using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScaler : MonoBehaviour
{
    //Declare Variables
    [SerializeField] GameObject topBox;
    [SerializeField] GameObject bottomBox;
    [SerializeField] GameObject leftBox;
    [SerializeField] GameObject rightBox;
    [SerializeField] [Range (-3f, 3f)] float verticalUnitsToBuffer = 1f;
    [SerializeField] [Range(-3f, 3f)] float horizontalUnitsToBuffer = 1f;

    Vector3 boxTransform;
    
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
