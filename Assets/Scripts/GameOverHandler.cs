using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;

    private void Awake()
    {
        gameOverDisplay.SetActive(false);
    }
    public void EndGame()
    {
        asteroidSpawner.enabled = false;
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
