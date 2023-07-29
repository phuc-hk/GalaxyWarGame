using SVS.HealthSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 10;   
    private float deathDelay = 5;
    
    private Health health;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up * speed;
        StartCoroutine(DeathAfterDelay(deathDelay));
    }

    private IEnumerator DeathAfterDelay(float deathDelay)
    {
        yield return new WaitForSeconds(deathDelay);
        health.GetHit(1);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health collisonHeath = collision.GetComponent<Health>();
        if (collisonHeath != null)
        {
            collisonHeath.GetHit(1);
            health.GetHit(1);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
    }
}
