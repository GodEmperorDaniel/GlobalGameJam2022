using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentageGraffiti : MonoBehaviour
{
    public List<Graffiting> WallsForGraffiti;
    private int numberOfWallsWithGraffiti;
    public HealthBarScript healthBar;

    private int graffitiWall;
    private int cleanWall;
    private void Update()
    {
        //Debug.Log(checkPercentage());
        calculatePercentage(checkPercentage());
        CheckWinner();
    }

    private void CheckWinner()
    {
        graffitiWall = checkPercentage();
        //Debug.Log("Graffiti: " + graffitiWall);
        cleanWall = WallsForGraffiti.Count - graffitiWall;
        //Debug.Log("Clean: " + cleanWall);
    }

    private int checkPercentage()
    {
        numberOfWallsWithGraffiti = 0;
        foreach (Graffiting graffitiWall in WallsForGraffiti)
        {
            // if graffitiWall.painted is true 
            if (!graffitiWall.isCleaned)
                numberOfWallsWithGraffiti++;
        }
        return numberOfWallsWithGraffiti;
    }

    private void calculatePercentage(int graffitiWallNr)
    {
        //float percentage = WallsForGraffiti.Count/ graffitiWall;
        healthBar.SetMaxhealth(WallsForGraffiti.Count);
        healthBar.SetHealth(graffitiWallNr);
    }

    public int GetWinner()
    {
        if (graffitiWall > cleanWall)
            return 1;
        else if(graffitiWall < cleanWall)
            return 2;
        else
            return 3;

    }
}
