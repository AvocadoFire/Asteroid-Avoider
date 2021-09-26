using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] int worth = 1;
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth == null) { return; }

        playerHealth.Crash();
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public int Worth()
    {
        return worth;
    }
}
