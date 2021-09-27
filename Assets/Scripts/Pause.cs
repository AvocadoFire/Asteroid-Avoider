using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] private GameObject pauseDisplay;

    bool isPaused = false;
    public void Paused()
    {
        if (isPaused == false)
        {
            pauseDisplay.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
            pauseButton.gameObject.SetActive(false);
            return;
        }
        else { return; }
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseDisplay.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }
}
