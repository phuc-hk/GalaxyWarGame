using SVS.WeaponSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupTimerPresenter : MonoBehaviour
{
    Image timerImage;
    Image powerupImage;
    PowerupTimer powerupTimer;
    private void Awake()
    {   
        powerupImage = transform.Find("PowerupImage").GetComponent<Image>();
        timerImage = transform.Find("TimerImage").GetComponent<Image>();

        powerupTimer = FindObjectOfType<PowerupTimer>(true);
        powerupTimer.OnTimerChange += ShowTimer;
        powerupTimer.OnTimerChange += UpdateTimerImage;
        powerupTimer.OnBulletPowerUp.AddListener(ChangeImage);

        HideTimerPresenter();
    }

    private void ChangeImage(AttackPatternSO attackPattern)
    {
        powerupImage.sprite = attackPattern.image;
    }

    private void UpdateTimerImage()
    {
        timerImage.fillAmount = powerupTimer.TimerNormalize();
        if (timerImage.fillAmount == 0)
            HideTimerPresenter();
    }

    void ShowTimer()
    {
        gameObject.SetActive(true);
    }

    void HideTimerPresenter()
    {
        gameObject.SetActive(false);
    }
}
