using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmd_RaycastRoomba : MonoBehaviour
{

    public float maxDistance = .5f;
    public float roombaSpeed = 1f;

    void Update()
    {

        // 1 define the ray
        Ray roombaRay = new Ray(this.transform.position, this.transform.forward);

        // 2 define the max distance

        // 3 draw debug

        Debug.DrawRay(roombaRay.origin, roombaRay.direction * maxDistance, Color.red);

        RaycastHit roombatHit;

        if (Physics.Raycast(roombaRay.origin, roombaRay.direction, out roombatHit, maxDistance))
        {
            int randomNumber = Random.Range(1,100);

            if (randomNumber < 50)
            {
                this.transform.Rotate(0,-90,0);
            }
        
           if (randomNumber >= 50)
            {
                this.transform.Rotate(0,90,0);
            }        
        }

        else
        {
            transform.Translate(0, 0, Time.deltaTime * roombaSpeed);
        }
    }
}
