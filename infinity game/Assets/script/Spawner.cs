using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstanclePrefabs;

    private float obstancleSpawnTimer = 1f;
    private float obstancleSpeed = 5f;

    private float TimeUntilObstancleSpawn;

    private void Update()
    {
        SpawnLoop();
    }

    private void SpawnLoop()
    {
        TimeUntilObstancleSpawn += Time.deltaTime;

        if (TimeUntilObstancleSpawn > obstancleSpawnTimer)
        {
            Spawn();
            TimeUntilObstancleSpawn = 0f;
        }

    }

    private void Spawn()
    {
        GameObject obstancleToSpawn = obstanclePrefabs[Random.Range(0, obstanclePrefabs.Length)];
        GameObject spawnedObstancle = Instantiate(obstancleToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D obstancleRB = spawnedObstancle.GetComponent<Rigidbody2D>();
        obstancleRB.velocity = Vector2.left * obstancleSpeed;
    }
}
