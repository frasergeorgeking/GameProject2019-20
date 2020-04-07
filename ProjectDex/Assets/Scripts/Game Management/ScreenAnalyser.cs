using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAnalyser : MonoBehaviour
{
    //Create Shared Instance
    private static ScreenAnalyser sharedInstance;
    public static ScreenAnalyser Instance { get { return sharedInstance; } } //Getter, returns private sharedInstance

    //Editor-Facing Private Variables
    [SerializeField] GameObject mainCamera;

    //Private Variables
    private static float minX; //Declare Min/Max Screen Space Values - set to static as only defined once
    private static float maxX;
    private static float minY;
    private static float maxY;

    void Awake()
    {
        //Set Shared Instance
        if(sharedInstance != null && sharedInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            sharedInstance = this;
        }

        //Calculate Screen Corners in Relation to Distance from Camera
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        //Define Min/Max X & Y Boundary Values
        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;
    }

    public float GetScreenBoundary(string boundaryValueRequired)
    {
        switch (boundaryValueRequired)
        {
            case "minX":
                return minX;
            case "maxX":
                return maxX;
            case "minY":
                return minY;
            case "maxY":
                return maxY;
            default:
                throw new Exception("Invalid case detected. Please use 'minX', 'maxX' etc...");
        }
    }

    public Vector2 GetScreenResolution()
    {
        return new Vector2(Screen.width, Screen.height);
    }

}
