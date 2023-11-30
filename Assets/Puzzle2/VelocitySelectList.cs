using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocitySelectList : MonoBehaviour
{
    public Rigidbody rb; // Reference to the Rigidbody of the ball
    public float velocity1 = 9f; // Adjust these values based on your requirements
    public float velocity2 = 10f;
    public float velocity3 = 15f;

    public void SetTypeFromIndex(int index)
    {
        Debug.Log(index);
        switch (index)
        {
            case 1:
                Debug.Log("CASE 1");
                rb = GetComponent<Rigidbody>();
                rb.AddForce(Vector3.left * velocity1, ForceMode.Impulse);
                break;
            case 2:
                rb = GetComponent<Rigidbody>();
                rb.AddForce(Vector3.left * velocity2, ForceMode.Impulse);
                break;
            case 3:
                rb = GetComponent<Rigidbody>();
                rb.AddForce(Vector3.left * velocity3, ForceMode.Impulse);
                break;
            default:
                Debug.LogWarning("Invalid index selected");
                break;
        }
    }
}
