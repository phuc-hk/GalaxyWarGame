using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    TextMeshProUGUI finalScore;
    
    void Start()
    {
        finalScore = GetComponent<TextMeshProUGUI>();
        finalScore.text = ScoreSystem.Instance.GetScore().ToString();
    }
}
