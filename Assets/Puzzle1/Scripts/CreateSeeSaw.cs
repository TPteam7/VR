using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSeeSaw : MonoBehaviour
{
    public GameObject prefab; // Reference to your prefab
    private GameObject currentPrefab;

    void Start()
    {
        currentPrefab = Instantiate(prefab, transform.position, Quaternion.identity);
    }
    public void SetTypeFromIndex(int index)
    {
        if (index == 4)
        {
            if (currentPrefab != null)
            {
                Destroy(currentPrefab); // Destroy the current prefab if it exists
            }

            // Spawn a new prefab
            currentPrefab = Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}

