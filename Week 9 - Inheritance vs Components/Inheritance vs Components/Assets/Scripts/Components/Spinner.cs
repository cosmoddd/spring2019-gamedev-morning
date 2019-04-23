using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
	void Update () {

            // Time.deltaTime is the duration of the frame in seconds
            // spin 90 degrees per second on the X axis
            transform.Rotate(90f * Time.deltaTime, 0f, 0f);

	}


}
