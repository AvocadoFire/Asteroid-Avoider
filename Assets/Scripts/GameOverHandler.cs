using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private HighScore highScore;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private PlayerHealth player;

    private void Awake()
    {
        gameOverDisplay.SetActive(false);
    }
    public void EndGame()
    {
        //asteroidSpawner.enabled = false;
        highScore.gameObject.SetActive(false);
        scoreSystem.gameObject.SetActive(false);
        int score = scoreSystem.Score();
        highScore.CalculateHighScore();
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        gameOverText.text = ("GaME oVeR!\nyour score:  " + score + "\n high score: " + currentHighScore);
        gameOverDisplay.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
        gameObject.SetActive(true);
    }

    public void ContinueButton()
    {
        AdManager.Instance.ShowAd(this);
        continueButton.interactable = false;
    }

    public void ContinueGame()
    {
        player.transform.position = Vector3.zero;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.gameObject.SetActive(true);
        gameOverDisplay.gameObject.SetActive(false);
        scoreSystem.gameObject.SetActive(true);
        highScore.gameObject.SetActive(true);
      //  asteroidSpawner.enabled = true;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
