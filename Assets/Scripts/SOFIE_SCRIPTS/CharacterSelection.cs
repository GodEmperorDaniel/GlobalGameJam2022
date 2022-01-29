using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    private RectTransform image;
    [SerializeField] private float positionToTheLeft = -80.0f;
    [SerializeField] private float positionToTheRight = 80.0f;
    public EventSystem eventSystem; 

    private void Start()
    {
        image = GetComponent<RectTransform>();

    }


    private void Update()
    {
        if (eventSystem.currentSelectedGameObject.name == "LeftButton")
        {
            moveImageToLeft();
        }
        
        if (eventSystem.currentSelectedGameObject.name == "RightButton")
        {
            moveImageToRight();
        }
    }

    private void moveImageToLeft()
    {
        image.anchoredPosition = new Vector2(positionToTheLeft, image.anchoredPosition.y);
    }
    
    private void moveImageToRight()
    {
        image.anchoredPosition = new Vector2(positionToTheRight, image.anchoredPosition.y);
    }
}
