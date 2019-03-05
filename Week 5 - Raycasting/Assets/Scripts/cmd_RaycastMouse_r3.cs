using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmd_RaycastMouse_r3 : MonoBehaviour
{
    public float cameraRayDistance = 40f;

    public Transform paintCube;

    public bool pinWheelMode;

    // Start is called before the first frame update
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(mouseRay.origin, (mouseRay.direction * cameraRayDistance), Color.red);
    
        RaycastHit myHit;

        if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out myHit, cameraRayDistance))
        {
            paintCube.transform.position = myHit.point;

            if (myHit.transform.tag == "Donuts")
            {
                myHit.transform.Rotate(0,1,0);

            }

            if (Input.GetMouseButton(0))
            {
                Transform newCube = Instantiate(paintCube, paintCube.transform.position, Quaternion.Euler(0,0,0));

                if (pinWheelMode)
                {
                    newCube.SetParent(myHit.transform, true);
                }
            }
        }

        else
        {
            paintCube.transform.position = mouseRay.direction;
        }

        

    }
}
