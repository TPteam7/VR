using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public Collider Target; // Assign your trigger zone here
    private bool isFirstRun = true;
    public GameObject rightDoor;
    public GameObject leftDoor;
    public AudioSource audioData;

    // Update is called once per frame
    void Update()
    {
        // Check if the object is within the trigger zone
        if (Target.bounds.Contains(transform.position) && isFirstRun)
        {
            isFirstRun = false;
            Debug.Log("If statement ran");

            for (int i = 0; i < 90; i++)
            {
                rightDoor.transform.Rotate(0.0f, -1.0f, 0.0f, Space.Self);
                leftDoor.transform.Rotate(0.0f, 1.0f, 0.0f, Space.Self);
            }
            Debug.Log("Doors have closed.");
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            audioData.time = 4.0f;

        }
    }
}
