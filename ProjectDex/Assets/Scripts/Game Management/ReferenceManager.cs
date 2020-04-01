using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    //Create Shared Instance
    private static ReferenceManager sharedInstance;
    public static ReferenceManager Instance { get { return sharedInstance; } }
    
    //Editor-Facing Private Variables
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject audioManager;
    [SerializeField] GameObject uiCanvas;
    [SerializeField] GameObject mainCamera;
    
    void Awake()
    {
        sharedInstance = this;
    }

    //Getter Functions
    public GameObject GetPlayerRef()
    {
        return player;
    }

    public GameObject GetGameManagerRef()
    {
        return gameManager;
    }

    public GameObject GetAudioManagerRef()
    {
        return audioManager;
    }

    public GameObject GetUICanvasRef()
    {
        return uiCanvas;
    }

    public GameObject GetMainCameraRef()
    {
        return mainCamera;
    }


}
