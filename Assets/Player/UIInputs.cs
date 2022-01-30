using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInputs : MonoBehaviour
{
    private CharacterInformation charInfo;
    public CharacterENUM choosenCharacter = CharacterENUM.NONE;
    public bool dialogueIsRunning;
    private void Awake()
    {
        charInfo = GetComponent<CharacterInformation>();
    }
    public void OnUIMoving()
    {
        if(CharacterInformation.players.Count <= 1)
        {
            charInfo.es.gameObject.SetActive(false);
            return;
        }
        else
        {
            charInfo.es.gameObject.SetActive(true);
        }
        if (charInfo.es.IsActive())
        {
            ActivateMyEventSystem();
        }
    }
    public void OnAccept()
    {
        if (charInfo.es.IsActive())
        {
            ActivateMyEventSystem();
        }
        //kommer skapa bugg. Kommer bara in i den här funktionen.
        if (GoodSelections() && UIManager.UI.gameObject.activeInHierarchy && !dialogueIsRunning)
        {
            if (charInfo.es.currentSelectedGameObject.name == "RightButton" && choosenCharacter != CharacterENUM.MORT)
            {
                choosenCharacter = CharacterENUM.MORT;
                return;
            }
            else if(charInfo.es.currentSelectedGameObject.name == "LeftButton" && choosenCharacter != CharacterENUM.TILDA)
            {
                choosenCharacter = CharacterENUM.TILDA;
                return;
            }
            else
            {
                UIManager.UI.StartGame();
                dialogueIsRunning = true;
                foreach (CharacterInformation p in CharacterInformation.players)
                {
                    if (p == charInfo)
                    {
                        p._character = choosenCharacter;
                    }
                    else
                    {
                        if(choosenCharacter == CharacterENUM.MORT)
                        {
                            p._character = CharacterENUM.TILDA;
                        }
                        else
                        {
                            p._character = CharacterENUM.MORT;
                        }
                    }
                }
            }
        }
        

        else if(dialogueIsRunning )//&& UIManager.UI.gameObject.activeInHierarchy)
        {
            if (choosenCharacter == CharacterENUM.MORT)
            {
                UIManager.UI.MortBubble.ButtonForDialoguePressed();
            }
            else
            {
                UIManager.UI.TildaBubble.ButtonForDialoguePressed();
            }
        }
    }
    private bool GoodSelections()
    {
        if (CharacterInformation.players.Count <= 1)
        {
            return false;
        }
        if (CharacterInformation.players[0].es.currentSelectedGameObject == CharacterInformation.players[1].es.currentSelectedGameObject)
        {
            return false;
        }
        return true;
    }
    public void ActivateMyEventSystem()
    {
        EventSystem.current = charInfo.es;
    }
    
    public void OnSkip()
    {
        if (choosenCharacter == CharacterENUM.MORT)
        {
            UIManager.UI.MortBubble.OnSkipDialogue();
        }
        else
        {
            UIManager.UI.TildaBubble.OnSkipDialogue();
        }
           
    }
}
