using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    //Button pushing
    public GameObject Button;
    public UnityEvent onPress;
    public Material pngMaterial;
    public GameObject whiteboard; // Assign your whiteboard object here
    public UnityEvent onRelease;
    GameObject presser;
    bool isPressed;

    //Ball movement
    public Rigidbody rb;
    public float forceStrength;
    public Collider Target; // Assign your trigger zone here
    private bool isStopped;
    private float stopTime;
    public float stopDuration = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;

        //Ball movement
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.left * forceStrength, ForceMode.Impulse);
        Debug.Log("Object has stopped for 5 seconds.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            Button.transform.localPosition -= new Vector3(0, 0.012f, 0);
            presser = other.gameObject; // Corrected property name
            onPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser) // Corrected property name
        {
            Button.transform.localPosition += new Vector3(0, 0.012f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    // Function to apply PNG material to a different cube
    private void ApplyPNGMaterialToCube()
    {
        if (whiteboard != null)
        {
            Renderer renderer = whiteboard.GetComponent<Renderer>();

            if (renderer != null)
            {
                // Assign the PNG material to the renderer of the target cube
                renderer.material = pngMaterial;
            }
            else
            {
                Debug.LogError("whiteboard does not have a Renderer component.");
            }
        }
        else
        {
            Debug.LogError("whiteboard not found in the scene.");
        }
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
