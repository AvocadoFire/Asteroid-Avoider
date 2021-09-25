
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject particles;
    [SerializeField] AudioClip deathClip;
    [SerializeField] GameOverHandler gameOverHandler;
    const string MasterSFKey = "master sf volume";
    const string DefaultSFVolume = "default sf volume";
    float volume;
    Camera mainCamera;

    public void Start()
    {
        mainCamera = Camera.main;
        volume = PlayerPrefs.GetFloat(MasterSFKey, PlayerPrefs.GetFloat(DefaultSFVolume));
    }

    public void Crash()
    {
        Instantiate(particles, gameObject.transform.position, gameObject.transform.rotation);
        AudioSource.PlayClipAtPoint(deathClip, mainCamera.transform.position, volume);
        gameObject.SetActive(false);
        //don't destroy because want the player to be able to respawn after watching ad

        Invoke("WaitEnd", 1f);
    }
    
    private void WaitEnd()
    {
        gameOverHandler.EndGame();
    }


}
