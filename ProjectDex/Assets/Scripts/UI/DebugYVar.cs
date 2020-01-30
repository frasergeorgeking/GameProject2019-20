using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugYVar : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] GameObject player;

    //Private Variables
    private PlayerController playerController;
    private TextMeshProUGUI textMeshProUGUI;

    void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        textMeshProUGUI.SetText(CalculateFixedRatioReward.Instance.GetCurrentY().ToString());
    }
}
