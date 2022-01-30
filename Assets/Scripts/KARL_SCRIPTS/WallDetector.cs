using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class WallDetector
{
    //public void FixedUpdate()
    //{
    //    interactingWithWall(this.transform);
    //}
    public void interactingWithWall(Transform tran, ref InputValue c, CharacterENUM _character) //
    {
        int contactDistance = 2;
        int layerMask = 1 << 6;
        Ray ray = new Ray(tran.position, tran.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, contactDistance, layerMask))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            if (_character == CharacterENUM.MORT)
                CallCleaning(hit, c);
            else
                CallGrafitti(hit, c);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        }
    }

    private void CallGrafitti(RaycastHit hit, InputValue c)
    {
        Graffiting graffiting = hit.collider.gameObject.GetComponent(typeof(Graffiting)) as Graffiting;
        if (graffiting != null)
        {
            graffiting.startFadeIn(c);
            //Debug.Log("TRÄFF");
        }
        else
        {
            Debug.Log("Hittar inte graffiting");
        }
    }
    private void CallCleaning(RaycastHit hit, InputValue c)
    {
        Graffiting graffiting = hit.collider.gameObject.GetComponent(typeof(Graffiting)) as Graffiting;
        if (graffiting != null)
        {
            graffiting.startFadeOut(c);
            //Debug.Log("TRÄFF");
        }
        else
        {
            Debug.Log("Hittar inte graffiting");
        } 
    }
}
