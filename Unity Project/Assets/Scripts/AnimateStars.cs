using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateStars : MonoBehaviour
{
    [SerializeField] GameObject[] starPrefabs;
    [SerializeField] [Range(0.01f, 1f)] float starMovementSpeed;

    private List<GameObject> spawnedStars;

    void Awake()
    {
        //Initialise List
        spawnedStars = new List<GameObject>();
        
        //Spawn Stars from Prefab & Add to List
        for (int i = 0; i < starPrefabs.Length; i++)
        {
            spawnedStars.Add (Instantiate(starPrefabs[i]));
        }

    }

    void Update()
    {     
        //*HARD CODED WITH MAGIC NUMBERS - REFACTOR!*
        spawnedStars[0].transform.Translate((Vector3.up * Time.deltaTime *starMovementSpeed), Space.World);
        spawnedStars[1].transform.Translate((Vector3.up * Time.deltaTime * (starMovementSpeed /2)), Space.World);
        spawnedStars[2].transform.Translate((Vector3.up * Time.deltaTime * (starMovementSpeed /4)), Space.World);
        spawnedStars[3].transform.Translate((Vector3.up * Time.deltaTime * (starMovementSpeed /8)), Space.World);
    }
}
