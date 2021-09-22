using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] TMP_Text scoreText = null;
    [SerializeField] float scoreMultiplier = 5;
    float score = 0;

    private void Update()
    {
        if (playerHealth.isActiveAndEnabled == true)
        {
            score += Time.deltaTime * scoreMultiplier;
            int scoreInt = (int)score;
            scoreText.text = scoreInt.ToString();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public int Score()
    {
        return (int)score;
    }
}
