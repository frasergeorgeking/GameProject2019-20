using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryTriggerScaler : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(0f, 1f)] float unitsToBuffer; //Buffer 'pushes' trigger volumes away from edges of screen

    //Private Variables
    Vector3 updatedPosition; //Vector3 used as container to map updated trigger volume position to
    BoxCollider2D col; //Colider reference required for increasing X/Y size of collider at runtime

    //Create List Selection List in Editior
    public enum boundaries
    {
        topBoundary,
        bottomBoundary,
        leftBoundary,
        rightBoundary
    }

    //Creates Object Reference to Enum
    public boundaries currentBoundary;

    void Awake()
    {
        col = GetComponent<BoxCollider2D>(); //Define collider
    }

    void Start()
    {
        //Switches Flow Based on Selected Option in Editor
        switch (currentBoundary)
        {
            case boundaries.topBoundary:
                //Update Position of Boundary
                updatedPosition = new Vector3(0, ScreenAnalyser.Instance.GetScreenBoundary("maxY") + unitsToBuffer, 0);
                gameObject.transform.position = updatedPosition;

                //Update Collider Size
                col.size += new Vector2((ScreenAnalyser.Instance.GetScreenBoundary("maxX") * 2), 0);

                break;
            
            case boundaries.bottomBoundary:
                //Update Position of Boundary
                updatedPosition = new Vector3(0, ScreenAnalyser.Instance.GetScreenBoundary("minY") - unitsToBuffer, 0);
                gameObject.transform.position = updatedPosition;
                
                //Update Collider Size
                col.size += new Vector2((ScreenAnalyser.Instance.GetScreenBoundary("maxX") * 2), 0);
                
                break;
            
            case boundaries.leftBoundary:
                //Update Position of Boundary
                updatedPosition = new Vector3(ScreenAnalyser.Instance.GetScreenBoundary("minX") - unitsToBuffer, 0, 0);
                gameObject.transform.position = updatedPosition;
                
                //Update Collider Size
                col.size += new Vector2(0, (ScreenAnalyser.Instance.GetScreenBoundary("maxY") * 2));
                
                break;
            
            case boundaries.rightBoundary:
                //Update Position of Boundary
                updatedPosition = new Vector3(ScreenAnalyser.Instance.GetScreenBoundary("maxX") + unitsToBuffer, 0, 0);
                gameObject.transform.position = updatedPosition;
                
                //Update Collider Size
                col.size += new Vector2(0, (ScreenAnalyser.Instance.GetScreenBoundary("maxY") * 2));
               
                break;

            default:
                throw new Exception("Invalid case detected.");
                break;
        }
    }
}
