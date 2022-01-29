using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CharacterInformation : MonoBehaviour
{
    [HideInInspector] public static List<CharacterInformation> players = new List<CharacterInformation>();
    [Header("CharacterSelection")]
    public CharacterENUM _character = CharacterENUM.NONE;
    [Header("SpeedStats")]
    public float _movementSpeed = 1;
    public float _jumpSpeed = 1;
    [Tooltip("If 0 can jump as fast as you hit ground")]
    public float _jumpCooldown = 0;
    public float _climbSpeed = 1;
    [Tooltip("In unity units")]
    public float _characterHeight = 1;

    public EventSystem es;
    
    [Header("UI information")]
    public GameObject image;
    public GameObject parent;
    public GameObject defaultButton;
    [Header("Playable Character")]
    public GameObject tilda;
    public GameObject mort;

    public void spawnPlayerImage()
    {
        GameObject go;
        go = Instantiate(image, parent.transform);
        TextMeshProUGUI text;
        text = go.GetComponentInChildren<TextMeshProUGUI>();

        if(PlayerJoinAction._playerCount == 1)
        {
            text.text = "Player 1";
        }
        else
        {
            go.GetComponent<RectTransform>().anchoredPosition = new Vector3(14, -62, 0);
            text.text = "Player 2";
        }
        

        es.SetSelectedGameObject(defaultButton);

        go.GetComponent<CharacterSelection>().eventSystem = es; 
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, (transform.position - ( new Vector3(0, _characterHeight / 2, 0))));
    }

    private void Awake()
    {
        if(!players.Contains(this))
        {
            players.Add(this);
        }
        //_character = (CharacterENUM)PlayerJoinAction._playerCount - 1;
        if(UIManager.UI == null)
        {
            return;
        }
        defaultButton = UIManager.UI.defaulButton;
        parent = UIManager.UI.gameObject; 
        spawnPlayerImage();
    }
}
public enum CharacterENUM
{
    MORT, TILDA, NONE
}