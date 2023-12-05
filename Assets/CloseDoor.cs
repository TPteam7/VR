using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public Collider Target; // Assign your trigger zone here
    private bool isFirstRun = true;
    public GameObject rightDoor;
    public GameObject leftDoor;

    // Update is called once per frame
    void Update()
    {
        // Check if the object is within the trigger zone
        if (Target.bounds.Contains(transform.position) && isFirstRun)
        {
            isFirstRun = false;
            Debug.Log("If statement ran");

            rightDoor.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
            leftDoor.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
            Debug.Log("Doors have closed.");
        }
    }
}
