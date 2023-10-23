using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Transport : MonoBehaviour
{
    public Button initiateTransport;


    private GameObject fragment1;
    private GameObject fragment2;
    private GameObject fragment3;
    private GameObject key;

    private float fullyVisible = 1;
    private float fullyTransparent = 0;

    AudioSource audioData;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Stop();

        fragment1 = GameObject.Find("Fragment1");
        fragment2 = GameObject.Find("Fragment2");
        fragment3 = GameObject.Find("Fragment3");

        key = GameObject.Find("Key");

        Material fragment1Material = fragment1.GetComponent<Renderer>().material;
        Material fragment2Material = fragment2.GetComponent<Renderer>().material;
        Material fragment3Material = fragment3.GetComponent<Renderer>().material;

        Material keyMaterial = key.GetComponent<Renderer>().material;

        key.SetActive(false);

        Color initKeyColor = new Color(keyMaterial.color.r, keyMaterial.color.g, keyMaterial.color.b, fullyTransparent);

        keyMaterial.SetColor("_Color", initKeyColor);

        initiateTransport.onClick.AddListener(TasksOnClick);
    }


    void Update()
    {
        
    }

    IEnumerator ChangeColorOverTime(float time, GameObject obj1, GameObject obj2, GameObject obj3, GameObject obj4)
    {
        // changes color of an objects over time, by manipulating alpha

        Color oldColor1 = obj1.GetComponent<Renderer>().material.color;
        Color newColor1 = new Color(oldColor1.r, oldColor1.g, oldColor1.b, fullyTransparent);



        Color oldColor4 = obj4.GetComponent<Renderer>().material.color;
        Color newColor4 = new Color(oldColor4.r, oldColor4.g, oldColor4.b, fullyVisible);

        float currentTime = 0.0f;

        Color lerpedColorFrag;
        Color lerpedColorKey;

        do
        {
            lerpedColorFrag = Color.Lerp(oldColor1, newColor1, currentTime / time);
            obj1.GetComponent<Renderer>().material.SetColor("_Color", lerpedColorFrag);
            obj2.GetComponent<Renderer>().material.SetColor("_Color", lerpedColorFrag);
            obj3.GetComponent<Renderer>().material.SetColor("_Color", lerpedColorFrag);


            lerpedColorKey = Color.Lerp(oldColor4, newColor4, ((currentTime / time) - 0.1f));
            obj4.GetComponent<Renderer>().material.SetColor("_Color", lerpedColorKey);

            currentTime += Time.deltaTime;
            yield return null;


        } while (currentTime <= time);
    }
    
    void TasksOnClick()
    {
        // executed when the "Initiate Transport" button is clicked

        key.SetActive(true);

        
        StartCoroutine(ChangeColorOverTime(5f, fragment1, fragment2, fragment3, key));

        initiateTransport.gameObject.SetActive(false);


        audioData.Play(0);
        
    }

    
    void ChangeMaterial(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
}
