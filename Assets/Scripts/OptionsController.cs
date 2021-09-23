using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    //[SerializeField] Slider difficultySlider;
    [Range(0, 1)] [SerializeField] float defaultVolume = 0.08f;
    //[Range(0, 9)] [SerializeField] int defaultDifficulty = 5;

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume(); //what is the master volume
    //    difficultySlider.wholeNumbers = true;
    //    difficultySlider.value = PlayerPrefsController.GetMasterDifficulty();
    }

    private void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found.. remember to start from Splash screen");
        }
        //set difficulty here
        //var livesDisplay = FindObjectOfType<LivesDisplay>();
        //if (livesDisplay)
        //{
        //    livesDisplay.SetLives((int)difficultySlider.value);
        //}
    }

    public void SaveAndExit()
    {
        //PlayerPrefsController.SetMasterDifficulty((int)difficultySlider.value);
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        SceneManager.LoadScene(0);
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
       // difficultySlider.value = (float)defaultDifficulty;
    }

}
