using SVS.HealthSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathIndicator : MonoBehaviour
{
    //Transform heathBar;
    public Image foreground;
    Health heath;

    private void Awake()
    {
        //heathBar = transform.Find("Bar");
        heath = GetComponentInParent<Health>();
        
        heath.OnHit.AddListener(Show);
        heath.OnHit.AddListener(DisplayHeath);

        Hide();
    }

    private void DisplayHeath()
    {
        //heathBar.localScale = new Vector3(heath.CurrentHeathNormalize(), 1, 1);
        foreground.fillAmount = heath.CurrentHeathNormalize();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
