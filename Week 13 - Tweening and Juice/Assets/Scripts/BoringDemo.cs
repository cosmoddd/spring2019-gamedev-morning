using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on a Sphere, assign the Cube too
// INTENT: demo a boring way to move Sphere towards a Cube
public class BoringDemo : MonoBehaviour
{

    // assign in Inspector
    public Transform sphere, cube;

    void Update()
    {
        // the boring NOT JUICY way to move the cube
        sphere.position = Vector3.MoveTowards(

            sphere.position,    // starting point
            cube.position,      // target point
            .1f                // rate of movement
        );
    }

        //  BO-RING!
}
