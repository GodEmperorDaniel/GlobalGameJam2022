using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class percentageGraffiti : MonoBehaviour
{
    public List<GameObject> WallsForGraffiti;
    private int numberOfWallsWithGraffiti;
    public HealthBarScript healthBar; 

    private void Update()
    {
        checkPercentage();
        calculatePercentage();
    }

    private int checkPercentage()
    {
        numberOfWallsWithGraffiti = 0;
        foreach (GameObject graffitiWall in WallsForGraffiti)
        {
            // if graffitiWall.painted is true 
            numberOfWallsWithGraffiti++; 
        }

        return numberOfWallsWithGraffiti;
    }

    private void calculatePercentage()
    {
        int percentage = WallsForGraffiti.Count/numberOfWallsWithGraffiti;
        healthBar.SetHealth(percentage);
    }
}
