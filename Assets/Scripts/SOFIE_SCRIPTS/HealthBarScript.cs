using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider sliderTilda;
    public Slider sliderMort;
    private int maxHealth = 100;

    public void SetHealth(int health)
    {
        sliderTilda.value = health;
        sliderMort.value = maxHealth - health;
    }

}
