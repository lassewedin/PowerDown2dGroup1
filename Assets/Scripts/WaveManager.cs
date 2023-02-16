using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public Animator animator;
    public TextMeshProUGUI waveName;

    private Wave currentWave;
    private int currentWaveIndex;
    private bool canSpawnEnemy = true;
    private bool canAnimate = false;
    private float nextSpawnTime;
    public void Update()
    {
	    currentWave = waves[currentWaveIndex];
        SpawnWave();
        
        //UGLY CHECK TO SEE IF THERE'S ANY ENEMIES LEFT
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0) {
            if (canAnimate && currentWaveIndex + 1 != waves.Length) {
                waveName.text = waves[currentWaveIndex + 1].waveName;
                animator.SetTrigger("Complete");
                canAnimate = false;
                Invoke(nameof(NextAnimationStep), 2);
            }
            else //WE ARE DONE!?
            {
                Debug.Log("Game finished!");
            }
        }
    }

    public void NextAnimationStep() //Will be replaced once we get the powerup selection
    {
        HUD.ShowPowerDownSelection(true);
        animator.SetTrigger("NextWave");
    }

    public void StartNextWave()
    {
        currentWaveIndex++;
        canSpawnEnemy = true;
        nextSpawnTime = Time.time + secondsBetweenWaves;
        HUD.SetWave(currentWaveIndex);
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
                canAnimate = true;
            }
        }
    }
}
