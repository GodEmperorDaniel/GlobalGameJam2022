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
    public void OnMoving()
    {
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
            if (charInfo.es.currentSelectedGameObject.name == "RightButton")
            {
                choosenCharacter = CharacterENUM.MORT;
            }
            else if(charInfo.es.currentSelectedGameObject.name == "LeftButton")
            {
                choosenCharacter = CharacterENUM.TILDA;
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
        EventSystem current = EventSystem.current;
        EventSystem.current = charInfo.es;
        //change back?
    }
}
