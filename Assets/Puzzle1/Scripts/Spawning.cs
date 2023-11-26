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

    public void SetTypeFromIndex(int index)
    {
        if(!chosen)
        {
            if (index == 1)
            {
                Debug.Log("Hit ball 1");
                // Spawn the first prefab when the "1" key is pressed
                chosenObject = prefab1; 
                Invoke("SpawnObject", 1.0f); 
                chosen = true; 
            }
            else if (index == 2)
            {
                // Spawn the first prefab when the "1" key is pressed
                chosenObject = prefab2; 
                Invoke("SpawnObject", 1.0f); 
                chosen = true; 
            }
            else if (index == 3)
            {
                // Spawn the first prefab when the "1" key is pressed
                chosenObject = prefab3; 
                Invoke("SpawnObject", 1.0f); 
                chosen = true; 
            }
        }
        else if (index == 4)
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