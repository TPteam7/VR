using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public GameObject objectToCopy; // Reference to the object you want to copy.
    public Transform destination; // The destination where the copy will be placed.

    private void Start()
    {
        // Check if the object to copy is provided.
        if (objectToCopy != null)
        {
            // Instantiate a copy of the object.
            GameObject copy = Instantiate(objectToCopy);

            // Set the parent of the copy to the Container (optional).
            copy.transform.SetParent(transform);

            // Position the copy at the destination.
            copy.transform.position = destination.position;
        }
        else
        {
            Debug.LogError("Please assign an object to copy in the Inspector.");
        }
    }
}
