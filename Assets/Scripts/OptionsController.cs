using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [Range(0, 2)] [SerializeField] int defaultDifficulty = 1;
    [Range(0, 1)] [SerializeField] float defaultSFVolume = 0.08f;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] Slider SFSlider;
    const string DefaultDifficulty = "default difficulty";
    const string DefaultVolume = "default volume";
    const string DefaultSFVolume = "default sf volume";

    private void Awake()
    {
        PlayerPrefs.SetInt(DefaultDifficulty, defaultDifficulty);
        PlayerPrefs.SetFloat(DefaultSFVolume, defaultSFVolume);
    }

    private void Start()
    {
        difficultySlider.wholeNumbers = true;
        difficultySlider.value = PlayerPrefsController.GetMasterDifficulty();
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        SFSlider.value = PlayerPrefsController.GetSFVolume();
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
        PlayerPrefsController.SetSFVolume(SFSlider.value);
        SceneManager.LoadScene(0);
    }

    public void SetDefaults()
    {
        SFSlider.value = PlayerPrefs.GetFloat(DefaultSFVolume);
        volumeSlider.value = PlayerPrefs.GetFloat(DefaultVolume);
        difficultySlider.value = PlayerPrefs.GetInt(DefaultDifficulty);
    }

}
