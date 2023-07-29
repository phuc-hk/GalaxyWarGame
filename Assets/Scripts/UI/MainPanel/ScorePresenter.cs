using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePresenter : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    //ScoreSystem scoreSystem;

    private void Awake()
    {
        scoreText =  transform.Find("scoreText").GetComponent<TextMeshProUGUI>();
        UpdateScoreText();
        //scoreSystem = FindObjectOfType<ScoreSystem>();
        ScoreSystem.Instance.OnScoreChange += UpdateScoreText;
    }

    public void UpdateScoreText()
    {
        scoreText.text = ScoreSystem.Instance.GetScore().ToString();
    }
}
