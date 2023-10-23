using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    public float balanceTime = 3f; // Time in seconds to complete the rotation
    public float slowdownRate = 5.0f; // Adjust this value to control the slowdown rate
    private float elapsedTime = 0f;
    private bool isRotating = false;
    private bool slow = false;
    private Rigidbody rb;
    public float rotationSpeed = 90.0f; // Adjust the initial rotation speed as needed
    private float targetZRotation = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        //Debug.Log("Time: " + elapsedTime);
        if (isRotating)
        {
            
            if (elapsedTime >= balanceTime)
            {
                isRotating = false;
                slow = true;
            }
        }
        if (slow)
        {
            SlowDown();
        }
    }

     private void FreezeObjectsWithTag(string tag)
    {
        GameObject[] objectsToFreeze = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in objectsToFreeze)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll; // This freezes position and rotation.
            }
            else
            {
                // If an object doesn't have a Rigidbody, you can still freeze its rotation.
                obj.transform.rotation = Quaternion.identity;
            }
        }
    }

    private void SlowDown()
    {
        //Debug.Log("Slowing Down");
        if (elapsedTime - balanceTime >= 2f) // Wait for 2 second after the balanceTime
        {
            // Calculate the current Z rotation of the object
            float currentZRotation = transform.eulerAngles.z;

            // Calculate the step size based on the rotation speed and time
            float step = rotationSpeed * Time.deltaTime;

            // Rotate towards the target rotation
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 
            transform.eulerAngles.y, Mathf.MoveTowardsAngle(currentZRotation, targetZRotation, step));
        }
        if (elapsedTime - balanceTime >= 3.5f) // Wait for 4 second after the balanceTime
        {
            // Set the Z rotation to 0
            Vector3 newRotation = transform.rotation.eulerAngles;
            newRotation.z = 0f;
            transform.rotation = Quaternion.Euler(newRotation);
            FreezeObjectsWithTag("TestingObjects");
            FreezeObjectsWithTag("CubeOnPlank");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TestingObjects"))
        {
            isRotating = true;
            //Debug.Log("Hit, starting timer");
        }
    }
}