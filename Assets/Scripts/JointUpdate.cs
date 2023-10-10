using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointUpdate : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves "Object1"
        if (collision.gameObject.CompareTag("Plank"))
        {
            Debug.Log("HITITTTTT.");
            // Add a Fixed Joint component to "Object2"
            FixedJoint joint = collision.gameObject.AddComponent<FixedJoint>();

            // Connect "Object2" to "Object1"
            joint.connectedBody = GetComponent<Rigidbody>();
        }
    }
}

