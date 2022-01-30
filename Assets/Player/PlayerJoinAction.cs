using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerJoinAction : MonoBehaviour
{
    public static int _playerCount = 0;
    
    public void AddPlayerCount()
    {
        _playerCount++;
    }
}
