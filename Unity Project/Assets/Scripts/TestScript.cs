using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
     // Start is called before the first frame update
    void Start()
    {
        float[] noteLookup = new float[4];

        noteLookup[0] = 1f;
        noteLookup[1] = 2f;
        noteLookup[2] = 3f;
        noteLookup[3] = 4f;

        foreach (float item in noteLookup)
        {
            Debug.Log(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
