﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(1f, 50f)] float speed;
    [SerializeField] bool switchDirection = false;    

    public enum rotationAxis
    {
        xAxis,
        yAxis,
        zAxis
    }

    public rotationAxis desiredAxis;

    private void FixedUpdate()
    {
        //Switch Based on Selected Axis, Inverse Rotation if switchDirection == true
        switch (desiredAxis)
        {
            case (rotationAxis.xAxis):
                if (switchDirection)
                {
                    transform.Rotate(-Vector3.left * (Time.deltaTime * speed));
                }
                else
                {
                    transform.Rotate(Vector3.left * (Time.deltaTime * speed));
                }
                
                break;

            case (rotationAxis.yAxis):
                if (switchDirection)
                {
                    transform.Rotate(-Vector3.up * (Time.deltaTime * speed));
                }
                else
                {
                    transform.Rotate(Vector3.up * (Time.deltaTime * speed));
                }

                break;

            case (rotationAxis.zAxis):
                if (switchDirection)
                {
                    transform.Rotate(-Vector3.forward * (Time.deltaTime * speed));
                }
                else
                {
                    transform.Rotate(Vector3.forward * (Time.deltaTime * speed));
                }
                
                break;
        }

    }


}

