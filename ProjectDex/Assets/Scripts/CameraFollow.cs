using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed;
    [SerializeField] Vector3 offset;

    void LateUpdate()
    {
        //Camera Tracking Logic Placed in LateUpdate() to ensure PlayerController Movement has occurred first
        Vector3 desiredPosition = target.position + offset; 
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, (smoothSpeed * Time.deltaTime)); //Multiplied by Time.deltaTime to ensure consistency between frames
        transform.position = smoothedPosition;
    }
}
