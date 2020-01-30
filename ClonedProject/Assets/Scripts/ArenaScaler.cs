using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaScaler : MonoBehaviour
{
    //Create Shared Instance
    private static ArenaScaler sharedInstance;
    public static ArenaScaler Instance { get { return sharedInstance; } } //Getter, returns private sharedInstance
   
    //Editor-Facing Private Variables
    [SerializeField] float arenaXSize = 40f;
    [SerializeField] float arenaYSize = 25f;
    [SerializeField] float colliderWidth = 1f;
    [SerializeField] float colliderBuffer = 2f;
    [SerializeField] Vector3 startingPos = new Vector3(0,0,0);
    [SerializeField] BoxCollider2D[] boundaryTriggers;

    void Awake()
    {
        //Set Shared Instance
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            sharedInstance = this;
        }
       
        //Check Array Length is Correct
        if (boundaryTriggers.Length != 4)
        {
            Debug.LogError("Invalid number of boundaryTriggers detected. Please ensure 4 boundaryTriggers are present and referenced in the Editor!");
        }
        
        else
        {
            //Scale Boundary Triggers
            for (int i = 0; i < boundaryTriggers.Length; i++)
            {
                if (i < 2) //Index positions 0/1 = vertical boundaries
                {
                    boundaryTriggers[i].size = new Vector2((arenaXSize + colliderBuffer), colliderWidth); //Set vertical size
                }
                else if (i >= 2) //Index positions 2/3 = horizontal boundaries
                {
                    boundaryTriggers[i].size = new Vector2(colliderWidth, (arenaYSize + colliderBuffer)); //Set horizontal size
                }
            }

            //Set Position of Boundary Triggers
            boundaryTriggers[0].transform.position = startingPos + new Vector3(0, (arenaYSize / 2) + (colliderWidth / 2), 0); //Index Pos 0 = top boundary
            boundaryTriggers[1].transform.position = startingPos - new Vector3(0, (arenaYSize / 2) + (colliderWidth / 2), 0); //Index Pos 1 = bottom boundary
            boundaryTriggers[2].transform.position = startingPos - new Vector3((arenaXSize / 2) + (colliderWidth / 2), 0, 0); //Index Pos 2 = left boundary
            boundaryTriggers[3].transform.position = startingPos + new Vector3((arenaXSize / 2) + (colliderWidth / 2), 0, 0); //Index Pos 3 = right boundary  
        }
    }

    public float GetArenaBoundary(string boundaryValueRequired)
    {
        switch (boundaryValueRequired)
        {
            case ("minX"):
                return boundaryTriggers[2].transform.position.x;
                break;

            case ("maxX"):
                return boundaryTriggers[3].transform.position.x;
                break;

            case ("minY"):
                return boundaryTriggers[1].transform.position.y;
                break;

            case ("maxY"):
                return boundaryTriggers[0].transform.position.y;
                break;

            default:
                throw new Exception("Invalid case detected. Please use 'minX', 'maxX' etc...");
                break;
        }
    }

    public float GetColliderBufferSize()
    {
        return colliderBuffer;
    }



}
