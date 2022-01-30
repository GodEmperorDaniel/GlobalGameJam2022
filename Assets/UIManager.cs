using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Character Select Things")]
    public GameObject characterSelectObject;
    public static UIManager UI;
    public Dialogue TildaBubble;
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
    
    public GameObject CreditsCanvas;
    public GameObject WinScreen;
    public GameObject DialogueScreen;
    public GameObject TimerScreen;
    public GameObject HealthbarObj;

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
                if(p._character == CharacterENUM.MORT)
                {
                    p.transform.position = SpawnPoint.spawn.mort.transform.position;
                    p.GetComponent<CharacterInformation>().Setstats();
                }
                else
                {
                    p.transform.position = SpawnPoint.spawn.tilda.transform.position;
                    p.GetComponent<CharacterInformation>().Setstats();
                }
            }
        }
        DialogueScreen.SetActive(true);
        characterSelectObject.SetActive(false);
    }
    public void ChangeActionMapCharacterInput()
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
    
    public void ChangeActionMapUIInput(bool main = false)
    {
        foreach (CharacterInformation p in CharacterInformation.players)
        {
            p.GetComponent<PlayerInput>().SwitchCurrentActionMap("UIInput");
            EventSystem tempES = p.GetComponentInChildren<EventSystem>();
            if(tempES && tempES.gameObject.activeInHierarchy)
            {
                tempES.gameObject.SetActive(main);
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
    
    public void DoCreditsNow()
    {
        //credits canvas
        CreditsCanvas.gameObject.SetActive(true);
        WinScreen.gameObject.SetActive(false);

    }

    public void PlayGameAgain()
    {
        //restart the game here
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
