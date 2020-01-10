using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDebugger : MonoBehaviour
{
    private PlayerControls controls;
    private Vector2 leftStick;

    void Awake()
    {

        controls = new PlayerControls(); //Must be placed in Awake() to ensure OnEnable() fires correctly

        //Define Logic for Input Actions
        controls.Gameplay.Move.performed += ctx => leftStick = ctx.ReadValue<Vector2>(); //'Move' Axis Data, updates move Vector 2
        controls.Gameplay.Move.canceled += ctx => leftStick = Vector2.zero; //On release of stick, zero out move Vector 2
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
        Debug.Log(leftStick);
    }

    void FixedUpdate()
    {

    }

}
