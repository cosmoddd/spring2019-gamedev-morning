using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on a Sphere, assign the Cube too
// INTENT: demo a JUICY way to move Sphere towards a Cube
public class JuicyDemo : MonoBehaviour
{

    // assign in Inspector
    public Transform sphere, cube;

    void Update()
	{	// move 10% of remaining distance, every frame.  JUICY!!!
		sphere.position += (cube.position - sphere.position) * .1f;
	}
}

