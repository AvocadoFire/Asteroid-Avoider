using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [Range(0, 1)] [SerializeField] float defaultVolume = 0.08f;
    const string DefaultVolume = "default volume";
    const string MasterVolumeKey = "master volume";
    AudioSource audioSource;
    float volume;
    public static MusicPlayer Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        PlayerPrefs.SetFloat(DefaultVolume, defaultVolume);

    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volume = PlayerPrefs.GetFloat(MasterVolumeKey, PlayerPrefs.GetFloat(DefaultVolume));
        audioSource.volume = volume;
    }

    public void SetVolume(float volume) //something else can change volume
    {
        audioSource.volume = volume;
    }
}
