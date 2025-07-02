using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControlr3 : MonoBehaviour
{
    public float thrustPower = 10f;
    public float rotationPower = 2f;
    private Rigidbody rb;
    public float rotationSpeed = 1.0f; // Adjust the speed of correction
    
    private float maxSpeed = 0f; // Set your speed limit
    
    public float bankAngle = 15f; // Max Z tilt when turning
    public float bankSmoothing = 3f; // How fast to smooth to bank target
    private float currentZTilt = 0f;

    //private readonly float[] thrustSteps = { 0f, 5f, 10f, 15f, 20f }; // Define 4 increments
    public float[] thrustSteps = { 0f, 5f, 10f, 15f, 20f }; // Define 4 increments
    private int thrustStepSet = 0;

    private bool wPreviouslyPressed = false;
    private bool sPreviouslyPressed = false;
    private bool onAcceleration1 = false;
    private bool shiftUp = false;
    private int stepDirection = 0;
    private float setSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // No gravity in space
        rb.drag = 0; // No air resistance
        rb.angularDrag = 0; // No rotational resistance




    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.W)) // Accelerate forward
        //{
        //    rb.AddForce(transform.forward * thrustPower, ForceMode.Acceleration);
        //}

        //if (Input.GetKeyDown(KeyCode.S)) // Accelerate forward
        //{
        //    rb.AddForce(-transform.forward * thrustPower, ForceMode.Acceleration);

        //}

        bool wCurrentlyPressed = Input.GetKey(KeyCode.W);
        bool sCurrentlyPressed = Input.GetKey(KeyCode.S);


        if (wCurrentlyPressed && !wPreviouslyPressed) // Accelerate forward
        {
            if (stepDirection >= 4) stepDirection = 4;
            else stepDirection++;

            Debug.Log("The setting is: " + stepDirection);
        }

        wPreviouslyPressed = wCurrentlyPressed;

        if (sCurrentlyPressed && !sPreviouslyPressed)
        {
            if (stepDirection <= -4) stepDirection = -4;
            else stepDirection--;

            Debug.Log("The setting is: " + stepDirection);

            //if (thrustStepSet <= 0) thrustStepSet = 0;
            //onAcceleration1 = false;
            //Debug.Log("Pressed reverse. Now step: " + thrustStepSet);
            //shiftUp = false;
        }

        sPreviouslyPressed = sCurrentlyPressed;

        if (Input.GetKey(KeyCode.A)) // Rotate left
        {
            rb.AddTorque(Vector3.up * -rotationPower, ForceMode.Acceleration);
        }
        else if (Input.GetKey(KeyCode.D)) // Rotate right
        {
            rb.AddTorque(Vector3.up * rotationPower, ForceMode.Acceleration);
        }
        else
        {
            // Stop rotation when no key is pressed
            rb.angularVelocity = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.E))
        {
            HaltStop1();
            thrustStepSet = 0;
            setSpeed = 0;
            stepDirection = 0;
        }

        // Get the current rotation
        Quaternion currentRotation = transform.rotation;

        if (stepDirection <= 4 && stepDirection > 0)
        {
            setSpeed = thrustSteps[stepDirection];
        }
        else if (stepDirection < 0 && stepDirection >= -4)
        {
            thrustStepSet = -1 * stepDirection;

            setSpeed = -1 * thrustSteps[thrustStepSet];
        }
        else if (stepDirection == 0)
        {
            HaltStop1();
            setSpeed = 0;
        }

        if (setSpeed > 0)
        {
            rb.AddForce(transform.forward * thrustPower, ForceMode.Acceleration);
            maxSpeed = setSpeed;
        }
        else if (setSpeed < 0)
        {
            rb.AddForce(-transform.forward * thrustPower, ForceMode.Acceleration);
            maxSpeed = -1 * setSpeed;
        }
        else
        {
            HaltStop1();
            setSpeed = 0;
            maxSpeed = 0;
        }


        //Set max speed
        //maxSpeed = thrustSteps[thrustStepSet];
        //maxSpeed = setSpeed;


        //// Limit speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        //Debug.Log("Current speed " + maxSpeed.ToString());

        float speed = rb.velocity.magnitude; // Get speed in units per second

        // Only bank while advancing forward and rotating
        bool isTurning = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        bool isAdvancing = Vector3.Dot(rb.velocity, transform.forward) > 0.1f;

        float targetZ = 0f;
        if (isAdvancing && isTurning)
        {
            if (Input.GetKey(KeyCode.A))
                targetZ = bankAngle;
            else if (Input.GetKey(KeyCode.D))
                targetZ = -bankAngle;
        }

        // Smoothly interpolate the tilt
        currentZTilt = Mathf.Lerp(currentZTilt, targetZ, Time.deltaTime * bankSmoothing);

        // Apply tilt without affecting Y rotation
        Quaternion targetRotation = Quaternion.Euler(0, transform.eulerAngles.y, currentZTilt);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


        if (speed >= maxSpeed)
        {
            //Debug.Log("Maximum speed reached. Activating Speed Control!");
        }
    }
    void HaltStop1()
    {
        rb.velocity = Vector3.zero; // Stop movement
        rb.angularVelocity = Vector3.zero; // Stop rotation
        maxSpeed = 0f;
    }
}
