using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController sharedInstance;

    public Sprite heartFull;
    public Sprite heartEmpty;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private Image heart1Image;
    private Image heart2Image;
    private Image heart3Image;


    private int playerHealth;

    private void Awake()
    {
        sharedInstance = this;
    }

    void Start()
    {
        heart1Image = heart1.GetComponent<Image>();
        heart2Image = heart2.GetComponent<Image>();
        heart3Image = heart3.GetComponent<Image>();

    }

    void Update()
    {

    }

    public void RemoveHeart(int playerHealth)
    {
        if (playerHealth == 3)
        {
            heart3Image.sprite = heartEmpty;
        }

        if (playerHealth == 2)
        {
            heart2Image.sprite = heartEmpty;
        }
    
        if (playerHealth == 1)
        {
            heart1Image.sprite = heartEmpty;
        }
    }
}
