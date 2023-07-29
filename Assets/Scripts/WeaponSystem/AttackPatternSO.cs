using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SVS.WeaponSystem
{
    public abstract class AttackPatternSO : ScriptableObject
    {

        [SerializeField]
        protected GameObject projectile;

        public Sprite image;

        [SerializeField]
        protected float attackDelay = 0.2f;

        [SerializeField]
        protected AudioClip weaponSFX;

        public float AttackDelay => attackDelay;

        public AudioClip AudioSFX => weaponSFX;

        public abstract void Perform(Transform shootingStartPoint);
    }
}