using SVS.WeaponSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerupTimer : MonoBehaviour
{
    [SerializeField] private float maxTimer;

    private float currentTimer;

    public Action OnTimerChange;

    public UnityEvent<AttackPatternSO> OnBulletPowerUp;

    Player player;

    Weapon weapon;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        weapon = player.GetComponentInChildren<Weapon>();
        StopTimer();
    }
    private void Start()
    {
        currentTimer = maxTimer;
    }

    private void Update()
    {
        currentTimer -= Time.deltaTime;
        OnTimerChange?.Invoke(); 
    }

    public void ActivePowerupShield()
    {
        player.ActiveShield();
        StartCoroutine(DelayShieldTimer());
    }

    public void ActivePowerupBullet(AttackPatternSO attackPattern)
    {
        weapon.ChangeWeapon(attackPattern);
        OnBulletPowerUp?.Invoke(attackPattern);
        StartCoroutine(DelayBulletTimer());
    }

    public float TimerNormalize()
    {
        return currentTimer / maxTimer;
    }

    private IEnumerator DelayShieldTimer()
    {
        yield return new WaitForSeconds(maxTimer);
        player.DeactiveShield();
        StopTimer();
    }

    private IEnumerator DelayBulletTimer()
    {
        yield return new WaitForSeconds(maxTimer);
        weapon.ChangeDefaultWeapon();
        StopTimer();
    }

    public void StartTimer()
    {
        gameObject.SetActive(true);
        currentTimer = maxTimer;
    }

    public void StopTimer()
    {
        gameObject.SetActive(false);
    }
}
