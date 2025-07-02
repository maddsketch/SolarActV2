using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringProjectiles : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile prefab
    public Transform firePoint; // Where the projectile is fired from
    public float maxChargeTime = 3f; // Maximum charge duration
    public float baseForce = 10f; // Minimum projectile force
    public float maxForce = 30f; // Maximum projectile force
    

    private float chargeTime;
    private bool isCharging;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isCharging = true;
            chargeTime = 0f;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            chargeTime += Time.deltaTime; // Increase charge time
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            FireProjectile();
            isCharging = false;
        }
        
    }

    void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        float chargeRatio = Mathf.Clamp(chargeTime / maxChargeTime, 0f, 1f);
        float launchForce = Mathf.Lerp(baseForce, maxForce, chargeRatio); // Scale force based on charge time

        rb.AddForce(firePoint.forward * launchForce, ForceMode.Impulse);
    }
}


/*

public class ChargedProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile prefab
    public Transform firePoint; // Where the projectile is fired from
    public float maxChargeTime = 3f; // Maximum charge duration
    public float baseForce = 10f; // Minimum projectile force
    public float maxForce = 30f; // Maximum projectile force

    private float chargeTime;
    private bool isCharging;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isCharging = true;
            chargeTime = 0f;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            chargeTime += Time.deltaTime; // Increase charge time
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            FireProjectile();
            isCharging = false;
        }
    }

    void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        float chargeRatio = Mathf.Clamp(chargeTime / maxChargeTime, 0f, 1f);
        float launchForce = Mathf.Lerp(baseForce, maxForce, chargeRatio); // Scale force based on charge time

        rb.AddForce(firePoint.forward * launchForce, ForceMode.Impulse);
    }
}

 */