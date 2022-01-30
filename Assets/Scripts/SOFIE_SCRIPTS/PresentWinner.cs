using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PresentWinner : MonoBehaviour
{
    private void Update()
    {
        if(//tildaWon == true)
        gameObject.transform.Find("TildaWon").transform.gameObject.SetActive(true);
        
        else if(//tildaWon==false)
        gameObject.transform.Find("MortWon").transform.gameObject.SetActive(true);
        
        else
        {
            gameObject.transform.Find("Tie").transform.gameObject.SetActive(true);
        }
    }
}
