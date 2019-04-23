using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuniorTheClicker1 : PopsTheBouncer1
{
    void Update()
    {
        Spin();
        BounceToTheOunce();
    }

    void OnMouseDown()
    {
        ClickToEnlarge();
    }

    void ClickToEnlarge()
    {
        transform.localScale *= 1.05f;
    }
}
