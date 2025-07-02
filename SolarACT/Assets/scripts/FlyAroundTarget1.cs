using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAroundTarget1 : MonoBehaviour
{
    public Transform target;       // The GameObject to orbit around

    public float speed = 20f;      // Speed of rotation
    public float orbitDistance = 10f;
    public Vector3 axis = Vector3.up; // Axis around which to rotate
    public float orbitSpeed = 30f;
    public float bankAngle = 30f;       // Max tilt angle
    public float bankSmooth = 2f;       // Smoothing factor


    private Vector3 lastPosition;
    private float currentBank = 0f;

    void Start()
    {
        if (target == null) return;

        // Initialize position at the correct orbit distance
        Vector3 offset = (transform.position - target.position).normalized * orbitDistance;
        transform.position = target.position + offset;
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        // Orbit movement
        transform.RotateAround(target.position, Vector3.up, orbitSpeed * Time.deltaTime);

        // Direction of movement
        Vector3 direction = (transform.position - lastPosition).normalized;





        if (direction != Vector3.zero)
        {
            // Look in direction of movement
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            // Determine turn direction
            Vector3 turnVector = Vector3.Cross(lastPosition - target.position, direction);
            float turnSign = Mathf.Sign(turnVector.y); // +1 = right turn, -1 = left turn

            // Compute target bank angle
            float targetBank = -turnSign * bankAngle;
            currentBank = Mathf.Lerp(currentBank, targetBank, Time.deltaTime * bankSmooth);

            // Combine look direction and bank rotation
            Quaternion bankRotation = Quaternion.AngleAxis(currentBank, Vector3.forward);
            transform.rotation = lookRotation * bankRotation;

        }

        lastPosition = transform.position;
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


/*
void Update()
{
    if (target == null) return;

    // Orbit around the target
    transform.RotateAround(target.position, axis, orbitSpeed * Time.deltaTime);

    // Direction of movement
    Vector3 direction = (transform.position - lastPosition).normalized;

    if (direction != Vector3.zero)
    {
        // Look in direction of movement
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // Determine turn direction
        Vector3 turnVector = Vector3.Cross(lastPosition - target.position, direction);
        float turnSign = Mathf.Sign(turnVector.y); // +1 = right turn, -1 = left turn

        // Compute target bank angle
        float targetBank = turnSign * bankAngle;
        currentBank = Mathf.Lerp(currentBank, targetBank, Time.deltaTime * bankSmooth);

        // Combine look direction and bank rotation
        Quaternion bankRotation = Quaternion.AngleAxis(currentBank, Vector3.forward);
        transform.rotation = lookRotation * bankRotation;
    }

    lastPosition = transform.position;
}

 
 
 
 */


//if (target == null) return;

//// Orbit around the target
//transform.RotateAround(target.position, Vector3.up, orbitSpeed * Time.deltaTime);

//// Calculate movement direction
//Vector3 direction = (transform.position - lastPosition).normalized;

//// Face the direction of movement
//if (direction != Vector3.zero)
//    transform.rotation = Quaternion.LookRotation(direction);

//lastPosition = transform.position;


//if (target != null)
//{
//    transform.RotateAround(target.position, axis, speed * Time.deltaTime);
//}


/*
 public class EnemyOrbit : MonoBehaviour
{
    public Transform target;
    public float orbitDistance = 10f;
    public float orbitSpeed = 30f;
    public float bankAngle = 30f;       // Max tilt angle
    public float bankSmooth = 2f;       // Smoothing factor

    private Vector3 lastPosition;
    private float currentBank = 0f;

    void Start()
    {
        if (target == null) return;

        Vector3 offset = (transform.position - target.position).normalized * orbitDistance;
        transform.position = target.position + offset;
        lastPosition = transform.position;
    }

    void Update()
    {
        if (target == null) return;

        // Orbit movement
        transform.RotateAround(target.position, Vector3.up, orbitSpeed * Time.deltaTime);

        // Direction of movement
        Vector3 direction = (transform.position - lastPosition).normalized;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);

            // Calculate banking using cross product to detect turn direction
            Vector3 turnDir = Vector3.Cross(direction, transform.up);
            float turnAmount = Vector3.Dot(turnDir, Vector3.up);

            // Smooth bank angle
            float targetBank = Mathf.Clamp(-turnAmount * bankAngle, -bankAngle, bankAngle);
            currentBank = Mathf.Lerp(currentBank, targetBank, Time.deltaTime * bankSmooth);

            // Apply bank rotation
            transform.Rotate(Vector3.forward, currentBank, Space.Self);
        }

        lastPosition = transform.position;
    }
}

 */