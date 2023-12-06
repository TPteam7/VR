using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBalance : MonoBehaviour
{
    
    public Material InstructionMaterial;
    public Material DoneMaterial;
    public Renderer board;
    private bool right = false;
    public GameObject keyObject;

    
    // Start is called before the first frame update
    void Start()
    {
        right = false;
    }

    public void SetTypeFromIndex(int index)
    {
        if(index == 1)
        {
            right = true;
            Debug.Log("Hit The right ball");
        }
        else
        {
            right = false;
            Debug.Log("HIT THE WRONG BALL");
        }
        Invoke("runUpdate",6.0f);
    }
    // Update is called once per frame
    public void runUpdate()
    {
        Renderer renderer = board.GetComponent<Renderer>();
        if(right)
        {
            renderer.material = DoneMaterial;
            if (keyObject != null)
            {
                keyObject.SetActive(true);
            }
        }
        else{
            renderer.material = InstructionMaterial;
            if (keyObject != null)
            {
                keyObject.SetActive(false);
            }
        }
    }
}
