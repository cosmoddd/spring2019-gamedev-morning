using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{

    void OnTriggerEnter(Collider c)
    {
        print("A collider entered this place");
    }


}
