using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText = null;
    [SerializeField] float scoreMultiplier = 5;
    float score = 0;

    private void Update()
    {
        int scoreInt = (int)score;
        scoreText.text = scoreInt.ToString();
    }

    public void AddToScore()
    {
        score += scoreMultiplier;
    }

    public int Score()
    {
        return (int)score;
    }

}
