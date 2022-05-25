using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    float secondsBetweenSpawning = 0.1f;
    [SerializeField]
    float xMinRange = -25.0f;
    [SerializeField]
    float xMaxRange = 25.0f;
    [SerializeField]
    float yMinRange = 8.0f;
    [SerializeField]
    float yMaxRange = 25.0f;

    [SerializeField]
    GameObject[] spawnObjects;

    float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + secondsBetweenSpawning;
    }


    void Update()
    {
        if (Time.time >= nextSpawnTime && !GameManager.gm.gameOver)
        {
            SpawnSomething();

            nextSpawnTime = Time.time + secondsBetweenSpawning;
        }
    }

    void SpawnSomething()
    {
        Vector2 spawnPosition;

        spawnPosition.x = Random.Range(xMinRange, xMaxRange);
        spawnPosition.y = Random.Range(yMinRange, yMaxRange);

        spawnPosition += (Vector2)transform.position;

        int objectToSpawn = Random.Range(0, spawnObjects.Length);

        GameObject spawnedObject = Instantiate(spawnObjects[objectToSpawn], spawnPosition, transform.rotation) as GameObject;

        spawnedObject.transform.parent = gameObject.transform;
    }
}
