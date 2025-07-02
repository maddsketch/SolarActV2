using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAroundTarget2 : MonoBehaviour
{
    public Transform target;
    public float approachSpeed = 10f;
    public float orbitDistance = 10f;
    public float orbitSpeed = 30f;
    public float bankAngle = 30f;
    public float bankSmooth = 2f;
    public float fltDistance1 = 5f;

    private Vector3 lastPosition;
    private float currentBank = 0f;
    private bool isOrbiting = false;


    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (target == null) return;

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (!isOrbiting)
        {
            // Move toward the target
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * approachSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);

            // Start orbiting when close enough
            if (distanceToTarget <= orbitDistance)
            {
                isOrbiting = true;

                // Snap to orbit ring
                Vector3 offset = (transform.position - target.position).normalized * orbitDistance;
                transform.position = target.position + offset;
                lastPosition = transform.position;
                //AvoidOtherEnemies();
            }
            
        }
        else
        {
            // Orbiting behavior
            transform.RotateAround(target.position, Vector3.up, orbitSpeed * Time.deltaTime);

            Vector3 direction = (transform.position - lastPosition).normalized;
            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);

                Vector3 turnVector = Vector3.Cross(lastPosition - target.position, direction);
                float turnSign = Mathf.Sign(turnVector.y);
                float targetBank = -turnSign * bankAngle;

                currentBank = Mathf.Lerp(currentBank, targetBank, Time.deltaTime * bankSmooth);
                Quaternion bankRotation = Quaternion.AngleAxis(currentBank, Vector3.forward);

                transform.rotation = lookRotation * bankRotation;
            }
            //AvoidOtherEnemies();

            lastPosition = transform.position;
            
        }
        
    }

    void AvoidOtherEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy1");
        Vector3 avoidance = Vector3.zero;
        int count = 0;

        foreach (GameObject other in enemies)
        {
            if (other == gameObject) continue;

            float distance = Vector3.Distance(transform.position, other.transform.position);
            //if (distance < 5f) // Adjust this threshold
            if (distance < fltDistance1)
            {
                Vector3 away = (transform.position - other.transform.position).normalized;
                avoidance += away / distance; // Stronger repulsion when closer
                count++;
            }
        }

        if (count > 0)
        {
            avoidance /= count;
            transform.position += avoidance * Time.deltaTime * 5f; // Adjust strength
        }
    }



}

/*
 public class FlyAroundTarget1 : MonoBehaviour
{
    public Transform target;
    public float approachSpeed = 10f;
    public float orbitDistance = 10f;
    public float orbitSpeed = 30f;
    public float bankAngle = 30f;
    public float bankSmooth = 2f;

    private Vector3 lastPosition;
    private float currentBank = 0f;
    private bool isOrbiting = false;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        if (target == null) return;

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (!isOrbiting)
        {
            // Move toward the target
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * approachSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);

            // Start orbiting when close enough
            if (distanceToTarget <= orbitDistance)
            {
                isOrbiting = true;

                // Snap to orbit ring
                Vector3 offset = (transform.position - target.position).normalized * orbitDistance;
                transform.position = target.position + offset;
                lastPosition = transform.position;
            }
        }
        else
        {
            // Orbiting behavior
            transform.RotateAround(target.position, Vector3.up, orbitSpeed * Time.deltaTime);

            Vector3 direction = (transform.position - lastPosition).normalized;
            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);

                Vector3 turnVector = Vector3.Cross(lastPosition - target.position, direction);
                float turnSign = Mathf.Sign(turnVector.y);
                float targetBank = -turnSign * bankAngle;

                currentBank = Mathf.Lerp(currentBank, targetBank, Time.deltaTime * bankSmooth);
                Quaternion bankRotation = Quaternion.AngleAxis(currentBank, Vector3.forward);

                transform.rotation = lookRotation * bankRotation;
            }

            lastPosition = transform.position;
        }
    }
}

 
 */

