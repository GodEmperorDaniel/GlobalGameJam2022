using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInformation : MonoBehaviour
{
    public CharacterENUM _character;
    public float _movementSpeed = 2;
}
public enum CharacterENUM
{
    MORT, TILDA
}