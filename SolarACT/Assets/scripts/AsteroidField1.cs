using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidField1 : MonoBehaviour
{
    public GameObject prefab; // Assign the prefab you want to instantiate
    public int objectCount = 50; // Number of objects to spawn
    public Vector3 areaSize = new Vector3(1000, 1000, 1000); // Define the area size
    public Vector3 fieldCenter = Vector3.zero;
    public float minScale = 0.5f;
    public float maxScale = 3f;
    public float minRotationSpeed = 10f;
    public float maxRotationSpeed = 100f;



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objectCount; i++)
        {
            SpawnRandomObject();
        }
    }

    void SpawnRandomObject()
    {
        // Generate random position within the defined area
        Vector3 randomPosition = fieldCenter + new Vector3(
            Random.Range(-areaSize.x / 2, areaSize.x / 2),
            Random.Range(-areaSize.y / 2, areaSize.y / 2),
            Random.Range(-areaSize.z / 2, areaSize.z / 2)
        );

        // Instantiate the object
        GameObject newObject = Instantiate(prefab, randomPosition, Random.rotation);

        // Randomize scale
        float randomScale = Random.Range(minScale, maxScale);
        newObject.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        // Assign random rotation speed
        float randomRotation = Random.Range(minRotationSpeed, maxRotationSpeed);
        newObject.AddComponent<RandomRotator>().rotationSpeed = randomRotation;
    }
}
// This script will rotate the object randomly
public class RandomRotator : MonoBehaviour
{
    public float rotationSpeed = 30f;

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}