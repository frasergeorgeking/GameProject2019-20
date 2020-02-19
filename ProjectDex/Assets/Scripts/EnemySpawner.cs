using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public int homingEnemyToSpawn;
        public int interceptorEnemyToSpawn;
    }

    //Editor-Facing Private Variables
    [SerializeField] Wave[] waves;
    [SerializeField] float timeBetweenWaves;


    //Private Variables
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private GameObject enemy01;
    private GameObject enemy02;
    private int currentWave = 1;

    void Start()
    {
        //Define Variables
        minX = ArenaScaler.Instance.GetArenaBoundary("minX");
        maxX = ArenaScaler.Instance.GetArenaBoundary("maxX");
        minY = ArenaScaler.Instance.GetArenaBoundary("minY");
        maxY = ArenaScaler.Instance.GetArenaBoundary("maxY");

        SpawnWave(waves[0]); //Spawn First Wave
    }

    void FixedUpdate()
    {
        if (IsWaveOver())
        {
            currentWave++;
            SpawnWave(waves[currentWave - 1]);
        }
    }

    private void SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.homingEnemyToSpawn; i++)
        {
            SpawnEnemy("enemy01");
        }

        for (int i = 0; i < wave.interceptorEnemyToSpawn; i++)
        {
            SpawnEnemy("enemy02");
        }

    }

    private void SpawnEnemy(string enemyToSpawnTag)
    {
        if (enemyToSpawnTag == "enemy01")
        {
            enemy01 = ObjectPooler.sharedInstance.GetPooledObject("enemy01");

            if (enemy01 != null)
            {
                enemy01.transform.position = CalculateRandomSpawnPoint();

                enemy01.SetActive(true);//Spawn Enemy
            }
        }

        if (enemyToSpawnTag == "enemy02")
        {
            enemy02 = ObjectPooler.sharedInstance.GetPooledObject("enemy02");

            if (enemy02 != null)
            {
                enemy02.transform.position = CalculateRandomSpawnPoint();

                enemy02.SetActive(true);//Spawn Enemy
            }
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
        //Find all objects in scene with enemy tags
        GameObject[] enemy01s = GameObject.FindGameObjectsWithTag("enemy01");
        GameObject[] enemy02s = GameObject.FindGameObjectsWithTag("enemy02");

        return enemy01s.Length + enemy02s.Length; //Return combined total for each individual array
    }

    private bool IsWaveOver()
    {
        if (GetCurrentEnemies() == 0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

}
