using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider otherCollider) //other thing's collider
    {
        //var health = otherCollider.GetComponent<Health>();
        //var attacker = otherCollider.GetComponent<Attacker>();

        if (otherCollider.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
            Destroy(otherCollider.gameObject);
        }

    }




}
