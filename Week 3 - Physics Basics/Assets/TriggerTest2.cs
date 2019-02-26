using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest2 : MonoBehaviour
{

    public Camera camera2;

    void OnCollisionEnter(Collision c)
    {
        print(c.transform.name + " entered this object.");

        camera2.enabled = true;
    }

}
