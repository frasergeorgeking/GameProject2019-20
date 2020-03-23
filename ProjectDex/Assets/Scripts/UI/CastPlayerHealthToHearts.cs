using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastPlayerHealthToHearts : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] List<GameObject> heartGameObjects;
    [SerializeField] GameObject player;

    //Private Variables
    private List<Image> heartImageComponents;
    private PlayerController playerController;
    
    void Awake()
    {
        //Iterate Through heartGameObjects List & Add Image Component Reference to heartImageComponents List
        foreach (GameObject heart in heartGameObjects)
        {
            heartImageComponents.Add(heart.GetComponent<Image>());
        }

        playerController = player.GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        
    }

}
