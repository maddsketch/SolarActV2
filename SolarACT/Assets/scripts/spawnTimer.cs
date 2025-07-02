using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class SpawnPoint
    {
        public Transform spawnLocation; // Reference to the child GameObject
        public float initialSpawnTime; // Initial time before the first spawn
        public GameObject objectToSpawn; // Specific object to spawn at this point
        public int repeatCount = 1; // Number of times to repeat the spawn (1 means no repetition)
        public float timeBetweenSpawns = 1f; // Time delay between each spawn in a repeat cycle
    }

    public List<SpawnPoint> spawnPoints;

    private void Start()
    {
        foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            StartCoroutine(SpawnObjectRepeatedly(spawnPoint));
        }
    }

    private IEnumerator SpawnObjectRepeatedly(SpawnPoint spawnPoint)
    {
        // Wait for the initial spawn time
        yield return new WaitForSeconds(spawnPoint.initialSpawnTime);

        for (int i = 0; i < spawnPoint.repeatCount; i++)
        {
            Instantiate(spawnPoint.objectToSpawn, spawnPoint.spawnLocation.position, Quaternion.identity);

            // If not the last iteration, wait for the time between spawns
            if (i < spawnPoint.repeatCount - 1)
            {
                yield return new WaitForSeconds(spawnPoint.timeBetweenSpawns);
            }
        }
    }
}
