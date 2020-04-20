using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(2f, 50f)] float baseSpeed = 10f; //The base speed value of the player - higher = faster
    [SerializeField] GameObject leftFireRef; //Reference to the left firing position - highlighted in Dex prefab
    [SerializeField] GameObject rightFireRef; //Reference to the right firing position - highlighted in Dex prefab
    [SerializeField] [Range(0f, 4f)] float shootCooldown = 0.2f; //The cooldown between shots, in seconds - lower cooldown = higher firing rate
    [SerializeField] [Range (0f, 20f)] float playerSpeedAccelerateShootThreshold = 10f; //The value threshold for playerRB.velocity.magnitude before player bullets are sped up to compensate (prevents player catching up to bullets)
    [SerializeField] [Range(1, 15)] int playerHealth = 3;
    [SerializeField] [Range(0.1f, 2f)]float hitProtection = 1f; //The period of time, in seconds, that the player is invincible for after being hit
    [SerializeField] [Range(0f, 1f)] float leftStickDeadZone = 0.365f; //The deadzone radius for the left movement stick, expressed between 0 - 1 (0 = center, 1 = perimeter)
    [SerializeField] [Range(0f, 1f)] float rightStickDeadZone = 0.365f; //The deadzone radius for the right shooting stick, expressed between 0 - 1 (0 = center, 1 = perimeter)

    //Private Variables
    private Rigidbody2D playerRB;
    private float currentPlayerSpeed; 

    private float arenaBufferSize; //Arena varibles used to track reference to arena size (arena dimensions can differ)
    private float arenaMinX; 
    private float arenaMaxX;
    private float arenaMinY;
    private float arenaMaxY;

    private PlayerControls controls; //PlayerControls class generated through new Input Manager, selected option on PlayerControls.inputactions - prevents manual string lookups on individual actions
    private Vector2 move; //'move' Vector2 used to map Axis data from left joystick to
    private Vector2 shoot; //'shoot' Vector2 used to map Axis data from right joystick to

    private bool canShoot = true; //Used for shoot cooldown timer
    private bool canBeHit = true; //Used to track invincibility timing
    private bool shootLeft = true; //Used for tracking which direction to fire from (alternates)
    
    private GameObject bullet; //Container for bullet GameObject Reference

    private CastPlayerHealthToHearts castPlayerHealthToHearts; //Used to cast playerHealth to UI Hearts

    private bool isGamePaused = false; //Bool flag used for toggling pause state

    void Awake()
    {
        //Define Variables
        playerRB = GetComponent<Rigidbody2D>();
        controls = new PlayerControls(); //Must be placed in Awake() to ensure OnEnable() fires correctly

        //Define Logic for Input Actions
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>(); //'Move' Axis Data, updates 'move' Vector2
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero; //On release of stick, zero out 'move' Vector2
        controls.Gameplay.Shoot.performed += ctx => shoot = ctx.ReadValue<Vector2>(); //'Shoot' Axis Data, updates 'shoot' Vector2
        controls.Gameplay.Shoot.canceled += ctx => shoot = Vector2.zero; //On release of stick, zero out 'shoot' Vector2
        controls.Gameplay.Pause.performed += ctx => PauseGame(); //On pressing start button, call PauseGame function
    }

    void Start()
    {
        //Define Arena Dimensions - Must be Performed in Start() as ArenaScaler Calculates Offsets in Awake()
        arenaBufferSize = ArenaScaler.Instance.GetColliderBufferSize();
        arenaMinX = ArenaScaler.Instance.GetArenaBoundary("minX");
        arenaMaxX = ArenaScaler.Instance.GetArenaBoundary("maxX");
        arenaMinY = ArenaScaler.Instance.GetArenaBoundary("minY");
        arenaMaxY = ArenaScaler.Instance.GetArenaBoundary("maxY");
        
        castPlayerHealthToHearts = ReferenceManager.Instance.GetUICanvasRef().GetComponent<CastPlayerHealthToHearts>(); //Pull Reference to Hearts UI Controller
    }

    void OnEnable()
    {
        controls.Gameplay.Enable(); //Enable 'Gameplay' Bindings of PlayerControls
    }

    void OnDisable()
    {
        controls.Gameplay.Disable(); //Disable 'Gameplay' Bindings of PlayerControls
    }

    void FixedUpdate()
    {
        HandlePlayerInput();
    }

    private void HandlePlayerInput()
    {
        //Clamp Player Position to Arena Boundary
        playerRB.position = new Vector2
            (
                Mathf.Clamp(playerRB.position.x, (arenaMinX + arenaBufferSize), (arenaMaxX - arenaBufferSize)),
                Mathf.Clamp(playerRB.position.y, (arenaMinY + arenaBufferSize), (arenaMaxY - arenaBufferSize))
            );
        
        //Perform Dead-Zone Check on Left Stick Input
        float absLeftStickMagnitude = Mathf.Abs(move.magnitude); //Absoloute Value used for Dead-Zone Comparison
        if (absLeftStickMagnitude < leftStickDeadZone)
        {
            move = Vector2.zero; //If in dead-zone, zero-out move Vector2
        }

        //Calculate Rotation Angle
        float leftStickAngle = Mathf.Atan2(move.x, move.y) * Mathf.Rad2Deg;

        //Perform Zero-Check on Input; Prevents Player Character from Locking Upwards when Stick is Released/Dead-Zone Reached
        if (move != Vector2.zero)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -leftStickAngle)); //Update Rotation of Dex in Accordance with Angle
            currentPlayerSpeed = CalculateSpeed(move.x, move.y); //Pass Stick Data to Thrust Algorithm
            playerRB.AddForce(move * currentPlayerSpeed, ForceMode2D.Force); //Note - AddForce directly uses physics system - Rigidbody mass and drag values dramatically affect handling  
        }

        //Perform Dead-Zone Check on Right Stick Input
        float absRightStickMagnitude = Mathf.Abs(shoot.magnitude); //Absoloute Value used for Dead-Zone Comparison
        if(absRightStickMagnitude < rightStickDeadZone)
        {
            shoot = Vector2.zero; //If in dead-zone, zero-out shoot Vector2
        }

        if ((absRightStickMagnitude > rightStickDeadZone) && (canShoot))
        {
            StartCoroutine(Shoot(shoot)); //If out of dead-zone AND canShoot, run Shoot Coroutine and pass through right stick data
        }

    }

    private float CalculateSpeed(float xPos, float yPos)
    {
        float currentStickRadius = CalculateRadius(xPos, yPos); //Calculate stick radius to judge speed - larger radius = higher speed
        float currentStickModifier = currentStickRadius * 100; //Multiply Stick Radius by 100 - output always between 0 - 100 (minimum bounds set by defined deadZone)

        //Logarithmic Function to Taper Speed Value
        float currentMultiplier = Mathf.Clamp(Mathf.Log(currentStickModifier, 10f), 0f, 2f); //"How many number 10s do we need to multiply to get to 'currentStickModifier'?" - currentModifier has a max value of 100, so max log return is 2f. Clamped to 2f for safety.

        float calculatedSpeed = currentMultiplier * baseSpeed; //Multiply currentMultipler by baseSpeed to create final calculatedSpeed
                
        return calculatedSpeed;
    }

    private float CalculateRadius(float x, float y)
    {
        //Standard Form Equation of a Circle - a and b values not required as they are both a constant of zero - i.e. centre of analog stick always 0,0
        float radiusSquared = (x * x) + (y * y); // (x^2) + (y^2) = r^2
        
        return Mathf.Sqrt(radiusSquared); //Return square root of radiusSquared
    }

    private void FireBullet(Vector2 shootRef)
    {
        //Declare and Define Starting Shoot Position
        Vector2 startingShootPos;

        if (shootLeft)
        {
            startingShootPos = leftFireRef.transform.position;
        }

        else
        {
            startingShootPos = rightFireRef.transform.position;
        }
        
        //Pull bullet Reference from Pooler
        bullet = ObjectPooler.sharedInstance.GetPooledObject("playerBullet");
        
        if (bullet != null) //Peform Null-Check on bullet
        {
            //Set bullet position & rotation to that of player character
            bullet.transform.position = startingShootPos;
            bullet.transform.rotation = gameObject.transform.rotation;
            bullet.SetActive(true); //Spawn Bullet
            Physics2D.IgnoreCollision(bullet.GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>()); //Create collision exception for bullet col & player col

            //Pull Reference to Neccesary bullet Components
            Rigidbody2D bulletSpawnedRB = bullet.GetComponent<Rigidbody2D>();
            PlayerBullet bulletPlayerBullet = bullet.GetComponent<PlayerBullet>();

            //Add Calculate Updated 'shoot' Vector2
            Vector2 uniformShootPos = CalculateShootPos(shootRef); //Converts pure stick data into uniform Vector2 (ensures bullets fire at same speed, regardless of right stick distance from perimeter)
            
            //Check Player Velocity Against Threshold to Speed up Bullets - Prevents player from catching up to bullets
            if (playerRB.velocity.magnitude > playerSpeedAccelerateShootThreshold)
            {
                Vector2 magnitudeMultipliedShootPos = uniformShootPos.normalized * (playerRB.velocity.magnitude / playerSpeedAccelerateShootThreshold); //Apply magnitude multiplier to normalised shoot position
                Vector2 finalShootPos = magnitudeMultipliedShootPos * bulletPlayerBullet.GetBulletSpeed(); //Create final shoot position by multiplying by bullet speed
                bulletSpawnedRB.AddForce(finalShootPos); //Update bullet rigidbody
            }

            //If Player Velocity Threshold not met, Fire Bullet Normally
            else
            {
                bulletSpawnedRB.AddForce(new Vector2((uniformShootPos.x * bulletPlayerBullet.GetBulletSpeed()), (uniformShootPos.y * bulletPlayerBullet.GetBulletSpeed()))); //Update bullet rigidbody
            }
        }

        shootLeft = !shootLeft; //Invert value of shootLeft

    }

    private Vector2 CalculateShootPos(Vector2 shootRef)
    {
        float rotation = Mathf.Atan2(shootRef.x, shootRef.y); //Convert stick data into radians
        
        //Convert Radians into x/y Values
        float x = Mathf.Sin(rotation);
        float y = Mathf.Cos(rotation);
        
        return new Vector2 (x, y); //Return new Vector2 - due to nature of conversion from radians, new Vector2 will always be as if the stick is at the perimeter of its casing (i.e. returned values are 'maxed' out)
    }

    private void PauseGame()
    {
        if (isGamePaused)
        {
            ReferenceManager.Instance.GetGameManagerRef().GetComponent<PauseGame>().EndPauseGame();
            isGamePaused = false;
        }

        else if (!isGamePaused)
        {
            ReferenceManager.Instance.GetGameManagerRef().GetComponent<PauseGame>().StartPauseGame();
            isGamePaused = true;
        }
    }

    private void GameOver()
    {
        gameObject.SetActive(false); //Destroy Player
        SceneLoader.Instance.LoadNextScene(); //Load GameOver Scene
    }

    public void TakeDamage(int damageDealt)
    {
        if (canBeHit) //Check for hit protection
        {
            StartCoroutine(HitProtection());

            if (playerHealth <= 1) //Check player health
            {
                GameOver();
            }

            else
            {
                playerHealth = playerHealth - damageDealt;
                castPlayerHealthToHearts.UpdateHearts(playerHealth);
            }
        }
    }

    IEnumerator Shoot(Vector2 shootRef)
    {
        //Run Firing Logic
        FireBullet(shootRef);
        canShoot = false;

        //Cooldown
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
    IEnumerator HitProtection()
    {
        canBeHit = false;

        yield return new WaitForSeconds(hitProtection); //'Cooldown' for hit invinsibility
        canBeHit = true;
    }

    //Getter Functions
    public float GetCurrentPlayerVelocity()
    {
        return Mathf.Clamp(playerRB.velocity.magnitude, 0.01f, 4000f);
    }

    public float GetBaseSpeed()
    {
        return baseSpeed;
    }

    public float GetRBMass()
    {
        return playerRB.mass;
    }

    public float GetRBLinearDrag()
    {
        return playerRB.drag;
    }

    public int GetHealth()
    {
        return playerHealth;
    }

    //Setter Functions
    public void SetBaseSpeed(float updatedBaseSpeed)
    {
        baseSpeed = updatedBaseSpeed;
    }

    public void SetRBMass(float updatedMass)
    {
        if (playerRB.useAutoMass) //Check if Auto Mass is enabled
        {
            playerRB.useAutoMass = false; //Turn off Auto Mass
            playerRB.mass = updatedMass;
        }
        else
        {
            playerRB.mass = updatedMass;
        }
    }

    public void SetRBLinearDrag(float updatedLinearDrag)
    {
        playerRB.drag = updatedLinearDrag;
    }
}
