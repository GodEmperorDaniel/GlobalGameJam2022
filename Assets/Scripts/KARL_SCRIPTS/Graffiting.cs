using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Graffiting : MonoBehaviour
{
    [SerializeField] private Renderer myModel;
    [SerializeField] private float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        Color color = myModel.material.color;
        color.a = 0;
        myModel.material.color = color;

        //StartCoroutine(FadeInMaterial(waitTime));
    }
    public void startFadeIn(UnityEngine.InputSystem.InputValue c)
    {
        StartCoroutine(FadeInMaterial(waitTime, c));
    }
    private IEnumerator FadeInMaterial(float waitTime, UnityEngine.InputSystem.InputValue c)
    {
        //Debug.Log("Innan " + c.isPressed);
        while (myModel.material.color.a < 1 && c.isPressed)
        {
            Color color = myModel.material.color;
            float fadeAmount = color.a + (waitTime * Time.deltaTime);
            color = new Color(color.r, color.g, color.b, fadeAmount);
            myModel.material.color = color;
            yield return null;
        }
        //Debug.Log("Efter " + c.isPressed);
    }
    
    public void startFadeOut(UnityEngine.InputSystem.InputValue c)
    {
        StartCoroutine(FadeOutMaterial(waitTime, c));
    }

    private IEnumerator FadeOutMaterial(float waitTime, UnityEngine.InputSystem.InputValue c)
    {
        while (myModel.material.color.a > 0 && c.isPressed)
        {
            Color color = myModel.material.color;
            float fadeAmount = color.a - (waitTime * Time.deltaTime);
            color = new Color(color.r, color.g, color.b, fadeAmount);
            myModel.material.color = color;
            yield return null;
        }
    }
}
