using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Balance : MonoBehaviour
{
    private float elapsedTime = 0f;
    private float collidedTime = 0f;
    private bool isRotating = false;
    private bool slow = false;
    private bool done = false;
    private GameObject droppedObj;
    private bool collided = false;
    private bool ready = false;
    private bool balance = false;
    float prevZ = 0;



    private void Start()
    {
        done = false;
        elapsedTime = 0;
        isRotating = false;
        slow = false;
        collided = false;
        balance = false;

    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        //Debug.Log("Time: " + elapsedTime);
        if(collided)
        {
            collidedTime += Time.deltaTime;
            prevZ = transform.eulerAngles.z;
        }
        if (isRotating)
        {   
            isRotating = false;
            slow = true;
        }
        if (slow && !done)
        {
            
            SlowDown();
            //Debug.Log("Slowing Down");
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
            }
        }
    }


    private void SlowDown()
    {
        // Calculate the current Z rotation of the object
        float currentZRotation = transform.eulerAngles.z;

        //Debug.Log("current: " +currentZRotation);
 
        if(!ready &&  Mathf.Abs(currentZRotation) >= 2 && Mathf.Abs(currentZRotation) <= 10 )
        {
            ready = true;
        }
        if (!done && (Mathf.Abs(currentZRotation) <= 0 || Mathf.Abs(currentZRotation) >= 358) && ready) 
        {
            // If the Z rotation is close to 0, set it to 0
            Vector3 newRotation = transform.rotation.eulerAngles;
            newRotation.z = 0f;
            transform.rotation = Quaternion.Euler(newRotation);
            FreezeObjectsWithTag("plank");
            FreezeObjectsWithTag("CorrectObject");
            done = true;
        }
    }


    

    private void OnCollisionEnter(Collision collision)
    {
        collided = true;
        //Debug.Log("Should be completed");
        if (collision.gameObject.CompareTag("CorrectObject"))
        {
            
            isRotating = true;
            balance = true;
        }
    }
}
