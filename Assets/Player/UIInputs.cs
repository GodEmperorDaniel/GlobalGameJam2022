using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInputs : MonoBehaviour
{
    private CharacterInformation charInfo;
    public CharacterENUM choosenCharacter = CharacterENUM.NONE;
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
        if (GoodSelections())
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
}
