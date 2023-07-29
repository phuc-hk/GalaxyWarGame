using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SVS.HealthSystem
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float initialHealthValue = 3;
        public float CurrentHealth { get; private set; }

        public UnityEvent OnDeath, OnHit;

        private void Start()
        {
            CurrentHealth = initialHealthValue;
        }
        public void GetHit(int damageValue)
        {
            CurrentHealth -= damageValue;
            if (CurrentHealth <= 0)
            {
                OnDeath?.Invoke();
            }
            else
            {
                OnHit?.Invoke();
            }
        }

        public void InitializeHealth(int startingHealth)
        {
            if (startingHealth < 0)
            {
                startingHealth = 0;
            }  
            CurrentHealth = startingHealth;
        }

        public float CurrentHeathNormalize()
        {
            return CurrentHealth / initialHealthValue;
        }
    }
}