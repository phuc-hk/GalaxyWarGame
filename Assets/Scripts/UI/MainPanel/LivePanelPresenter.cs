using SVS.HealthSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivePanelPresenter : MonoBehaviour
{
    Health playerHealth;

    private Transform liveImages;

    private List<Image> liveImageList = new List<Image>();

    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

        liveImages = transform.Find("LiveImages");

        foreach (Transform liveImage in liveImages)
        {
            liveImageList.Add(liveImage.GetComponent<Image>());
        }
    }

    private void OnEnable()
    {
        playerHealth.OnDeath.AddListener(UpdateUI);
        playerHealth.OnHit.AddListener(UpdateUI);
    }

    private void OnDisable()
    {
        playerHealth.OnDeath.RemoveListener(UpdateUI);
        playerHealth.OnHit.RemoveListener(UpdateUI);
    }

    private void UpdateUI()
    {
        for (int i = 0; i < liveImageList.Count; i++)
        {
            if (i >= playerHealth.CurrentHealth)
            {
                liveImageList[i].color = Color.black;
            }
            else
            {
                liveImageList[i].color = Color.white;
            }
        }
    }
}
