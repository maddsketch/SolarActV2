using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision1 : MonoBehaviour
{
    public GameObject explosionEffect; // Assign an explosion prefab in Unity


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collision");

        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        
        // Destroy the object it collides with
        Destroy(collision.gameObject);

        // Destroy the bullet itself
        Destroy(gameObject);

        
    }

    private void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("Asteroid1"))
        {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
            Debug.Log("Bullet collision");
        }
    }

}



/*

 */