using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] float moveThrust = 100f;

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
        Debug.Log(move); //Debug Test
    }

    void Fire()
    {
        Debug.Log("Fired"); //Debug Test
    }

}
