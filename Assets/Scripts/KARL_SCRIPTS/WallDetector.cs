using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class WallDetector : MonoBehaviour
{
    public LayerMask mask;
    public int contactDistance;
    
    private void FixedUpdate()
    {
        interactingWithWall();
    }
    // Update is called once per frame

    private void interactingWithWall()
    {

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(ray, out hit, contactDistance, mask))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            CallGrafitti(hit);
            print("There is something in front of the object! " + hit.collider.gameObject.name);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        }
    }

    private void CallGrafitti(RaycastHit hit)
    {
        if (Input.GetKey("a"))
        {
            hit.collider.gameObject.SendMessage("startFadeIn");
        }
        
    }
}
