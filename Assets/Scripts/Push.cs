using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public Rigidbody rb;
    public float forceStrength;
    public Collider Target; // Assign your trigger zone here
    private bool isStopped;
    private float stopTime;
    public float stopDuration = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.left * forceStrength, ForceMode.Impulse);
        Debug.Log("Object has stopped for 5 seconds.");
    }

    void Update()
    {
        // Check if the object is within the trigger zone
        if (Target.bounds.Contains(transform.position))
        {
            // If it's in the zone, start or continue timing
            if (!isStopped)
            {
                isStopped = true;
                stopTime = Time.time;
            }
            else
            {
                // If it has been in the zone for the specified duration, trigger your event
                if (Time.time - stopTime >= stopDuration)
                {
                    // Add your event code here
                    Debug.Log("Object has stopped for 5 seconds.");
                }
            }
        }
        else
        {
            // If it's not in the zone, reset the timing
            isStopped = false;
        }
    }
}
