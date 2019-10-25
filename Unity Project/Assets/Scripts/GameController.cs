using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //[SerializeField] GameObject enemyShip;
    [SerializeField] GameObject[] enemySpawnPoints;
    [SerializeField] float spawnTimer;
    [SerializeField] int maxEnemies;

    private GameObject enemyShip;

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
        //NOTE - UPDATE CODE TO DYNAMICALLY MOVE SPAWNERS IN ACCORANCE W/ MIN-MAX X/Y VALUES
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
        //Pull Reference of Enemy from Object Pool
        enemyShip = ObjectPooler.sharedInstance.GetPooledObject("enemy01");

        //Select Random Spawn Point
        GameObject selectedSpawn = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)];

        if (enemyShip != null)
        {
            enemyShip.transform.position =  new Vector3 (selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, 0f);
            enemyShip.transform.rotation = selectedSpawn.transform.rotation;
            enemyShip.SetActive(true);
        }
    }
}
