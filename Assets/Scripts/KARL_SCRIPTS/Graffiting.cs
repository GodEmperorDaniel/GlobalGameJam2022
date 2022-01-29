using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void startFadeIn()
    {
        StartCoroutine(FadeInMaterial(waitTime));
    }
    private IEnumerator FadeInMaterial(float waitTime)
    {
        while (myModel.material.color.a < 1)
        {
            Color color = myModel.material.color;
            float fadeAmount = color.a + (waitTime * Time.deltaTime);

            color = new Color(color.r, color.g, color.b, fadeAmount);
            myModel.material.color = color;
            yield return null;
        }
    }
}
