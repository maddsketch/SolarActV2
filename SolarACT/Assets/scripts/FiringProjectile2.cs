using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringProjectile2 : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign your projectile prefab
    public Transform firePoint; // Set the firing position
    public float projectileSpeed = 20f; // Adjust speed
    public float fireOffsetDistance = 2f; // Distance in front of firePoint


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Pressed Firing!");
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        Vector3 spawnPosition = firePoint.position + firePoint.forward * fireOffsetDistance;
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = firePoint.forward * projectileSpeed; // Propel forward
            Debug.Log("Firing!");
        }
    }
}
