using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Animations;

public class CharacterInformation : MonoBehaviour
{
    [HideInInspector] public static List<CharacterInformation> players = new List<CharacterInformation>();
    [Header("CharacterSelection")]
    public CharacterENUM _character = CharacterENUM.NONE;
    [Header("CharacterStats")]
    public float _movementSpeed = 1;
    public float _jumpSpeed = 1;
    [Tooltip("If 0 can jump as fast as you hit ground")]
    public float _jumpCooldown = 0;
    public float _jumpDuration = 0.5f;
    public float _climbSpeed = 1;
    [Tooltip("In unity units")]
    public float _characterHeight = 1;
    public float _cleanOrGraffitiMultiplier = 1;

    public EventSystem es;

    [Header("UI information")]
    public GameObject image;
    public Sprite player1;
    public Sprite player2;
    public GameObject parent;
    public GameObject defaultButton;
    [Header("Playable Character things")]
    public GameObject tildaGameObject;
    public GameObject mortGameObject;
    public Animator tildaAnim;
    public Animator mortAnim;

    public void spawnPlayerImage()
    {
        GameObject go;
        go = Instantiate(image, parent.transform);

        if (PlayerJoinAction._playerCount == 1)
        {
            go.GetComponent<Image>().sprite = player1;
        }
        else
        {
            go.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -62, 0);
            go.GetComponent<Image>().sprite = player2;
        }
        es.SetSelectedGameObject(defaultButton);

        go.GetComponent<CharacterSelection>().eventSystem = es;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3[] positions =
{
            transform.position,
            new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z),
            new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z),
            new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f),
            new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f),
            new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z - 0.5f),
            new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z + 0.5f),
            new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z - 0.5f),
            new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z + 0.5f)
        };
        for (int i = 0; i < 9; i++)
        {
            Gizmos.DrawLine(positions[i], (positions[i] - (new Vector3(0, _characterHeight / 2, 0))));
        }
    }
    public void Setstats()
    {
        switch (_character)
        {
            case CharacterENUM.MORT:
                MortSettings mort = new MortSettings();
                _movementSpeed = mort._movementSpeed;
                _jumpSpeed = mort._jumpSpeed;
                _jumpCooldown = mort._jumpCooldown;
                _jumpDuration = mort._jumpDuration;
                _climbSpeed = mort._climbSpeed;
                _characterHeight = mort._characterHeight;
                _cleanOrGraffitiMultiplier = mort._cleanOrGraffitiMultiplier;
                break;
            case CharacterENUM.TILDA:
                TildaSettings tilda = new TildaSettings();
                _movementSpeed = tilda._movementSpeed;
                _jumpSpeed = tilda._jumpSpeed;
                _jumpCooldown = tilda._jumpCooldown;
                _jumpDuration = tilda._jumpDuration;
                _climbSpeed = tilda._climbSpeed;
                _characterHeight = tilda._characterHeight;
                _cleanOrGraffitiMultiplier = tilda._cleanOrGraffitiMultiplier;
                break;
            case CharacterENUM.NONE:
                break;
            default:
                break;
        }
    }
    public void SetCharacterAnim()
    {
        MovementScript move = GetComponent<MovementScript>();
        switch (_character)
        {
            case CharacterENUM.MORT:
                move._anim = mortAnim;
                break;
            case CharacterENUM.TILDA:
                mortGameObject.SetActive(false);
                tildaGameObject.SetActive(true);
                move._anim = tildaAnim;
                break;
            case CharacterENUM.NONE:
                Debug.LogWarning("NOW SOMETHING WENT VERY WRONG WHEN SETTING ANIMATION");
                break;
            default:
                break;
        }
        
    }
    private void Awake()
    {
        transform.position = new Vector3(UnityEngine.Random.Range(2f, 20f), UnityEngine.Random.Range(2f,20f));
        if (!players.Contains(this))
        {
            players.Add(this);
        }
        if (UIManager.UI == null)
        {
            return;
        }
        defaultButton = UIManager.UI.defaulButton;
        parent = UIManager.UI.characterSelectObject;
        spawnPlayerImage();
    }
}
public enum CharacterENUM
{
    MORT, TILDA, NONE
}

public class MortSettings
{
    public float _movementSpeed = 2;
    public float _jumpSpeed = 16;
    public float _jumpCooldown = 0;
    public float _jumpDuration = 0.5f;
    public float _climbSpeed = 5;
    public float _characterHeight = 5;
    public float _cleanOrGraffitiMultiplier = 1;
}

public class TildaSettings
{
    public float _movementSpeed = 4;
    public float _jumpSpeed = 16;
    public float _jumpCooldown = 0;
    public float _jumpDuration = 0.5f;
    public float _climbSpeed = 1;
    public float _characterHeight = 5;
    public float _cleanOrGraffitiMultiplier = 1;
}