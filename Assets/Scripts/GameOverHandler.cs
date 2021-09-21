using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;

    private void Awake()
    {
        gameOverDisplay.SetActive(false);
    }
    public void EndGame()
    {
        asteroidSpawner.enabled = false;
        int score = scoreSystem.Score();

        gameOverText.text = ("GaME oVeR!\n" + "sCoRe: " + score);
        gameOverDisplay.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
        gameObject.SetActive(false);
    } 

    public void Continue()
    {
        return;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
