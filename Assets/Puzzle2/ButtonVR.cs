using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject Button;
    public UnityEvent onPress;
    public Material pngMaterial;
    public UnityEvent onRelease;
    GameObject presser;
    bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            Button.transform.localPosition -= new Vector3(0, 0.012f, 0);
            presser = other.gameObject; // Corrected property name
            onPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser) // Corrected property name
        {
            Button.transform.localPosition += new Vector3(0, 0.012f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    // Function to apply PNG material to a different cube
    private void ApplyPNGMaterialToCube()
    {
        GameObject whiteboard = GameObject.Find("Whiteboard");

        if (whiteboard != null)
        {
            Renderer renderer = whiteboard.GetComponent<Renderer>();

            if (renderer != null)
            {
                // Assign the PNG material to the renderer of the target cube
                renderer.material = pngMaterial;
            }
            else
            {
                Debug.LogError("whiteboard does not have a Renderer component.");
            }
        }
        else
        {
            Debug.LogError("whiteboard not found in the scene.");
        }
    }
}
