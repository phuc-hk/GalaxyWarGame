using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Enemy> enemyList;
    public Enemy bossEnemy;

    private BoxCollider2D boxCollider;
 
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public IEnumerator SpawnWaveWithDelay(float startDelay, int maxEnemies)
    {
        yield return new WaitForSeconds(startDelay);
        float minX = boxCollider.bounds.min.x;
        float maxX = boxCollider.bounds.max.x;
        for (int i = 0; i < maxEnemies; i++)
        {
            Vector3 spawnPoint = new Vector3(UnityEngine.Random.Range(minX, maxX), transform.position.y, 0);
            GameObject newEnemy = Instantiate(enemyList[UnityEngine.Random.Range(0,enemyList.Count)].gameObject
                                             ,spawnPoint
                                             ,Quaternion.Euler(0, 0, -90));
        }
    }

    public IEnumerator SpawnBossWithDelay(float startDelay)
    {
        yield return new WaitForSeconds(startDelay);
        float minX = boxCollider.bounds.min.x;
        float maxX = boxCollider.bounds.max.x;
        float center = (minX + maxX) / 2;
        Vector3 spawnPoint = new Vector3(center, transform.position.y, 0);
        GameObject newEnemy = Instantiate(bossEnemy.gameObject, spawnPoint, Quaternion.Euler(0, 0, 0));
    }
}
