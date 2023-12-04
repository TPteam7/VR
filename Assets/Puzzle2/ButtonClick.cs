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

        assignMaterial();
    }

    public Material Vi1Material;
    public Material Vi2Material;
    public Material Vi3Material;
    public Material Vi4Material;
    public Material Vi5Material;
    public Material Vi6Material;
    public Material Vi7Material;
    public Material Vi8Material;
    public Material Vi9Material;
    public Material Vi10Material;
    public Material Vi11Material;
    public Material Vi12Material;
    public Material Vi13Material;
    public Material Vi14Material;
    public Material Vi15Material;
    public Renderer whiteboard;

    void assignMaterial()
    {
        // Get the renderer component of the GameObject
        Renderer renderer = whiteboard.GetComponent<Renderer>();
        switch (slider.value)
        {
            case 1:
                renderer.material = Vi1Material;
                break;
            case 2:
                renderer.material = Vi2Material;
                break; 
            case 3:
                renderer.material = Vi3Material; 
                break;
            case 4:
                renderer.material = Vi4Material;
                break; 
            case 5:
                renderer.material = Vi5Material; 
                break;
            case 6:
                renderer.material = Vi6Material; 
                break;
            case 7:
                renderer.material = Vi7Material; 
                break;
            case 8:
                renderer.material = Vi8Material; 
                break;
            case 9:
                renderer.material = Vi9Material; 
                break;
            case 10:
                renderer.material = Vi10Material; 
                break;
            case 11:
                renderer.material = Vi11Material; 
                break;
            case 12:
                renderer.material = Vi12Material;
                break;
            case 13:
                renderer.material = Vi13Material; 
                break;
            case 14:
                renderer.material = Vi14Material;
                break; 
            case 15:
                renderer.material = Vi15Material;
                break; 
            default:
                break;
        }
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
            if (Time.time - initialTime >= 10.0f)
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
