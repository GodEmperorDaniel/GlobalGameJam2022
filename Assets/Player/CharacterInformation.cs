using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInformation : MonoBehaviour
{
    [Header("CharacterSelection")]
    public CharacterENUM _character;
    [Header("SpeedStats")]
    public float _movementSpeed = 1;
    public float _jumpSpeed = 1;
    public float _climbSpeed = 1;
    [Tooltip("In unity units")]
    public float _characterHeight = 1;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, (transform.position - ( new Vector3(0, _characterHeight / 2, 0))));
    }
}
public enum CharacterENUM
{
    MORT, TILDA
}