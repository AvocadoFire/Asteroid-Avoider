using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //public void MoveProjectile(Vector3 speedVector)
    //{
    //    transform.Translate(speedVector * Time.deltaTime, Space.Self);
    //}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
