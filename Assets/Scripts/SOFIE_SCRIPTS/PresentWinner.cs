using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PresentWinner:MonoBehaviour
{
    public PercentageGraffiti percentageGraffiti;

    private void Update()
    {
        
    }
    public void CheckForWinner()
    {
        if (percentageGraffiti.GetWinner() == 1)
            Debug.Log("TildaWon");//gameObject.transform.Find("TildaWon").transform.gameObject.SetActive(true);
        else if (percentageGraffiti.GetWinner() == 2)
            Debug.Log("MortWon");//gameObject.transform.Find("MortWon").transform.gameObject.SetActive(true);
        else
            Debug.Log("Tie");//gameObject.transform.Find("Tie").transform.gameObject.SetActive(true);
    }
}
