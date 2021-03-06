using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private Pause pause;
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
        pause.gameObject.SetActive(false);
        highScore.gameObject.SetActive(false);
        scoreSystem.gameObject.SetActive(false);

        int score = scoreSystem.Score();
        var currentHighScore = highScore.CalculateHighScore();
        gameOverText.text = ("GaME oVeR!\nyour score:  " + score + "\n high score: " + currentHighScore);
        gameOverDisplay.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        gameObject.SetActive(true);
    }

    public void ContinueButton()
    {
        asteroidSpawner.enabled = false;
#if UNITY_ANDROID || UNITY_IOS
        AdManager.Instance.ShowAd(this);
#endif
        continueButton.interactable = false;
    }

    public void ContinueGame()
    {
        player.transform.position = Vector3.zero;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.gameObject.SetActive(true);
        gameOverDisplay.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
        scoreSystem.gameObject.SetActive(true);
        highScore.gameObject.SetActive(true);
        asteroidSpawner.enabled = true;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
