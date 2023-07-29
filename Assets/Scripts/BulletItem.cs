using SVS.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : MonoBehaviour
{
    [SerializeField] private AttackPatternSO attackPattern;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        PowerupTimer powerupTimer = FindObjectOfType<PowerupTimer>(true);
        if (player != null)
        {
            powerupTimer.StartTimer();
            powerupTimer.ActivePowerupBullet(attackPattern);
            Destroy(gameObject);
        }
    }
}
