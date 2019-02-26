using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usage: put this on your Main Camera (+ make sure it's tagged as MainCamera)
// intent: move a sphere around based on mouse cursor raycast
public class cmd_RaycastMouse : MonoBehaviour
{
	// the sphere we are moving / controlling
	public Transform thisCube; // assign in Inspector
	public bool makePinWheel;
    public GameObject canvas;

	// Update is called once per frame
	void Update () {



		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);  // ScreenPointToRay is *essential* for doing raycast with mouse
		
		// STEP 2: define the maximum raycast distance
		float maxRaycastDist = 1000f; // just a big number to catch whatever
		
		// STEP 2B: define a RaycastHit variable
		RaycastHit myRayHit = new RaycastHit(); // blank, will fill it later
		
		// STEP 3: visualize the raycast!! (optional)
		Debug.DrawRay(mouseRay.origin, mouseRay.direction * maxRaycastDist, Color.yellow);
		
		// STEP 4: shoot the raycast!!!
		if (Physics.Raycast(mouseRay, out myRayHit, maxRaycastDist))
		{
			// if true, if we hit the wall, move the sphere there
			thisCube.position = myRayHit.point; // point = worldPos of impact
			
			// what if wanted the tag of the thing we hit?
			Debug.Log( myRayHit.collider.tag );
			
			// what if we wanted to access the object we hit?
			myRayHit.transform.Rotate(0f, 1f, 0f); // demo: rotate the thing we hit
			
			// INSTANTIATION: cloning an object during the game
			// myRayHit.point = the position of the new clone
			// Quaternion.Euler() = the rotation of the new clone
			if (Input.GetMouseButton(0)) // 0 = left-click
			{
				Transform instantiatedCube = Instantiate(thisCube, myRayHit.point, Quaternion.Euler(0, 0, 0));

                // Step 5 BONUS (PINWHEEL)

                if (makePinWheel)
                {
                    instantiatedCube.SetParent(canvas.transform, true);
                }
			}
		}
	}
}
