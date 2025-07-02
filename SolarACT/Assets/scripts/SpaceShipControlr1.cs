using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpaceShipControlr1 : MonoBehaviour
{
    public float maxSpeed = 10f;       // Max movement speed
    public float acceleration = 3f;    // Acceleration when moving
    public float deceleration = 2f;    // Normal deceleration
    public float brakingFactor = 10f;   // Braking effect when switching directions
    public float rotationSpeed = 90f;  // Rotation speed

    private float currentSpeed = 0f;
    private int moveDirection = 0; // 1 = Forward, -1 = Reverse, 0 = Idle

    // Update is called once per frame
    void Update()
    {
        // Handle movement
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Pressed W and speed " + currentSpeed);
            if (moveDirection == -1)
            { // If reversing, slow down before moving forward
                //Debug.Log("Reverse direction " + currentSpeed);
                currentSpeed -= brakingFactor * Time.deltaTime;
                if (currentSpeed < 0) currentSpeed = 0; // Ensure it fully stops
            }

            else
            {
                currentSpeed += acceleration * Time.deltaTime;
                Debug.Log("else Accelarate " + currentSpeed);
            }

            moveDirection = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Pressed S and speed " + currentSpeed);
            if (moveDirection == 1) // If moving forward, slow down before reversing
                currentSpeed -= brakingFactor * Time.deltaTime;
                if (currentSpeed < 0) currentSpeed = 0;
            else
                currentSpeed += acceleration * Time.deltaTime;

            moveDirection = -1;
        }
        else
        {
            // Decelerate when no key is pressed
            currentSpeed -= deceleration * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, 0);
        }

        // Bank visually while turning — tilt on Z-axis based on rotationInput
        if (moveDirection == 1 && currentSpeed > 0.1f)
        {
            //float zTilt = -rotationInput * rotationSpeed * Time.deltaTime;
            //transform.Rotate(Vector3.forward * zTilt);
        }

        // Prevent instant switching by allowing speed to decrease first
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        // Apply movement in the correct direction
        transform.Translate(Vector3.forward * moveDirection * currentSpeed * Time.deltaTime);

        // Rotate left/right using A and D
        float rotationInput = 0f;
        if (Input.GetKey(KeyCode.A))
            rotationInput = -1f;
        else if (Input.GetKey(KeyCode.D))
            rotationInput = 1f;

        transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);
    }
}

/*
public class SpaceShipController : MonoBehaviour
{
    public float thrustPower = 10f;
    public float rotationPower = 2f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // No gravity in space
        rb.drag = 0; // No air resistance
        rb.angularDrag = 0; // No rotational resistance
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) // Accelerate forward
        {
            rb.AddForce(transform.forward * thrustPower, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.A)) // Rotate left
        {
            rb.AddTorque(Vector3.up * -rotationPower, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.D)) // Rotate right
        {
            rb.AddTorque(Vector3.up * rotationPower, ForceMode.Acceleration);
        }
    }
}
*/

/*
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float maxSpeed = 10f;       // Max movement speed
    public float acceleration = 3f;    // Acceleration when moving
    public float deceleration = 2f;    // Normal deceleration
    public float brakingFactor = 4f;   // Braking effect when switching directions
    public float rotationSpeed = 90f;  // Rotation speed

    private float currentSpeed = 0f;
    private int moveDirection = 0; // 1 = Forward, -1 = Reverse, 0 = Idle

    void Update()
    {
        // Handle movement
        if (Input.GetKey(KeyCode.W))
        {
            if (moveDirection == -1) // If reversing, slow down before moving forward
                currentSpeed -= brakingFactor * Time.deltaTime;
            else
                currentSpeed += acceleration * Time.deltaTime;

            moveDirection = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (moveDirection == 1) // If moving forward, slow down before reversing
                currentSpeed -= brakingFactor * Time.deltaTime;
            else
                currentSpeed += acceleration * Time.deltaTime;

            moveDirection = -1;
        }
        else
        {
            // Decelerate when no key is pressed
            currentSpeed -= deceleration * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, 0);
        }

        // Prevent instant switching by allowing speed to decrease first
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        // Apply movement in the correct direction
        transform.Translate(Vector3.forward * moveDirection * currentSpeed * Time.deltaTime);

        // Rotate left/right using A and D
        float rotationInput = 0f;
        if (Input.GetKey(KeyCode.A))
            rotationInput = -1f;
        else if (Input.GetKey(KeyCode.D))
            rotationInput = 1f;

        transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);
    }
}


*/

/*
using UnityEngine;

public class SmoothCharacterControl : MonoBehaviour
{
    public float maxSpeed = 6.0f;      // Maximum movement speed
    public float acceleration = 2.0f;  // Speed increase per second
    public float deceleration = 1.5f;  // Speed decrease per second
    public float rotationSpeed = 100.0f; // Rotation speed
    
    private float currentSpeed = 0f;

    void Update()
    {
        // Forward movement with gradual acceleration
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        }
        else
        {
            // Deceleration when key is released
            currentSpeed -= deceleration * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, 0); // Prevent negative speed
        }

        // Apply movement
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        // Rotate character left/right when pressing A or D
        float rotationInput = 0f;
        if (Input.GetKey(KeyCode.A))
            rotationInput = -1f;
        else if (Input.GetKey(KeyCode.D))
            rotationInput = 1f;

        transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);
    }
}

*/

/*
public class SpaceShipControlr1 : MonoBehaviour
{
    public float baseSpeed = 3.0f;
    public float maxSpeed = 6.0f;
    private float currentSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
         currentSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
                if (Input.GetKey(KeyCode.W) && currentSpeed < maxSpeed)
        {
            currentSpeed += 1 * Time.deltaTime; // Gradually increase speed
        }
        else if (!Input.GetKey(KeyCode.W) && currentSpeed > baseSpeed)
        {
            currentSpeed -= 1 * Time.deltaTime; // Gradually decrease speed
        }

        float translation = Input.GetAxis("Vertical") * currentSpeed;
        float strafe = Input.GetAxis("Horizontal") * currentSpeed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);
    }
}

*/