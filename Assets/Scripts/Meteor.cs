using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour, IHittable
{
    Rigidbody2D rb2d;

    private float speed = 1;

    [SerializeField]
    private Transform meteorSprite;

    [SerializeField]
    private float rotationSpeed = 15;

    private Vector2 direction = Vector2.down;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        meteorSprite.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHittable hittable = collision.GetComponent<IHittable>();
        if (hittable != null)
        {
            hittable.GetHit(1);
            GetHit(1);
        }
    }

    public void GetHit(int damageValue)
    {
        Vector2 newDirection = transform.position;
        direction = newDirection.normalized;
    }
}

