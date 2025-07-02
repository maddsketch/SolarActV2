using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltRotateAdvance1 : MonoBehaviour
{
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


/*
using UnityEngine;

public class RotateWhileAdvancing : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // Apply forward motion
        Vector2 moveVector = transform.up * moveInput * moveSpeed;
        rb.velocity = moveVector;

        // Rotate only while moving forward
        if (moveInput > 0)
        {
            float zRotation = -turnInput * rotationSpeed * Time.fixedDeltaTime;
            rb.MoveRotation(rb.rotation + zRotation);
        }
    }
}

 */
