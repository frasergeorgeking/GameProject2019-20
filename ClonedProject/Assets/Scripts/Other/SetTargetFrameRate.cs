using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetFrameRate : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(1, 400)] int targetFPS = 60;
    [SerializeField] bool forceDisableVSync = true;

    void Start()
    {
        Application.targetFrameRate = targetFPS; //Set Target FPS

        //Disable VSync
        if (forceDisableVSync)
        {
            QualitySettings.vSyncCount = 0;
        }
    }

}
