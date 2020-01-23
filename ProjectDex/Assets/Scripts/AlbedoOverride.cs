using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Updates Material in Edit Mode, in Addition to Play Mode
[ExecuteInEditMode]
public class AlbedoOverride : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] Color albedoOverrideCol = Color.white; //Colour by default set to white
    
    //Private Variables
    private MeshRenderer meshRenderer;

    void Awake()
    {
        //Define Variables
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sharedMaterial.color = albedoOverrideCol; //Directly Update Colour of SharedMaterial through Renderer
    }

}
