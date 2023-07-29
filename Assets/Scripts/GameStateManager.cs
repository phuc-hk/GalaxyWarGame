using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour
{

    [SerializeField] private int waveCount = 3;
    private int currentWave = 0;
    private int currentEnemyCount;
    private int currentBossCount = 0;
    private int maxEnemies = 3;
    private int startDelay = 1;
    private int powerupItemDelay = 5;

    EnemySpawner enemySpawner;
    PowerupItemSpawner powerupItemSpawner;

    public UnityEvent OnWin;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        powerupItemSpawner = FindObjectOfType<PowerupItemSpawner>();
    }

    private void Start()
    {
        SpawnEnemyWave();
        SpawnPowerupItem();
    }

    public void CheckEnemyNumber()
    {
        currentEnemyCount--;
        if (currentEnemyCount == 0)
        {
            if (currentWave < waveCount)
            {
                maxEnemies++;
                SpawnEnemyWave();
                SpawnPowerupItem();
            }
            else if (currentWave == waveCount)
            {
                if (currentBossCount == 0)
                {
                    SpawnEnemyBoss();
                }
                else
                    OnWin?.Invoke();
            } 
        }
    }

    private void SpawnPowerupItem()
    {
        StartCoroutine(powerupItemSpawner.SpawnItemWithDelay(powerupItemDelay));
    }

    private void SpawnEnemyWave()
    {
        StartCoroutine(enemySpawner.SpawnWaveWithDelay(startDelay, maxEnemies));
        currentEnemyCount = maxEnemies;
        currentWave++;
    }

    private void SpawnEnemyBoss()
    {
        StartCoroutine(enemySpawner.SpawnBossWithDelay(2f));
        currentEnemyCount++;
        currentBossCount++;
    }
}

