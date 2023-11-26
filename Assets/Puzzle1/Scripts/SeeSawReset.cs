using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSawReset : MonoBehaviour
{
     private Quaternion defaultRotation;

    void Start()
    {
        // Store the default rotation of the see-saw
        defaultRotation = transform.rotation;
    }

    void Update()
    {
        // Implement different behaviors for the see-saw based on your scenarios
        // For example, you can add logic to tilt or rotate the see-saw as needed.
    }

    // Reset the see-saw to its default state
    public void ResetSeeSaw()
    {
        transform.rotation = defaultRotation;
    }
}
