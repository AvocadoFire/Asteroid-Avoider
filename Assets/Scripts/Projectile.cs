using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private ScoreSystem scoreSystem;
    [SerializeField] AudioClip asteroidSound;
    Camera mainCamera;
    const string MasterSFKey = "master sf volume";
    const string DefaultSFVolume = "default sf volume";
    float volume;


    private void Start()
    {
        mainCamera = Camera.main;
        scoreSystem = FindObjectOfType<ScoreSystem>();
        volume = PlayerPrefs.GetFloat(MasterSFKey, PlayerPrefs.GetFloat(DefaultSFVolume));
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider otherCollider) //other thing's collider
    {
        if(otherCollider.gameObject.CompareTag("Asteroid")) 
        {
            Destroy(otherCollider.gameObject);
            AudioSource.PlayClipAtPoint(asteroidSound, mainCamera.transform.position, volume);
            scoreSystem.AddToScore();
            Destroy(gameObject);
        }
    }




}
