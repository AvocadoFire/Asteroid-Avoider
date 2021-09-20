using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private float secBetweenAsteroids = 1.5f;
    [SerializeField] private Vector2 topForce = new Vector2 (2f,4f);
    [SerializeField] private Vector2 sideForce = new Vector2(4f, 7f);


    private Camera mainCamera;
    private float timer;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnAsteroid();
            timer += secBetweenAsteroids;
        }
    }

    private void SpawnAsteroid()
    {
        int side = UnityEngine.Random.Range(0, 4); //returns a random integer between 1-3

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;
        Vector2 force = Vector2.zero;

        switch (side)
        {
            case 0:
                //left
                spawnPoint.x = 0;
                spawnPoint.y = UnityEngine.Random.value;
                direction = new Vector2(1f, UnityEngine.Random.Range(-1, 1));
                force = sideForce;
                break;
            case 1:
                //right
                spawnPoint.x = 1;
                spawnPoint.y = UnityEngine.Random.value;
                direction = new Vector2(-1f, UnityEngine.Random.Range(-1, 1));
                force = sideForce;
                break;
            case 2:
                //bottom
                spawnPoint.x = UnityEngine.Random.value;
                spawnPoint.y = 0;
                direction = new Vector2(UnityEngine.Random.Range(-1, 1), 1f);
                force = topForce;
                break;
            case 3:
                //top
                spawnPoint.x = UnityEngine.Random.value;
                spawnPoint.y = 1;
                direction = new Vector2(UnityEngine.Random.Range(-1, 1), -1f);
                force = topForce;
                break;

                //in viewport space (0,1) and need to have it in world space.
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint); //gives Vector3 where to spawn
        worldSpawnPoint.z = 0;
        GameObject selectedAsteroid = asteroidPrefabs[UnityEngine.Random.Range(0, asteroidPrefabs.Length)];
        GameObject asteroidInstance = Instantiate(
            selectedAsteroid,
            worldSpawnPoint, 
            Quaternion.Euler(0f,0f,UnityEngine.Random.Range(0,360)));
        Rigidbody rb = asteroidInstance.GetComponent<Rigidbody>();
        rb.velocity = direction.normalized * UnityEngine.Random.Range(force.x, force.y);
        //normalizing to make sure the magnitude is 1

    }
}
