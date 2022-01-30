using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//OBS WORK OUT BUG MARKED IN THIS CODE!
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
        if (CharacterInformation.players.Count <= 1)
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
            else if (charInfo.es.currentSelectedGameObject.name == "LeftButton" && choosenCharacter != CharacterENUM.TILDA)
            {
                choosenCharacter = CharacterENUM.TILDA;
                return;
            }
            else
            {
                dialogueIsRunning = true;
                foreach (CharacterInformation p in CharacterInformation.players)
                {
                    if (p == charInfo)
                    {
                        p._character = choosenCharacter;
                    }
                    else
                    {
                        if (choosenCharacter == CharacterENUM.MORT)
                        {
                            p._character = CharacterENUM.TILDA;
                        }
                        else
                        {
                            p._character = CharacterENUM.MORT;
                        }
                    }
                }
                UIManager.UI.StartGame();
            }
        }
        else if (dialogueIsRunning)//&& UIManager.UI.gameObject.activeInHierarchy)
        {
            if (choosenCharacter == CharacterENUM.MORT)
            {
                UIManager.UI.TildaBubble.ButtonForDialoguePressed();
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
        EventSystem.current.gameObject.SetActive(false);
        if (!charInfo.es.isActiveAndEnabled)
        {
            charInfo.es.gameObject.SetActive(true);
        }
        EventSystem.current = charInfo.es;
    }

    public void OnSkip()
    {
        if (!UIManager.UI.characterSelectObject.activeInHierarchy)
        {
            if (UIManager.UI.DialogueScreen.activeInHierarchy)
            {
                UIManager.UI.TildaBubble.OnSkipDialogue();
            }
            else if (UIManager.UI.CreditsCanvas.activeSelf)
            {
                UIManager.UI.PlayGameAgain();
            }
            //OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS OBS 
            else if (UIManager.UI.WinScreen.activeSelf) //this can cause bug in countdown screen!
            {
                UIManager.UI.DoCreditsNow();
            }
        }
    }

    public void OnFlipTheCard()
    {
        if (charInfo.es.currentSelectedGameObject.name == "RightButton")
        {
            UIManager.UI.FlipThePictureMort();
        }
        else if (charInfo.es.currentSelectedGameObject.name == "LeftButton")
        {
            UIManager.UI.FlipThePictureTilda();
        }
    }

}
