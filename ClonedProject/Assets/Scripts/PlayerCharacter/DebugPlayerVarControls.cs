using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPlayerVarControls : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] float baseSpeedIncrementVal;
    [SerializeField] float massIncrementVal;
    [SerializeField] float dragIncrementVal;

    //Private Variables
    private PlayerControls controls;
    private PlayerController playerController;

    void OnEnable()
    {
        controls.Debug.Enable();
    }

    void OnDisable()
    {
        controls.Debug.Disable();
    }

    void Awake()
    {
        //Define Variables
        playerController = GetComponent<PlayerController>();
        controls = new PlayerControls();

        //Define Logic for Input Actions
        controls.Debug.LeftButtonDebug.performed += ctx => DecreaseBaseSpeed();
        controls.Debug.RightButtonDebug.performed += ctx => IncreaseBaseSpeed();
        controls.Debug.UpButtonDebug.performed += ctx => IncreaseMass();
        controls.Debug.DownButtonDebug.performed += ctx => DecreaseMass();
        controls.Debug.SelectButtonDebug.performed += ctx => DecreaseDrag();
        controls.Debug.StartButtonDebug.performed += ctx => IncreaseDrag();
    }

    private void IncreaseBaseSpeed()
    {
        float currentBaseSpeed = playerController.GetBaseSpeed();
        float newBaseSpeed = currentBaseSpeed + baseSpeedIncrementVal;
        playerController.SetBaseSpeed(newBaseSpeed);
    }

    private void DecreaseBaseSpeed()
    {
        float currentBaseSpeed = playerController.GetBaseSpeed();
        float newBaseSpeed = currentBaseSpeed - baseSpeedIncrementVal;
        playerController.SetBaseSpeed(newBaseSpeed);
    }

    private void IncreaseMass()
    {
        float currentMass = playerController.GetRBMass();
        float newMass = currentMass + massIncrementVal;
        playerController.SetRBMass(newMass);
    }

    private void DecreaseMass()
    {
        float currentMass = playerController.GetRBMass();
        float newMass = currentMass - massIncrementVal;
        playerController.SetRBMass(newMass);
    }

    private void IncreaseDrag()
    {
        float currentDrag = playerController.GetRBLinearDrag();
        float newDrag = currentDrag + dragIncrementVal;
        playerController.SetRBLinearDrag(newDrag);
    }

    private void DecreaseDrag()
    {
        float currentDrag = playerController.GetRBLinearDrag();
        float newDrag = currentDrag - dragIncrementVal;
        playerController.SetRBLinearDrag(newDrag);
    }
    
}
