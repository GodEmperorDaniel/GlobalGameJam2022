using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager UI;
    public GameObject defaulButton;
    public TextMeshProUGUI xFor;
    [HideInInspector] public bool ready; 

    private void Awake()
    {
        UI = this;
        PressXToJoinGame();
    }
    private void Update()
    {
        if(CheckIfBothSelectedCharacter())
        {
            ShowContinueUI();
            ready = true;
        }
        if(CharacterInformation.players.Count > 1)
        {
            PressXToselectCharacter();
        }
    }
    private void PressXToJoinGame()
    {
        xFor.text = "Any Button to Join";
    }
    public void PressXToselectCharacter()
    {
        xFor.text = "X to Pick Character";
    }
    private void ShowContinueUI()
    {
        xFor.text = "X to Start Game!";
    }
    public void StartGame()
    {
        foreach (CharacterInformation p in CharacterInformation.players)
        {
            p.es.gameObject.SetActive(false);
            p.GetComponent<PlayerInput>().SwitchCurrentActionMap("CharacterInput"); 
        }
        gameObject.SetActive(false);
    }
    public bool CheckIfBothSelectedCharacter()
    {
        if(CharacterInformation.players.Count <= 1)
        {
            return false;
        }
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
