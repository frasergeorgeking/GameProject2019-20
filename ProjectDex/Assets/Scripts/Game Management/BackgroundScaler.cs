using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{   
    /*
    PLEASE NOTE: All maths included in this scaler works on the provision that the background tile is exactly 1 Unity Unit both vertically and horizontally.
    For example, at a declared sprite rate of 100 Pixels per Unit, a suitale background tile would be 100px * 100px.
    */

    //Editor-Facing Private Variables
    [SerializeField] GameObject backgroundTile; //Reference to GameObject Prefab - !!SPRITE MUST BE 1 UNIT SQUARED!!

    //Private Variables
    //Declare Arena Properties
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    //Declare Scaler Properties 
    private List<GameObject> backgroundTiles;
    private int gridWidth;
    private int gridHeight;
    private Vector3 newTileTransform;

    void Start()
    {
        //Define Arena Properties
        minX = ReferenceManager.Instance.GetGameManagerRef().GetComponent<ArenaScaler>().GetArenaBoundary("minX");
        maxX = ReferenceManager.Instance.GetGameManagerRef().GetComponent<ArenaScaler>().GetArenaBoundary("maxX");
        minY = ReferenceManager.Instance.GetGameManagerRef().GetComponent<ArenaScaler>().GetArenaBoundary("minY");
        maxY = ReferenceManager.Instance.GetGameManagerRef().GetComponent<ArenaScaler>().GetArenaBoundary("maxY");

        //Define Scaler Properties
        gridWidth = Mathf.CeilToInt(ReferenceManager.Instance.GetGameManagerRef().GetComponent<ArenaScaler>().GetArenaXSize());
        gridHeight = Mathf.CeilToInt(ReferenceManager.Instance.GetGameManagerRef().GetComponent<ArenaScaler>().GetArenaYSize());

        InitialiseBackgroundTiles();
        InitialiseFirstTileTransform();
        AdjustTileTransforms();
        
    }

    private void InitialiseBackgroundTiles()
    {
        backgroundTiles = new List<GameObject>(); //Initialise backgroundTiles list

        //Calculate Total Number of Required Tiles
        int totalRequiredTiles = gridHeight * gridWidth; //totalRequiredTiles = height * width
        
        for (int i = 0; i < totalRequiredTiles; i++)
        {
            //Declare new GameObject, Set to Value of backgroundTile and add to backgroundTiles list
            GameObject emptyGameObject;
            emptyGameObject = Instantiate(backgroundTile);
            backgroundTiles.Add(emptyGameObject);
        }
    }

    private void InitialiseFirstTileTransform()
    {
        newTileTransform = new Vector3 ((minX + 1), (minY + 1), 0); //Start at minimum X/Y position (i.e. bottom left tile)
    }

    private void AdjustTileTransforms()
    {
        for (int i = 0; i < backgroundTiles.Count; i++)
        {
            //Define 1D to 2D Lookup Variables
            int x = (i % gridWidth);
            int y = (i / gridWidth);

            UpdateGameObjectPosition(newTileTransform, backgroundTiles[i]);

            //If Not on East Border, Increment 'x' Axis Transform
            if (x < (gridWidth - 1))
            {
                newTileTransform = new Vector3 ((newTileTransform.x + 1), newTileTransform.y, 0);
            }

            //If on East Border, Reset 'x' Axis Transform & Increment 'y' Axis Transform
            else if (x == (gridWidth - 1))
            {
                Debug.Log("Index Pos " +i + " on East Border");
                newTileTransform = new Vector3 ((backgroundTiles[gridWidth * y].transform.position.x), (backgroundTiles[gridWidth * y].transform.position.y + 1), 0);
            }
        }
        
    }

    private void UpdateGameObjectPosition (Vector3 newPosition, GameObject gameObjectToUpdate)
    {
        gameObjectToUpdate.transform.position = newPosition;
    }

}
