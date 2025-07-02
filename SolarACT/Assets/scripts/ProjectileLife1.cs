using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLife1 : MonoBehaviour
{
    public float maxDistance = 100f; // Maximum distance before destruction
    public float maxLifetime = 5f;   // Maximum time before destruction

    private Vector3 startPosition; // Store the starting position
    private float elapsedTime = 0f; // Track elapsed time

    // Update is called once per frame
    void Update()
    {
        // Update elapsed time
        elapsedTime += Time.deltaTime;

        startPosition = transform.position;

        //Debug.Log(elapsedTime);

        // Calculate distance traveled
        float traveledDistance = Vector3.Distance(startPosition, transform.position);

        // Destroy bullet if it exceeds time or distance limits
        if (elapsedTime >= maxLifetime || traveledDistance >= maxDistance)
        {
            Destroy(gameObject);
            Debug.Log("Bullet destroyed due to lifetime expiration.");
        }


    }
}
/*
 using UnityEngine;

public class BulletLifetime : MonoBehaviour
{
    public float maxDistance = 100f; // Maximum distance before destruction
    public float maxLifetime = 5f;   // Maximum time before destruction

    private Vector3 startPosition; // Store the starting position
    private float elapsedTime = 0f; // Track elapsed time

    void Start()
    {
        startPosition = transform.position; // Store initial position
    }

    void Update()
    {
        // Update elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate distance traveled
        float traveledDistance = Vector3.Distance(startPosition, transform.position);

        // Destroy bullet if it exceeds time or distance limits
        if (elapsedTime >= maxLifetime || traveledDistance >= maxDistance)
        {
            Destroy(gameObject);
            Debug.Log("Bullet destroyed due to lifetime expiration.");
        }
    }
}

 */