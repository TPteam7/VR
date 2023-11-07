using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    private float elapsedTime = 0f;
    private float collidedTime = 0f;
    private bool isRotating = false;
    private bool slow = false;
    private bool done = false;
    private bool correctObject = false;
    private GameObject droppedObj;
    private bool collided = false;


    private void Start()
    {
        done = false;
        correctObject = false;
        elapsedTime = 0;
        isRotating = false;
        slow = false;
        collided = false;

    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        //Debug.Log("Time: " + elapsedTime);
        if(collided)
        {
            collidedTime += Time.deltaTime;
        }
        if (isRotating)
        {   
            isRotating = false;
            slow = true;
        }
        if (slow && !done)
        {
            SlowDown();
        }
        // Check if 5 seconds have passed and stop everything
        if (collidedTime >= 5.0f)
        {
            CheckBalance();
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
            // Freeze rotation along the Z-axis (for example)
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ |
                RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;


            // Reset the rotation to (0, 0, 0)
            //obj.transform.rotation = Quaternion.identity;
            
        }
    }
}


    private void SlowDown()
{
    // Calculate the current Z rotation of the object
    float currentZRotation = transform.eulerAngles.z;
    Debug.Log("Z rotate: " + currentZRotation);

    if (!done && Mathf.Abs(currentZRotation) <= 1) 
    {
        // If the Z rotation is close to 0, set it to 0
        Vector3 newRotation = transform.rotation.eulerAngles;
        newRotation.z = 0f;
        transform.rotation = Quaternion.Euler(newRotation);
        FreezeObjectsWithTag("plank");
        Debug.Log("get out");
        done = true;
    }

}

    private void CheckBalance()
    {
        float zRotation = transform.eulerAngles.z;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("CorrectObject"))
        {
            collided = true;
            isRotating = true;
            correctObject = true;
            
            Debug.Log("Hit, starting timer");
        }
        else if (collision.gameObject.CompareTag("TestingObjects"))
        {
            collided = true;
            droppedObj  = collision.gameObject;
        }
    }
}
