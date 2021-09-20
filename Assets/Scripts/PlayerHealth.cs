
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject particles;
    [SerializeField] AudioClip deathClip;

    public void Crash()
    {
        Instantiate(particles, gameObject.transform.position, gameObject.transform.rotation);
        AudioSource.PlayClipAtPoint(deathClip, transform.position);
        gameObject.SetActive(false); 
        //don't destroy because want the player to be able to respawn after watching ad
    }
}
