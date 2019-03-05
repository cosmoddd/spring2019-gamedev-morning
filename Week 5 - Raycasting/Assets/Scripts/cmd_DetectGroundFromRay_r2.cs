using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmd_DetectGroundFromRay_r2 : MonoBehaviour
{
    public float rayDistance = 2;

    void Update()
    {
        Ray myRay = new Ray(this.transform.position, Vector3.down);

        Debug.DrawRay(myRay.origin, new Vector3(0, 0, rayDistance), Color.red);

        RaycastHit myHit;

        if (Physics.Raycast(myRay.origin, myRay.direction, out myHit, rayDistance))
        {
            print("This roomba hit a "+myHit.rigidbody.transform.name);
        }

    }    

}
