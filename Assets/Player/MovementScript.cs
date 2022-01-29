using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{

    //
    //OBS MAKE THINGS INTO INTERFACES OR CALCULATE ALL THE MOVEMENT IN UPDATE INSTEAD, GOES HAYWIRE AS IS 
    //
    private CharacterInformation charInfo;
    private Rigidbody rb;
    [SerializeField] private Vector3 _gravity = new Vector3(0, -1, 0);
    private const int _MULTIPLIER = 1000;
    private void Start()
    {
        charInfo = GetComponent<CharacterInformation>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!CheckIfGrounded())
        {
            Vector3 newVel = new Vector3(rb.velocity.x, _gravity.y,rb.velocity.z);
            rb.velocity = newVel * Time.deltaTime * _MULTIPLIER;
        }
    }
    private bool CheckIfGrounded()
    {
        new WaitForFixedUpdate();
        //first check so we aint climbing!
        Ray ray = new Ray(transform.position, Vector3.down);
        bool didRayHit = Physics.Raycast(ray, out RaycastHit hit);
        if (didRayHit && ((hit.point - transform.position)).magnitude > charInfo._characterHeight / 2) //gives wack null ref error
        {
            return false;
        }
        return true;
    }
    public void OnMoving(InputValue c)
    {
        Vector2 normDirection = c.Get<Vector2>().normalized;
        Vector3 direction = new Vector3(normDirection.x, 0, normDirection.y);
        rb.velocity = direction * charInfo._movementSpeed * Time.deltaTime * _MULTIPLIER;
    }

    public void OnJumpClimb()
    {
        if (!CheckIfGrounded())
        {
            return;
        }
        //if close to climbing area
        //else this
        Debug.Log(rb.velocity);
        Vector3 directionVector = new Vector3(rb.velocity.x, charInfo._jumpSpeed * Time.deltaTime * _MULTIPLIER, rb.velocity.z);
        rb.velocity = directionVector;
        Debug.Log(directionVector);
    }
    public void OnGraffitiClean(InputAction.CallbackContext c)
    {
        if (charInfo._character == CharacterENUM.MORT)
        {
            //test do clean
        }
        else
        {
            //test do graffiti
        }
    }
    public void OnPowerUp(InputAction.CallbackContext c)
    {
        if (charInfo._character == CharacterENUM.MORT)
        {

        }
        else
        {

        }
    }
}
