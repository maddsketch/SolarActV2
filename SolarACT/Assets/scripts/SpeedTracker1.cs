using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTracker1 : MonoBehaviour
{
    public Rigidbody rb;
    //public Text speedText; // Assign a UI Text element


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = rb.velocity.magnitude; // Get speed in units per second
        //speedText.text = "Speed: " + speed.ToString("F2") + " m/s"; // Display with 2 decimal places

        //Debug.Log("Current Speed: " + speed.ToString("F2") + " m/s");

    }
}
