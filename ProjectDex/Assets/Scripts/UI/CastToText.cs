using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CastToText : MonoBehaviour
{
    //Private Variables
    private PlayerController playerController;
    private TextMeshProUGUI textMeshProUGUI;

    //Create Selection List in Editor
    public enum playerVarToCast
    {
        xValue,
        yValue,
        playerHealth
    }

    //Create Object Reference to Enum
    public playerVarToCast selectedVar;

    void Start()
    {
        playerController = ReferenceManager.Instance.GetPlayerRef().GetComponent<PlayerController>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        switch (selectedVar)
        {
            case (playerVarToCast.xValue):
                textMeshProUGUI.SetText(CalculateFixedRatioReward.Instance.GetCurrentX().ToString());
                break;

            case (playerVarToCast.yValue):
                textMeshProUGUI.SetText(CalculateFixedRatioReward.Instance.GetCurrentY().ToString());
                break;

            case (playerVarToCast.playerHealth):
                textMeshProUGUI.SetText(playerController.GetHealth().ToString());
                break;
        }
    }

}
