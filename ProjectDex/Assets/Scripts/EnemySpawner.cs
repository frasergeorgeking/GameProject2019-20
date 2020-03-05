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
        public int waveracerEnemyToSpawn;
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
    private GameObject enemy03;
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

        for (int i = 0; i < wave.waveracerEnemyToSpawn; i++)
        {
            SpawnEnemy("enemy03");
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

        if (enemyToSpawnTag == "enemy03")
        {
            enemy03 = ObjectPooler.sharedInstance.GetPooledObject("enemy03");

            if (enemy03 != null)
            {
                enemy03.transform.position = CalculateRandomSpawnPoint();

                enemy03.SetActive(true);//Spawn Enemy
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
        GameObject[] enemy03s = GameObject.FindGameObjectsWithTag("enemy03");

        return enemy01s.Length + enemy02s.Length + enemy03s.Length; //Return combined total for each individual array - if adding additional enemy classes in the future, rework return function (not desirable to have manual dependencies)
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
