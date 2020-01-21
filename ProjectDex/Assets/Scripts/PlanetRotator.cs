using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(1f, 50f)] float speed;
    
    //Private Variables
    

    public enum rotationAxis
    {
        xAxis,
        yAxis,
        zAxis
    }

    public rotationAxis desiredAxis;

    private void FixedUpdate()
    {
        switch (desiredAxis)
        {
            case (rotationAxis.xAxis):
                transform.Rotate(Vector3.left * (Time.deltaTime * speed));
                break;

            case (rotationAxis.yAxis):
                transform.Rotate(Vector3.up * (Time.deltaTime * speed));
                break;

            case (rotationAxis.zAxis):
                transform.Rotate(Vector3.forward * (Time.deltaTime * speed));
                break;
        }

    }


}

