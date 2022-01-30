using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [Header("Character Select Things")]
    public GameObject characterSelectObject;
    public static UIManager UI;
    public Dialogue TildaBubble;
    public Dialogue MortBubble;
    public Image TildaPicture;
    public Image MortPicture;
    public GameObject textForInformation;
    
    private Sprite TildaFacts;
    private Sprite MortFacts;
    private Sprite TildaPortrait;
    private Sprite MortPortrait;

    public GameObject defaulButton;
    public TextMeshProUGUI xFor;
    [Header("PowerUp Things")]
    [SerializeField] private Color grayTintColour;
    public Image tildaImage1;
    public Image tildaImage2;
    public Image mortImage1;
    public Image mortImage2;
    [HideInInspector] public bool ready; 

    private void Awake()
    {
        UI = this;
        //sprites to change between
        TildaPortrait = Resources.Load<Sprite>("TildaCharacterCard");
        MortPortrait = Resources.Load<Sprite>("MortCharacterCard");
        TildaFacts = Resources.Load<Sprite>("TildaCardBack");
        MortFacts = Resources.Load<Sprite>("MortCardBack");
        
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
            if(SpawnPoint.spawn)
            {
                p.transform.position = p._character == CharacterENUM.MORT ? SpawnPoint.spawn.mort.transform.position : SpawnPoint.spawn.tilda.transform.position;
            }
        }
        characterSelectObject.SetActive(false);
    }
    public void ChangeActionMap()
    {
        foreach (CharacterInformation p in CharacterInformation.players)
        {
            p.GetComponent<PlayerInput>().SwitchCurrentActionMap("CharacterInput");
            EventSystem tempES = p.GetComponentInChildren<EventSystem>();
            if(tempES && tempES.gameObject.activeInHierarchy)
            {
                tempES.gameObject.SetActive(false);
            }
        }
    }
    public void SetPowerUpImage(Image i, bool haveIt)
    {
        if(!haveIt)
        {
            i.color = grayTintColour;
        }
        else
        {
            i.color = Color.white;
        }
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
    
    public void FlipThePictureTilda()
    {
        if (TildaPicture.sprite == TildaFacts)
        {
            TildaPicture.sprite = TildaPortrait;
        }
        else
        {
            TildaPicture.sprite = TildaFacts; 

        }
    }

    public void FlipThePictureMort()
    {
        if (MortPicture.sprite == MortFacts)
        {
            MortPicture.sprite = MortPortrait;
        }
        else
        {
            MortPicture.sprite = MortFacts; 
        }
    }
}
