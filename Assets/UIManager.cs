using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager UI;
    public GameObject defaulButton;

    private void Awake()
    {
        UI = this;
    }
    public bool CheckIfBothSelectedCharacter()
    {
        foreach (CharacterInformation p in CharacterInformation.players)
        {
            if (p.GetComponent<UIInputs>().choosenCharacter == CharacterENUM.NONE)
            {
                return false;
            }
        }
        return true;
    }
}
