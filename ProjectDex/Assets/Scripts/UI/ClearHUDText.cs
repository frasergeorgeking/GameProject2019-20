using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearHUDText : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] TextMeshProUGUI[] hudText;

    public void ClearAllText()
    {
        for (int i = 0; i < hudText.Length; i++)
        {
            hudText[i].gameObject.SetActive(false);
        }
    }

}
