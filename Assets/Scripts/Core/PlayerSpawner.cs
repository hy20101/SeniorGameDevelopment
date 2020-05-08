using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPos;

    private void Start()
    {
        Instantiate(playerPrefab, spawnPos);
    }
}
