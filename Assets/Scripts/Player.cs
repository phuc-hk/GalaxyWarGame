using SVS.HealthSystem;
using SVS.WeaponSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isAlive;
    
    private float speed = 10;
    private Vector2 movementVector = Vector2.zero;

    private ScreenBounds screenBounds;
    private Weapon weapon;
    private Health health;
    private Rigidbody2D playerRb;
    private Transform shield;

    private void Awake()
    {
        screenBounds = FindObjectOfType<ScreenBounds>();
        weapon = transform.Find("Weapon").GetComponent<Weapon>();
        health = GetComponent<Health>();
        playerRb = GetComponent<Rigidbody2D>();
        shield = transform.Find("Shield");
        shield.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        health.OnDeath.AddListener(Death);
    }

    private void OnDisable()
    {
        health.OnDeath.RemoveListener(Death);
    }

    void Update()
    {
        HandleMoving();
        HandleShooting();
    }

    private void HandleMoving()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input.Normalize();
        movementVector = speed * input;
        Vector2 newPosition = playerRb.position + movementVector * Time.deltaTime;
        if (screenBounds.AmIOutOfBounds(newPosition) == false)
        {
            playerRb.MovePosition(newPosition);
        }
    }

    private void HandleShooting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            weapon.PerformAttack();
        }
    }

    private void Death()
    {
        isAlive = false;
        Destroy(gameObject);
    }

    public void ReduceLives()
    {
        health.GetHit(1);
    }

    public void ActiveShield()
    {
        shield.gameObject.SetActive(true);
    }

    public void DeactiveShield()
    {
        shield.gameObject.SetActive(false);
    }
}
