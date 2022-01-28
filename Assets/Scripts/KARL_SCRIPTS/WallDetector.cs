using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        interactingWithWall();
    }
    // Update is called once per frame

    private void interactingWithWall()
    {
        int layerMask = 6 << 8;

        layerMask = ~layerMask;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            print("There is something in front of the object! " + hit.ToString());
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        }
        


    }
    

}
