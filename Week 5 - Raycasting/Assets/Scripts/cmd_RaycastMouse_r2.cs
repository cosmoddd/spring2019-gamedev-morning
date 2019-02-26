using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmd_RaycastMouse_r2 : MonoBehaviour
{
    public float cameraRayDistance = 1000f;

    public Transform paintCube;

    public bool pinWheelMode;

    void Update()
    {
        // 1 declare the ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // 2 draw it
        Debug.DrawRay(ray.origin, ray.direction * cameraRayDistance, Color.red);

        RaycastHit raycastHit;// = new RaycastHit();

        // RAYCAST FORMULA:  (ORIGIN, DIRECTION, HIT INFO (USEFUL STUFF), DISTANCE LENGTH)

        if (Physics.Raycast(ray.origin,ray.direction, out raycastHit, cameraRayDistance))
        {
            paintCube.transform.position = raycastHit.point;    // sets the paintCube to the point in the position

            print("We hit something with the "+ raycastHit.transform.tag + " tag!!!");  // gets the tag of the thing that got hit.

            if (raycastHit.transform.tag == "Clean On Your Bean")  // if raycast its... do something w tag
            {
                raycastHit.transform.Rotate(0,1,0);

            }

            if (Input.GetMouseButton(0)) // standard left click.  will spawn a lot of cubes
            {
                Transform newCube = Instantiate(paintCube, paintCube.transform.position, Quaternion.Euler(0,0,0)); // don't worry about quats for now.

                if (pinWheelMode)
                {
                    newCube.SetParent(raycastHit.transform.gameObject.transform, true);
                }
            }


        }
    }
}
