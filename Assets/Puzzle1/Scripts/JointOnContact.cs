using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointOnContacts : MonoBehaviour
{
    private bool jointCreated = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the specific object you want to connect with.
        if (collision.gameObject.CompareTag("plank"))
        {
            Rigidbody targetRigidbody = collision.rigidbody;
            if (targetRigidbody != null)
            {
                // Create a FixedJoint between this object and the target object.
                FixedJoint fixedJoint = gameObject.AddComponent<FixedJoint>();
                fixedJoint.connectedBody = targetRigidbody;

                // Optional: Configure the joint properties as needed.
                // For example, you can set the break force or break torque.

                jointCreated = true;
            }
        }
    }
}

