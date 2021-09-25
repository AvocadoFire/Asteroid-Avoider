using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [Range(0, 2)] [SerializeField] int defaultDifficulty = 1;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    const string DifficultyKey = "difficulty";
    const string DefaultDifficulty = "default difficulty";
    const string DefaultVolume = "default volume";

    private void Awake()
    {
        PlayerPrefs.SetInt(DefaultDifficulty, defaultDifficulty);
    }

    private void Start()
    {
        difficultySlider.wholeNumbers = true;
        difficultySlider.value = PlayerPrefsController.GetMasterDifficulty();
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
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
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterDifficulty((int)difficultySlider.value);
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        SceneManager.LoadScene(0);
    }

    public void SetDefaults()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(DefaultVolume);
        difficultySlider.value = PlayerPrefs.GetInt(DefaultDifficulty);
    }

}
