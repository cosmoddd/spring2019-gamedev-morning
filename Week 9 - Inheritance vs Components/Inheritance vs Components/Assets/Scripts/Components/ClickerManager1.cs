using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerManager1 : MonoBehaviour
{
    // static means "GLOBAL", ANY script can access this
    public static ClickerManager1 instance;

    // "static" alsmo means it lives in the code, not in the scene

    public int myScore = 0;

    void Start()
    {
        instance = this; // "I AM THE SINGLETON".  "NO OTHERS.  ONLY ME." 
    }
    
    void Update()
    {
        if (myScore > 30)
        {
            Debug.Log("YOU WIN...?");
        }
    }
}
