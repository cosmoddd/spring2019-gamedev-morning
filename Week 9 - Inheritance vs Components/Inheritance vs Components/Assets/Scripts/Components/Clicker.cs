using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    // OnMouseDown tells Unity to fire a raycast based on your mouse cursor
	// big flaw with OnMouseDown: doesn't tell you where you clicked / no RaycastHit

	void OnMouseDown()
	{
		// enlarge this object by 105%
		transform.localScale *= 1.05f;
		
		// access the static game manager and add a point
        ClickerManager1.instance.myScore += 1;
        
	}

}
