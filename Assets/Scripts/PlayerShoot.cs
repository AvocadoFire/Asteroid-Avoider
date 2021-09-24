using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun1, gun2;
    [SerializeField] float speed = 5, projectileTimer = .05f;
    float timer;
    Rigidbody rbPlayer;

    private void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    public void Fire()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && rbPlayer.velocity != new Vector3 (0f,0f,0f))
        {
            GameObject newProjectile1 = Instantiate
                (projectile, gun1.transform.position, transform.rotation);
            Rigidbody rbProjectile = newProjectile1.GetComponent<Rigidbody>();
            rbProjectile.velocity = rbPlayer.velocity * speed;

            GameObject newProjectile2 = Instantiate
                (projectile, gun2.transform.position, transform.rotation);
            Rigidbody rbProjectile2 = newProjectile2.GetComponent<Rigidbody>();
            rbProjectile2.velocity = rbPlayer.velocity.normalized * speed;
            timer += projectileTimer;
        }
    }
}
