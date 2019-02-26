using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entered : MonoBehaviour
{

    public GameObject hintText;

    void Start()
    {
        if (hintText)
            {hintText.SetActive(false);}
    }

    void OnTriggerEnter(Collider c)
    {
        print("Something entered this trigger.  Whoop-de-doo. A "+c.transform.name);
        hintText.SetActive(true);
    }
}
