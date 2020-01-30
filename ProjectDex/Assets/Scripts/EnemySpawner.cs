using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] int maxEnemies = 6;
    [SerializeField] float respawnDelay;


    //Private Variables
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private GameObject enemy01;
    private int currentEnemies;
    private bool canSpawn = true;

    void Start()
    {
        //Define Variables
        minX = ArenaScaler.Instance.GetArenaBoundary("minX");
        maxX = ArenaScaler.Instance.GetArenaBoundary("maxX");
        minY = ArenaScaler.Instance.GetArenaBoundary("minY");
        maxY = ArenaScaler.Instance.GetArenaBoundary("maxY");


    }

    void FixedUpdate()
    {
        currentEnemies = GetCurrentEnemies();

        
        if (currentEnemies < maxEnemies && canSpawn)
        {
            StartCoroutine(EnemyCooldown());
        }
        
    }

    private void SpawnEnemy()
    {
        enemy01 = ObjectPooler.sharedInstance.GetPooledObject("enemy01");

        if (enemy01 != null)
        {
            enemy01.transform.position = CalculateRandomSpawnPoint();

            enemy01.SetActive(true);//Spawn Enemy
        }
    }

    
    private Vector2 CalculateRandomSpawnPoint()
    {
        //Create Random X
        float randomX = Random.Range(minX, maxX);

        //Create Random Y
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }

    private int GetCurrentEnemies()
    {
        GameObject[] enemy01s = GameObject.FindGameObjectsWithTag("enemy01");

        return enemy01s.Length;
    }

    IEnumerator EnemyCooldown()
    {
        SpawnEnemy();
        canSpawn = false;

        yield return new WaitForSeconds(respawnDelay);
        canSpawn = true;
    }

}
