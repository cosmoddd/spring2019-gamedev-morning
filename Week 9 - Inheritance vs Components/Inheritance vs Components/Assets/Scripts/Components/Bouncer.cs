using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
	public Spinner spinner;
    public float amplitude = 0.5f;
	Vector3 startPos; // var for remembering where object started, before hovering

	void Start ()
	{	// remember where the object started, before we start hovering
		startPos = transform.position;
	}
	
	void Update () {
		// move the object and hover?
		// *2f (frequency)... *0.5f (amplitude)
		Vector3 bounceOffset = Vector3.up * Mathf.Sin(Time.time * 2f) * amplitude;
		transform.position = startPos + bounceOffset;
	}

}
