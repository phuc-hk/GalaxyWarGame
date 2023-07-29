using SVS.HealthSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private GameStateManager gameStateManager;
    private Health enemyHealth;

    private void Awake()
    {
        enemyHealth = GetComponent<Health>();
        enemyHealth.OnDeath.AddListener(Death);
        gameStateManager = FindObjectOfType<GameStateManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
           enemyHealth.GetHit(1);
        }
    }

    public void EnemyKilledOutsideBounds()
    {
        gameStateManager.CheckEnemyNumber();
        Destroy(gameObject);
    }

    private void Death()
    {
        ScoreSystem.Instance.SetScore(100);
        gameStateManager.CheckEnemyNumber();
        Destroy(gameObject);
    }

}
