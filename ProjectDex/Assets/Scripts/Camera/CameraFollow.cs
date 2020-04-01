using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] Transform target;
    [SerializeField] [Range(0f, 0.5f)] float smoothTime = 0.085f;
    [SerializeField] Vector3 offset = new Vector3 (0,0,-5);

    void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    }
}
