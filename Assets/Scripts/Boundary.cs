using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    // Define the boundaries
    public float minX = -25f;
    public float maxX = 25f;
    public float minY = 2.5f;
    public float maxY = 25f;
    public float minZ = -25f;
    public float maxZ = 25f;

    void Update()
    {
        // Get the player's current position
        Vector3 playerPosition = transform.position;

        // Clamp the player's position to stay within the specified range
        float clampedX = Mathf.Clamp(playerPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(playerPosition.y, minY, maxY);
        float clampedZ = Mathf.Clamp(playerPosition.z, minZ, maxZ);

        // Check if the player's position was clamped (i.e., they stepped out of range)
        if (playerPosition != new Vector3(clampedX, clampedY, clampedZ))
        {
            // Display a warning message
            Debug.LogWarning("Warning: You are outside the allowed range!");

            // Update the player's position with the clamped values to bring them back inside the boundaries
            transform.position = new Vector3(clampedX, clampedY, clampedZ);
        }
    }
}
