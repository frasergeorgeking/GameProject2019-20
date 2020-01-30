using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteColor : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] Color newColor = Color.white; //Set default colour to white

    //Private Variables
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        //Define Variables
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        SetNewColor();
    }

    public void SetNewColor()
    {
        spriteRenderer.color = newColor;
    }
}