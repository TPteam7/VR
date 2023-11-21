using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject prefab1; // Reference to the first prefab
    public GameObject prefab2; // Reference to the second prefab
    public GameObject prefab3; // Reference to the third prefab

    private GameObject chosenObject;
    private GameObject currentObject;
    private bool chosen = false;

    void Update()
    {
        if(!chosen)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                // Spawn the first prefab when the "1" key is pressed
                chosenObject = prefab1; 
                Invoke("SpawnObject", 1.0f); 
                chosen = true; 
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                // Spawn the first prefab when the "1" key is pressed
                chosenObject = prefab2; 
                Invoke("SpawnObject", 1.0f); 
                chosen = true; 
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                // Spawn the first prefab when the "1" key is pressed
                chosenObject = prefab3; 
                Invoke("SpawnObject", 1.0f); 
                chosen = true; 
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if(currentObject != null)
            {
                Destroy(currentObject);
                chosenObject = null;
                chosen = false;
            }
        }
    }

    void SpawnObject()
    {
        currentObject = Instantiate(chosenObject, transform.position, Quaternion.identity);
    }
}