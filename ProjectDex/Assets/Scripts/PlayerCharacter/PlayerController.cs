using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(2f, 25f)] float topSpeedModifier = 2f;
    [SerializeField] [Range(0.0f, 1f)] float deadZone = 0.365f;

    //Private Variables
    private Rigidbody2D playerRB;
    private PlayerControls controls; //PlayerControls class generated through new Input Manager, selected option on PlayerControls.inputactions - prevents manual string lookups on individual actions (e.g. "Fire")
    private Vector2 move; //'move' Vector2 used to map Axis data from left joystick to
    private Vector2 shoot; //'shoot' Vector2 used to map Axis data from right joystick to

    void Awake()
    {
        //Pull or create references
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

    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        UpdatePlayerMovement();
    }

    private void UpdatePlayerMovement()
    {     
        //Perform Dead-Zone Check on Stick Input
        if ((move.magnitude < deadZone) || (-move.magnitude > deadZone))
        {
            move = Vector2.zero; //Zero-Out Movement if in Dead-Zone
        }

        //Calculate Rotation Angle
        float angle = Mathf.Atan2(move.x, move.y) * Mathf.Rad2Deg;

        //Perform Zero-Check on Angle; Prevents Player Character from Locking Upwards when Stick is Released/Dead-Zone Reached
        if (angle != 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -angle)); //Update Rotation of Dex in Accordance with Angle
            float playerAcceleration = CalculateSpeed(move.x, move.y); //Pass Stick Data to Thrust Algorithm

            playerRB.velocity = new Vector2(move.x * playerAcceleration, move.y * playerAcceleration);
        }


    }

    private float CalculateSpeed(float xPos, float yPos)
    {
        float currentStickRadius = CalculateRadius(xPos, yPos); //Calculate stick radius to judge speed
        float currentSpeedModifier = currentStickRadius * topSpeedModifier;

        //Logarithmic Function to Taper Speed Value
        float currentSpeed = Mathf.Log(currentSpeedModifier, 1.16f);
                
        return currentSpeed; 
    }

    private float CalculateRadius(float x, float y)
    {
        //Standard Form Equation of a Circle - a and b values not required as they are both a constant of zero - i.e. centre of analog stick always 0,0
        float radiusSquared = (x * x) + (y * y); // (x^2) + (y^2) = r^2
        return Mathf.Sqrt(radiusSquared); //Return square root of radiusSquared
    }

 
}
