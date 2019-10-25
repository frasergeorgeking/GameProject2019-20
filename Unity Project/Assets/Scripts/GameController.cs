using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject enemyShip;
    [SerializeField] GameObject[] enemySpawnPoints;
    [SerializeField] float spawnTimer;
    [SerializeField] int maxEnemies;

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

    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        GameObject selectedSpawn = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)];
        
        //**Update to Pull from Object Pool**
        Instantiate(enemyShip, selectedSpawn.transform);
    }

}
