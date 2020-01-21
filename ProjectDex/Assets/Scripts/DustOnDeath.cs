using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustOnDeath : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] GameObject dust;

    void OnDisable()
    {
        //SpawnDust()
    }

}
