using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private ScoreSystem scoreSystem;


    private void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
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
            scoreSystem.AddToScore();
            Destroy(gameObject);
        }
    }




}
