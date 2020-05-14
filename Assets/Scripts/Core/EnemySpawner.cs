using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public int maxEnemies;
    public int currentEnemies;
    int randomSpawnPoint;
    int randomEnemies;

    SceneTransition sceneTransition;
    AnimatorControlTest animator;

    void Start()
    {
        currentEnemies = 0;
        InvokeRepeating("SpawnEnemies", 3f, 1f);
    }

    void SpawnEnemies()
    {
        if (currentEnemies < maxEnemies)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomEnemies = Random.Range(0, enemies.Length);
            GameObject enemy = Instantiate(enemies[randomEnemies], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
            currentEnemies++;
        }
    }
}
