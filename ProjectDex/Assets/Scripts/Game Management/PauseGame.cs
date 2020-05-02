using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] GameObject pauseGameSprite;

    void Awake()
    {
        pauseGameSprite.GetComponent<Image>().enabled = false; //Hide pause game sprite on awake
    }

    public void StartPauseGame()
    {
        Time.timeScale = 0; //Sets time dilation to 0 - i.e. Freezes time
        pauseGameSprite.GetComponent<Image>().enabled = true; //Show pause game sprite

    }

    public void EndPauseGame()
    {
        Time.timeScale = 1; //Resets time to base scale of 1
        pauseGameSprite.GetComponent<Image>().enabled = false; //Hide pause game sprite
    }

}
