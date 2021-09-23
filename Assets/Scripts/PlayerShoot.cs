using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    
    private void Fire()
    {
        GameObject newProjectile = Instantiate
            (projectile, gun.transform.position, transform.rotation) as GameObject;
       // newProjectile.transform.parent = projectileParent.transform;
    }
}
