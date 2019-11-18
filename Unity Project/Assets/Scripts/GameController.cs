using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Spawning Variables
    [SerializeField] GameObject[] enemySpawnPoints;
    private GameObject enemyShip;
    private int maxEnemies;
    private int currentEnemies;

    //Screen Boundary Variables
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
        maxEnemies = 8;
        //NOTE - UPDATE CODE TO DYNAMICALLY MOVE SPAWNERS IN ACCORANCE W/ MIN-MAX X/Y VALUES
    }

    void Update()
    {
        currentEnemies = ObjectPooler.sharedInstance.GetTotalActiveNumOfObjects("enemy01");

        if (currentEnemies < maxEnemies)
        {
            SpawnEnemy();
        }
        
        //Debug Enemy Spawn
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        //Pull Reference of Enemy from Object Pooler
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

    /*IEnumerator EnemyTimer()
    {

    }
    */
    
}
