using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugPlayerVarBinding : MonoBehaviour
{
    //Private Variables
    private PlayerController playerController;
    private TextMeshProUGUI textMeshProUGUI;

    //Create List Selection List in Editior
    public enum playerVariables
    {
        currentSpeed,
        baseSpeed,
        rigidBodyMass,
        linearDrag,
        health
    }

    public playerVariables desiredVariable;

    void Start()
    {
        //Define Variables
        playerController = ReferenceManager.Instance.GetPlayerRef().GetComponent<PlayerController>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
    
    void FixedUpdate()
    {
        //Switch based on selected variable
        switch (desiredVariable)
        {
            case (playerVariables.currentSpeed):
            {
                UpdateText(playerController.GetCurrentPlayerVelocity().ToString());
                break;
            }

            case (playerVariables.baseSpeed):
            {
                UpdateText(playerController.GetBaseSpeed().ToString());
                break;
            }

            case (playerVariables.rigidBodyMass):
            {
                UpdateText(playerController.GetRBMass().ToString());
                break;
            }

            case (playerVariables.linearDrag):
            {
                UpdateText(playerController.GetRBLinearDrag().ToString());
                break;
            }

            case (playerVariables.health):
                UpdateText(playerController.GetHealth().ToString());
                break;
        }
    }

    private void UpdateText(string displayText)
    {
        textMeshProUGUI.SetText(displayText);
    }
}
