using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] private Text highScoreText;
    [SerializeField] private ScoreSystem scoreSystem;

    public const string HighScoreKey = "HighScore";

    int highScore = 0;

    private void Start()
    {
       highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
       highScoreText.text = $"Your High Score: {highScore}";
    }
    public void CalculateHighScore()
    {
        var score = scoreSystem.Score();
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if (score > currentHighScore)
        {
            var scoreInt = (int)score;
            PlayerPrefs.SetInt(HighScoreKey, scoreInt);
        }
    }

}
