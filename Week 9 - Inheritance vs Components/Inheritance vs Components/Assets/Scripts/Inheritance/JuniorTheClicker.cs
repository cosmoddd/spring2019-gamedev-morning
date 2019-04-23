using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuniorTheClicker : PopsTheBouncer
{
	void Update()
    {
        Spin();
        Bounce();
    }
    
    
    // OnMouseDown tells Unity to fire a raycast based on your mouse cursor
	// big flaw with OnMouseDown: doesn't tell you where you clicked / no RaycastHit

	void OnMouseDown()
	{
		// enlarge this object by 105%
		ClickToEnlarge();
		
		// access the static game manager and add a point
		// ClickerManager.instance.myScore += 1;
		// notice: I don't need GetComponent or a public var
	}

    void ClickToEnlarge()
    {
		// enlarge this object by 105%
		transform.localScale *= 1.05f;
    }

}
