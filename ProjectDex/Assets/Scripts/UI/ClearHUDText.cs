using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearHUDText : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] TextMeshProUGUI[] hudTextToClear;
    [SerializeField] TextMeshProUGUI newText;

    void Awake()
    {
        newText.gameObject.SetActive(false); //Hide newText on Awake
    }

    public void ShowNewText()
    {
        //Iterate through text components and set inactive
        for (int i = 0; i < hudTextToClear.Length; i++)
        {
            hudTextToClear[i].gameObject.SetActive(false);
        }
        
        newText.gameObject.SetActive(true); //Show newText
    }

}
