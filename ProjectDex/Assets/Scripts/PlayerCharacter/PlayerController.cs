using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] float moveThrust = 100f;
    [SerializeField] float deadZone = 0.25f;

    //Private Variables
    private Rigidbody2D rb;
    private PlayerControls controls; //PlayerControls class generated through new Input Manager, selected option on PlayerControls.inputactions - prevents manual string lookups on individual actions (e.g. "Fire")
    private Vector2 move;

    void Awake()
    {
        //Pull or create references
        rb = GetComponent<Rigidbody2D>();
        controls = new PlayerControls(); //Must be placed in Awake() to ensure OnEnable() fires correctly

        //Define Logic for Input Actions
        controls.Gameplay.Fire.performed += ctx => Fire(); //'Fire' Button, calls Fire() Method
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>(); //'Move' Axis Data, updates move Vector 2
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero; //On release of stick, zero out move Vector 2
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

        //Calculate Stick Angle
        float angle = Mathf.Atan2(move.x, move.y) * Mathf.Rad2Deg;

        //Perform Zero-Check on Angle; Prevents Player Character from Locking Upwards when Stick is Released/Dead-Zone Reached
        if (angle != 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -angle)); //Update Rotation in Accordance with Angle
        }


    }


    private void Fire()
    {
        Debug.Log("Fired"); //Debug Test
    }

}
