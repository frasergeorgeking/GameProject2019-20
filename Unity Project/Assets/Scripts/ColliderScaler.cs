using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScaler : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] GameObject topBox;
    [SerializeField] GameObject bottomBox;
    [SerializeField] GameObject leftBox;
    [SerializeField] GameObject rightBox;
    [SerializeField] [Range (-6f, 6f)] float verticalUnitsToBuffer = 1f;
    [SerializeField] [Range(-6f, 6f)] float horizontalUnitsToBuffer = 1f;

    //Private Variables
    private Vector3 boxTransform;
    
    //Collider Code Must Remain in Start(), as GameController Variables are Assigned in Awake()
    void Start()
    {
        //Move Screen Boundary Colliders & Offset by unitsToBuffer
        //Top Box
        boxTransform = topBox.transform.position;
        boxTransform.y = GameController.maxY + verticalUnitsToBuffer;
        topBox.transform.position = boxTransform;

        //Bottom Box
        boxTransform = bottomBox.transform.position; 
        boxTransform.y = GameController.minY - verticalUnitsToBuffer;
        bottomBox.transform.position = boxTransform;

        //Left Box
        boxTransform = leftBox.transform.position; 
        boxTransform.x = GameController.minX - horizontalUnitsToBuffer;
        leftBox.transform.position = boxTransform;

        //Right Box
        boxTransform = rightBox.transform.position;
        boxTransform.x = GameController.maxX + horizontalUnitsToBuffer;
        rightBox.transform.position = boxTransform;
    }
}
