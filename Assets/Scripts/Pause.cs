using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Sprite buttonImageOriginal;
    [SerializeField] Sprite buttonImagePaused;
    [SerializeField] private GameObject pauseDisplay;

    Image buttonImage;
    
    Color buttonColor;
    bool isPaused = false;

    private void Start()
    {
       buttonImage = button.GetComponent<Image>();
    }

    public void Paused()
    {
        Debug.Log("entered paused");
        if (isPaused == false)
        {
            pauseDisplay.SetActive(true);
            //buttonImage.sprite = buttonImagePaused;
            Time.timeScale = 0;
            isPaused = true;
            return;
        }
        else { return; }
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseDisplay.SetActive(false);
        buttonImage.sprite = buttonImageOriginal;
    }
}
