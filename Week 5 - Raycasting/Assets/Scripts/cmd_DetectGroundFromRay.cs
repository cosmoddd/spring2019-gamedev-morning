using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmd_DetectGroundFromRay : MonoBehaviour
{

    public float rayDistance = 5;
    
    void Update()
    {
        Ray raycastCMD = new Ray(this.transform.position, Vector3.down);        // Initialize and fire raycast EVERY FRAME.  RAYS!!

        Debug.DrawRay(raycastCMD.origin, new Vector3(0, -rayDistance, 0), Color.red);   // Draw the raycast downward as far as the rayDistance.
                                                                                        //  Purely for visual feedbac.

        if (Physics.Raycast(raycastCMD, rayDistance))       // Tests the raycast against the target.
        {
            print("The raycast is hitting stuff");
            transform.Rotate(0,0,0);   // stop rotating the cube    

        }

        else 
        {
            transform.Rotate(0,2,0);   // rotate the cube otherwise
        }
    }
}
