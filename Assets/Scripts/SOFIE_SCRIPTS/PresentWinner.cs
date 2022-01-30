using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PresentWinner : MonoBehaviour
{
    public PercentageGraffiti percentageGraffiti;
    public GameObject mortWin;
    public GameObject tildaWin;
    public GameObject bothWin;
    public GameObject playerOne;
    public GameObject playerTwo;

    private void Update()
    {

    }
    public void CheckForWinner()
    {
        if (percentageGraffiti.GetWinner() == 1)
        {
            tildaWin.SetActive(true);
            UIManager.UI.ChangeActionMapUIInput();
            if (CharacterInformation.players[0]._character == CharacterENUM.TILDA)
            {
                playerOne.SetActive(true);
            }
            else
            {
                playerTwo.SetActive(true);
            }
        }
        else if (percentageGraffiti.GetWinner() == 2)
        {
            mortWin.SetActive(true);
            UIManager.UI.ChangeActionMapUIInput();
            if(CharacterInformation.players[0]._character == CharacterENUM.MORT)
            {
                playerOne.SetActive(true);
            }
            else
            {
                playerTwo.SetActive(true);
            }
        }
        else
        {
            playerOne.SetActive(true);
            playerTwo.SetActive(true);
            bothWin.SetActive(true);
        }
    }
}
