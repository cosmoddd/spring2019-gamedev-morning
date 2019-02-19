using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usage: put this on a Cube with a Rigidbody
// intent: this is a Rigidbody-based Player controller for a boat? car?
public class RigidbodyVehicle : MonoBehaviour
{

	Rigidbody rbody;
	Vector2 inputVector; // x is horizontal, y is vertical input

	// Use this for initialization
	void Start ()
	{
		rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// input handling
		
		// Input.GetAxis() returns a float between -1f and 1f, and 0 if nothing is happening
		// horizontal = A/D, Left/Right... Left = -1f, Right = +1f
		float horizontal = Input.GetAxis("Horizontal");
		// vertical = W/S, Up/Down... Up = +1, Down = -1f
		float vertical = Input.GetAxis("Vertical");
		
		// put input values into the inputVector, for FixedUpdate
		inputVector = new Vector2(horizontal, vertical);
	}

	// FixedUpdate runs every physics frame
	// to change physics framerate, go to Edit > Project Settings > Time
	void FixedUpdate()
	{
		// forward / backward thrust
		if (rbody.velocity.magnitude < 4f) // how fast are we going? if too fast, don't speed up
		{
			rbody.AddForce(transform.forward * inputVector.y * 2f, ForceMode.Impulse);
		}

		// left/right turning... torque is rotational force
		rbody.AddTorque( 0f, inputVector.x * 15f, 0f, ForceMode.VelocityChange);
	}
	
	
}