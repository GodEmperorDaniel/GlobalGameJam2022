using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    CharacterInformation charInfo;
    private void Start()
    {
        charInfo = GetComponent<CharacterInformation>();
    }
    public void Movement(InputAction.CallbackContext c)
    {
        Vector2 tempDirection = c.ReadValue<Vector2>();
        Vector3 direction = new Vector3(tempDirection.x, 0, tempDirection.y);
        transform.Translate(direction * charInfo._movementSpeed);
    }

    public void JumpOrClimb(InputAction.CallbackContext c)
    {
        //check if close to a ladder first
    }
    public void GraffitiOrClean(InputAction.CallbackContext c)
    {
        if(charInfo._character == CharacterENUM.MORT)
        {
            //do clean
        }
        else
        {
            //do graffiti
        }
    }
    public void TriggerPowerUp(InputAction.CallbackContext c)
    {
        if(charInfo._character == CharacterENUM.MORT)
        {

        }
        else
        {

        }
    }
}
