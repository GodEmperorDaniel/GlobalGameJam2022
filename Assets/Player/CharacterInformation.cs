using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterInformation : MonoBehaviour
{
    [Header("CharacterSelection")]
    public CharacterENUM _character;
    [Header("SpeedStats")]
    public float _movementSpeed = 1;
    public float _jumpSpeed = 1;
    [Tooltip("If 0 can jump as fast as you hit ground")]
    public float _jumpCooldown = 0;
    public float _climbSpeed = 1;
    [Tooltip("In unity units")]
    public float _characterHeight = 1;

    public EventSystem es;
    
    public GameObject image;
    public GameObject parent;
    public GameObject defaultButton;
    public GameObject tilda;
    public GameObject mort;

    public void spawnPlayerImage()
    {
        GameObject go;
        go = Instantiate(image, parent.transform);
        Debug.Log("Set player to cotroller");

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
        defaultButton = UIManager.UI.defaulButton;
        parent = UIManager.UI.gameObject; 
        spawnPlayerImage();
    }
}
public enum CharacterENUM
{
    MORT, TILDA
}