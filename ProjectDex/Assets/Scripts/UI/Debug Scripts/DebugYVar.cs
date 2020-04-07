using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugYVar : MonoBehaviour
{
    //Private Variables
    private PlayerController playerController;
    private TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        playerController = ReferenceManager.Instance.GetPlayerRef().GetComponent<PlayerController>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        textMeshProUGUI.SetText(CalculateFixedRatioReward.Instance.GetCurrentY().ToString());
    }
}
