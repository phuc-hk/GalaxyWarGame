using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public TMP_Text scoreText;
    public int currentScore;

    public static ScoreSystem Instance { get; private set; }
    public Action OnScoreChange;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }             
        currentScore = 0;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        //scoreText.text = currentScore + "";
    }
    public void SetScore(int score)
    {
        currentScore += score;
        OnScoreChange?.Invoke();
    }

    public int GetScore()
    {
        return currentScore;
    }
}
