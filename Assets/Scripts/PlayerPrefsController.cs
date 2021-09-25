using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    //defining a key we can use over and over

    const string MasterSFKey = "master sf volume";
    const string DefaultSFVolume = "default sf volume";
    const string MasterVolumeKey = "master volume";
    const string DefaultVolume = "default volume";
    const string MasterDifficultyKey = "difficulty";
    const string DefaultDifficulty = "default difficulty";
    const float MinVolume = 0f;
    const float MaxVolume = 1f;
    const int MinDifficulty = 0;
    const int MaxDifficulty = 2;

    public static float GetSFVolume()
    {
        return PlayerPrefs.GetFloat(MasterSFKey, PlayerPrefs.GetFloat(DefaultSFVolume));
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MasterVolumeKey, PlayerPrefs.GetFloat(DefaultVolume));
    }
    public static int GetMasterDifficulty()
    {
        return PlayerPrefs.GetInt(MasterDifficultyKey, PlayerPrefs.GetInt(DefaultDifficulty));
    }

    public static void SetSFVolume(float volume)
    {
        if (volume >= MinVolume && volume <= MaxVolume)
        {
            PlayerPrefs.SetFloat(MasterSFKey, volume);
        }
        else
        {
            Debug.LogError("SF volume is out of range");
        }
    }
    public static void SetMasterVolume(float volume)
    {
        if (volume >= MinVolume && volume <= MaxVolume)
        {
            PlayerPrefs.SetFloat(MasterVolumeKey, volume);
        }
        else 
        {
            Debug.LogError("Master volume is out of range");
        }
    }
    public static void SetMasterDifficulty(int difficulty)
    {
        if (difficulty >= MinDifficulty && difficulty <= MaxDifficulty)
        {
            PlayerPrefs.SetInt(MasterDifficultyKey, difficulty);
        }
        else
        {
            Debug.LogError("DIFFICULTY is out of range");
        }
    }
}
