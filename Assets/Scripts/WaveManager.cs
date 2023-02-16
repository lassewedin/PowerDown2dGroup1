using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

[Serializable]
public class Wave
{
    public string waveName;
    public int numberOfEnemies;
    public GameObject[] enemyTypes;
    public float spawnIntervalSeconds;
}
public class WaveManager : MonoBehaviour
{
    public float secondsBetweenWaves;
    [SerializeField] private Wave[] waves;
    public Transform[] enemySpawnPoints;

    private Wave currentWave;
    private int currentWaveIndex;
    private bool canSpawnEnemy = true;
    private float nextSpawnTime;
    public void Update()
    {
	    currentWave = waves[currentWaveIndex];
        SpawnWave();
        
        //UGLY CHECK TO SEE IF THERE'S ANY ENEMIES LEFT
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0 && !canSpawnEnemy && currentWaveIndex+1 != waves.Length)
        {
           StartNextWave();
        }
    }

    public void StartNextWave()
    {
        currentWaveIndex++;
        canSpawnEnemy = true;
        nextSpawnTime = Time.time + secondsBetweenWaves;
    }

    public void SpawnWave()
    {
        if (canSpawnEnemy && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.enemyTypes[UnityEngine.Random.Range(0, currentWave.enemyTypes.Length)];
            Transform randomSpawnPoint = enemySpawnPoints[UnityEngine.Random.Range(0, enemySpawnPoints.Length)];
            Instantiate(randomEnemy, randomSpawnPoint.position, quaternion.identity);
            
            currentWave.numberOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnIntervalSeconds;

            if (currentWave.numberOfEnemies == 0)
            {
                canSpawnEnemy = false;
            }
        }
    }
}
