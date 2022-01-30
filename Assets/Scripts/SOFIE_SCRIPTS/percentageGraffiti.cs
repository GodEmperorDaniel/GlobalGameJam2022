using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class percentageGraffiti : MonoBehaviour
{
    public List<Graffiting> WallsForGraffiti;
    private int numberOfWallsWithGraffiti;
    public HealthBarScript healthBar;

    private void Start()
    {
        
        
    }
    private void Update()
    {
        Debug.Log(checkPercentage());
        calculatePercentage(checkPercentage());
    }

    private int checkPercentage()
    {
        numberOfWallsWithGraffiti = 0;
        foreach (Graffiting graffitiWall in WallsForGraffiti)
        {
            
            // if graffitiWall.painted is true 
            if (!graffitiWall.isCleaned)
            {
                numberOfWallsWithGraffiti++;
            }

        }

        return numberOfWallsWithGraffiti;
    }

    private void calculatePercentage(int graffitiWall)
    {
        //float percentage = WallsForGraffiti.Count/ graffitiWall;
        healthBar.SetMaxhealth(WallsForGraffiti.Count);
        healthBar.SetHealth(graffitiWall);
    }
}
