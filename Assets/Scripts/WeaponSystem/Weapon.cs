using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        public bool shootingDelayed;

        [SerializeField]
        private AttackPatternSO attackPattern;

        private AttackPatternSO defaultAttackPattern;

        [SerializeField]
        private Transform shootingStartPoint;

        public AudioSource gunAudio;

        [SerializeField]
        private AudioClip weaponSwap;


        private void Start()
        {
            if(shootingDelayed)
                StartCoroutine(DelayShooting());
            defaultAttackPattern = attackPattern;
        }

        public void ChangeWeapon(AttackPatternSO attackPattern)
        {
            this.attackPattern = attackPattern;
            gunAudio.PlayOneShot(weaponSwap);
        }

        public void ChangeDefaultWeapon()
        {
            this.attackPattern = defaultAttackPattern;
            gunAudio.PlayOneShot(weaponSwap);
        }

        public void PerformAttack()
        {
            if (shootingDelayed == false)
            {
                shootingDelayed = true;

                gunAudio.PlayOneShot(attackPattern.AudioSFX);

                attackPattern.Perform(shootingStartPoint);

                StartCoroutine(DelayShooting());
            }
        }

        private IEnumerator DelayShooting()
        {
            yield return new WaitForSeconds(attackPattern.AttackDelay);
            shootingDelayed = false;
        }
    }
}