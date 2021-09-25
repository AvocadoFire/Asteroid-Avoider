using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] private Text highScoreText;
    [SerializeField] private ScoreSystem scoreSystem;
    const string MasterDifficultyKey = "difficulty";

    public static readonly string[] HighScoreName = { "Casual", "Normal", "Hard"};
    int[] highScores = { 0,0,0 };
    int difficultyInt;
    string highScoreName;
    int highScoreNumber;

    private void Start()
    {
       difficultyInt = PlayerPrefs.GetInt(MasterDifficultyKey);

       highScoreName =  HighScoreName[difficultyInt];
       highScoreNumber = highScores[difficultyInt];

       highScoreText.text = highScoreName + "   high   score   is   " + PlayerPrefs.GetInt(highScoreName, 0); 
    }
    public int CalculateHighScore()
    {
        var score = scoreSystem.Score();
        int currentHighScore = PlayerPrefs.GetInt(highScoreName, 0);
        if (score > currentHighScore)
        {
            var scoreInt = (int)score;
            PlayerPrefs.SetInt(highScoreName, scoreInt);
        }
        return PlayerPrefs.GetInt(highScoreName, 0);
    }


}
