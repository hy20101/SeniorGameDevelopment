using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public int maxEnemies;
    public int currentEnemies;
    public int spawnTime = 5;

    int randomSpawnPoint;
    int randomEnemies;

    void Start()
    {
        currentEnemies = 0;
        InvokeRepeating("SpawnEnemies", spawnTime, 1f);
    }

    void SpawnEnemies()
    {
        if (currentEnemies < maxEnemies)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomEnemies = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomEnemies], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
            currentEnemies++;
        }
    }
}
