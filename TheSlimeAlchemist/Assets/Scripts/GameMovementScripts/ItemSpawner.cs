using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public float spawnInterval = 3f;

    void Start()
    {
        // Start spawning items repeatedly
        InvokeRepeating("SpawnItem", 0f, spawnInterval);
    }

    void SpawnItem()
    {
        // Instantiate the itemPrefab at the spawner's position
        Instantiate(itemPrefab, transform.position, Quaternion.identity);
    }
}
