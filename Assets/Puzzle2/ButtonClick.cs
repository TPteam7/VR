using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Rigidbody rb; // Reference to the Rigidbody of the ball
    public Slider slider;
    public Button button;

    public Vector3 initialPosition;

    public void SetTypeFromIndex()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.left * slider.value, ForceMode.Impulse);
        initialPosition = rb.position;
        button.interactable = false;
    }

    public Collider Target; // Assign your trigger zone here
    private bool isStopped;
    private float stopTime;
    private bool isFirstRun;
    private float initialTime;
    public float stopDuration = 5.0f;

    void Update()
    {
        //Get initial time
        if (isFirstRun)
        {
            isFirstRun = false;
            initialTime = Time.time;
        }

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
            // If been running for 15 seconds then go back to initial position
            if (Time.time - initialTime >= 15.0f)
            {
                isFirstRun = true;
                rb.velocity = Vector3.zero;
                rb.position = initialPosition;
                button.interactable = true;
                Debug.Log("Reset position of snowball");
            }
        }
    }
}
