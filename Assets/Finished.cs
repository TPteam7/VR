using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished : MonoBehaviour
{
    public GameObject greenLight1;
    public GameObject greenLight2;
    public GameObject rightDoor;
    public GameObject leftDoor;
    public AudioSource audioData;
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

            rightDoor.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
            leftDoor.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
        }
    }
}
