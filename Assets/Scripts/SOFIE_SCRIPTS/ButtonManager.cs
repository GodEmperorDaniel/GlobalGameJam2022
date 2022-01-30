using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject CreditsCanvas;
    public GameObject Menu;
    public void DoCreditsNow()
    {
        //credits canvas
        CreditsCanvas.gameObject.SetActive(true);

    }

    public void PlayGameAgain()
    {
        //restart the game here
        
        //character selection
        Menu.gameObject.SetActive(true);
    }
    
}
