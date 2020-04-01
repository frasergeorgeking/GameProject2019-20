using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(2f, 50f)] float baseSpeed = 10f;
    [SerializeField] [Range(0f, 4f)] float shootCooldown = 0.2f;
    [SerializeField] [Range(1, 15)] int playerHealth = 3;
    [SerializeField] [Range(0.1f, 2f)]float hitProtection = 1f;
    [SerializeField] [Range(0f, 1f)] float leftStickDeadZone = 0.365f;
    [SerializeField] [Range(0f, 1f)] float rightStickDeadZone = 0.365f;

    //Private Variables
    private Rigidbody2D playerRB;
    private float currentPlayerSpeed;

    private PlayerControls controls; //PlayerControls class generated through new Input Manager, selected option on PlayerControls.inputactions - prevents manual string lookups on individual actions
    private Vector2 move; //'move' Vector2 used to map Axis data from left joystick to
    private Vector2 shoot; //'shoot' Vector2 used to map Axis data from right joystick to

    private bool canShoot = true; //Used for shoot cooldown timer
    private bool canBeHit = true; //Used to track invincibility timing
    
    private GameObject bullet; //Container for bullet GameObject Reference

    private CastPlayerHealthToHearts castPlayerHealthToHearts;

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
    }

    void Start()
    {
        castPlayerHealthToHearts = ReferenceManager.Instance.GetUICanvasRef().GetComponent<CastPlayerHealthToHearts>(); //Pull Reference to Hearts UI Controller
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
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
            Mathf.Clamp(playerRB.position.x, (ArenaScaler.Instance.GetArenaBoundary("minX") + ArenaScaler.Instance.GetColliderBufferSize()), (ArenaScaler.Instance.GetArenaBoundary("maxX") - ArenaScaler.Instance.GetColliderBufferSize())),
            Mathf.Clamp(playerRB.position.y, (ArenaScaler.Instance.GetArenaBoundary("minY") + ArenaScaler.Instance.GetColliderBufferSize()), (ArenaScaler.Instance.GetArenaBoundary("maxY") - ArenaScaler.Instance.GetColliderBufferSize()))
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
        if (move != new Vector2(0,0))
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
            StartCoroutine(Shoot(shoot)); //If out of dead-zone AND canShoot, run Shoot Coroutine
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
        //Pull bullet Reference from Pooler
        bullet = ObjectPooler.sharedInstance.GetPooledObject("playerBullet");
        
        if (bullet != null) //Peform Null-Check on bullet
        {
            //Set bullet position & rotation to that of player character
            bullet.transform.position = gameObject.transform.position;
            bullet.transform.rotation = gameObject.transform.rotation;
            bullet.SetActive(true); //Spawn Bullet
            Physics2D.IgnoreCollision(bullet.GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>()); //Create collision exception for bullet col & player col

            //Pull Reference to Neccesary bullet Components
            Rigidbody2D bulletSpawnedRB = bullet.GetComponent<Rigidbody2D>();
            PlayerBullet bulletPlayerBullet = bullet.GetComponent<PlayerBullet>();

            //Set bullet Velocity
            Vector2 newShootPos = CalculateShootPos(shootRef);
            bulletSpawnedRB.velocity = new Vector2((newShootPos.x * bulletPlayerBullet.GetBulletSpeed()), (newShootPos.y * bulletPlayerBullet.GetBulletSpeed()));
        }
    }

    private Vector2 CalculateShootPos(Vector2 shootRef)
    {
        float rotation = Mathf.Atan2(shootRef.x, shootRef.y); //Convert stick data into radians
        
        //Convert Radians into x/y Values
        float x = Mathf.Sin(rotation);
        float y = Mathf.Cos(rotation);
        
        return new Vector2 (x, y); //Return new Vector2 - due to nature of conversion from radians, new Vector2 will always be as if the stick is at the perimeter of its casing (i.e. returned values are 'maxed' out)
    }

    private void GameOver()
    {
        gameObject.SetActive(false); //Destroy Player
        SceneLoader.Instance.LoadNextScene(); //Load GameOver Scene
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

    //Getter Functions
    public float GetCurrentPlayerSpeed()
    {
        return currentPlayerSpeed;
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
