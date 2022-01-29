using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;
    private RectTransform image;
    [SerializeField] private float positionToTheLeft = -80.0f;
    [SerializeField] private float positionToTheRight = 80.0f; 

    private void Start()
    {
        image = GetComponent<RectTransform>();

    }


    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == leftButton)
        {
            moveImageToLeft();
        }
        
        if (EventSystem.current.currentSelectedGameObject == rightButton)
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
