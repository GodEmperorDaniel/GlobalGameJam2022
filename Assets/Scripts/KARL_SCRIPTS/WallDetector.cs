using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class WallDetector : MonoBehaviour
{
    //public LayerMask mask;
    //public int contactDistance;
    
    //private void FixedUpdate()
    //{
    //    interactingWithWall();
    //}
    // Update is called once per frame

    public void interactingWithWall(Transform tran)
    {
        int contactDistance = 2;
        int layerMask = 1 << 6;
        layerMask = ~layerMask;
        Ray ray = new Ray(tran.position, tran.forward);
        RaycastHit hit;

        Vector3 fwd = this.transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(ray, out hit, contactDistance, layerMask))
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
        hit.collider.gameObject.SendMessage("startFadeIn"); 
    }
}
