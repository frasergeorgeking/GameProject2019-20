using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugPlayerVarBinding : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] GameObject player;

    //Private Variables
    private PlayerController playerController;
    private TextMeshProUGUI textMeshProUGUI;

    public enum playerVariables
    {
        currentSpeed,
        baseSpeed,
        rigidBodyMass,
        linearDrag
    }

    public playerVariables desiredVariable;

    void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
    
    void FixedUpdate()
    {
        switch (desiredVariable)
        {
            case (playerVariables.currentSpeed):
            {
                UpdateText(playerController.GetCurrentPlayerSpeed().ToString());
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
                UpdateText(playerController.GetRBMass().ToString());
                break;
            }
        }
    }

    private void UpdateText(string displayText)
    {
        textMeshProUGUI.SetText(displayText);
    }
}
