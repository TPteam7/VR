using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished : MonoBehaviour
{
    public GameObject greenLight1;
    public GameObject greenLight2;
    public GameObject rightDoor;
    public GameObject leftDoor;
    private bool ranOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (greenLight1.activeSelf && greenLight2.activeSelf && !ranOnce)
        {
            ranOnce = true;
            for (int i = 0; i < 90; i++)
            {
                rightDoor.transform.Rotate(0.0f, 1.0f, 0.0f, Space.Self);
                leftDoor.transform.Rotate(0.0f, -1.0f, 0.0f, Space.Self);
            }
        }
    }
}
