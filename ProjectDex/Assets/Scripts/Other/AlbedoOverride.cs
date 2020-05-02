using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Updates Material in Edit Mode, in Addition to Play Mode (scene must be opened in play mode at least once for changes to update)
//NOTE - Unity Throws Warning over Material Leakage into Scene, however this is not an issue if albedo colour is defined exclusively with this component!
[ExecuteInEditMode]
public class AlbedoOverride : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] Color albedoOverrideCol = Color.white; //Colour by default set to white

    //Private Variables
    private MeshRenderer meshRenderer;
    private Material matieral;

    void Awake()
    {
        //Define Variables
        meshRenderer = GetComponent<MeshRenderer>();
        matieral = meshRenderer.material; //Create new instance of material
        matieral.color = albedoOverrideCol; //Update colour of new instance
    }
}
