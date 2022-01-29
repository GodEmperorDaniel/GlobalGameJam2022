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
    [SerializeField] private Vector3 _gravity = new Vector3(0, -5, 0);
    private const int _MULTIPLIER = 200;

    private Vector3 _moveVec;
    private bool _isJumping = false;
    private bool _canClimb = false;
    private bool _isClimbing = false;
    private Coroutine c_jumpCooldown;

    WallDetector wallDetector = new WallDetector();

    private void Start()
    {
        charInfo = GetComponent<CharacterInformation>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (charInfo.es.isActiveAndEnabled) return;
        Vector3 newVel = Vector3.zero;
        if (_isClimbing) //climbing
        {
                Debug.Log("we clibing");
            if (_moveVec.magnitude > 0.1f)
            {
                newVel = new Vector3(0, charInfo._climbSpeed);
            }
        }
        else if (!CheckIfGrounded()) //falling
        {
            newVel = new Vector3(_moveVec.x, _gravity.y, _moveVec.z);
        }
        else //moving and or jumping
        {
            //Debug.Log(_isJumping);
            newVel = new Vector3(_moveVec.x, _isJumping ? charInfo._jumpSpeed : 0, _moveVec.z);
        }
        rb.velocity = newVel * Time.fixedDeltaTime * _MULTIPLIER;
    }
    private bool CheckIfGrounded()
    {
        if (_isClimbing)
        {
            return false;
        }
        Ray ray = new Ray(transform.position, Vector3.down);
        bool didRayHit =Physics.SphereCast(ray, 1, out RaycastHit hit);
        //bool didRayHit = Physics.Raycast(ray, out RaycastHit hit);
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
        _moveVec = direction * charInfo._movementSpeed;
    }

    public void OnJumpClimb()
    {
        if (!CheckIfGrounded())
        {
            return;
        }
        //if close to climbing area
        if (_canClimb && !_isClimbing)
        {
            _isClimbing = true;
            return;
        }
        else if (c_jumpCooldown == null)
        {
            _isJumping = true;
            c_jumpCooldown = StartCoroutine(JumpCooldown());
        }
        else
        {
            _isClimbing = false;
        } 
    }
    private IEnumerator JumpCooldown()
    {
        _gravity = Vector3.zero;
        yield return new WaitForSeconds(charInfo._jumpDuration);
        _gravity = new Vector3(0, -5, 0);
        while (!CheckIfGrounded())
        {
            yield return null;
        }
        _isJumping = false;
        yield return new WaitForSeconds(charInfo._jumpCooldown);
        c_jumpCooldown = null;
    }
    public void OnGraffitiClean(InputValue c) //might not be able to do callback context, just check information in controller scheme?
    {
        if (charInfo._character == CharacterENUM.MORT)
        {
            //test do clean
            wallDetector.interactingWithWall(transform, ref c, charInfo._character);
        }
        else
        {
            //test do graffiti
            wallDetector.interactingWithWall(transform, ref c, charInfo._character);
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Climbable"))
        {
            _canClimb = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Climbable"))
        {
            _canClimb = false;
            _isClimbing = false;
        }
    }
}
