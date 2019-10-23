using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Declare Variables for Screen Boundaries
    public static float minX, maxX, minY, maxY;

    void Awake()
    {
        // Calculate Screen Corners in Relation to Camera Distance
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        //Update Min & Max X/Y Boundary Values
        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;
    }

    void Update()
    {
        
    }
}
