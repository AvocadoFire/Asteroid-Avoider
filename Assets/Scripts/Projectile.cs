using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] AudioClip asteroidSound;
    [SerializeField] GameObject asteroidParticle;
    private ScoreSystem scoreSystem;
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
            Instantiate(asteroidParticle, gameObject.transform.position, gameObject.transform.rotation);
            AudioSource.PlayClipAtPoint(asteroidSound, mainCamera.transform.position, volume);
            scoreSystem.AddToScore();
            Destroy(gameObject);
        }
    }




}
