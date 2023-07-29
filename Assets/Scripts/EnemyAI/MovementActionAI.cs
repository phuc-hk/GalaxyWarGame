using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyAI
{
    public class MovementActionAI : MonoBehaviour
    {
        [SerializeField]
        private float speed = 2;
        private float speedVariation = 0.3f;
        private Rigidbody2D enemyRb;

        private void Awake()
        {
            enemyRb = GetComponent<Rigidbody2D>();
            speed += UnityEngine.Random.Range(0, speedVariation);
        }
        private void FixedUpdate()
        {
            enemyRb.MovePosition(enemyRb.position + Vector2.down * speed * Time.deltaTime);
        }
    }
}