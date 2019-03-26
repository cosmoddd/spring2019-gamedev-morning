using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public Vector3 swimDestination;     // where's the fish going?
    public float speed;                 // how fast is it going?

    void Start()
    {
        // once you really get going w the spawning of fish
        swimDestination = new Vector3(Random.Range(-10f,10f),
                                  Random.Range(-10f, 10f),
                                  Random.Range(-10f, 10f));
    }

    void Update()
    {

        // the fish always swims towards its destination
        this.transform.position = Vector3.MoveTowards(this.transform.position,  // set the destionation
                                                    swimDestination, 
                                                    speed *Time.deltaTime);
        
        // tell the fish to look at the destination
        transform.LookAt(swimDestination); 
        
        // draw the debug line!
        Debug.DrawLine(this.transform.position, swimDestination, Color.yellow); 

        // when you reach the destination... find a new point.

        // DON'T DO THIS
        //		if (transform.position == destination)

        // anyway... let's find the new point:
        if (Vector3.Distance(this.transform.position, swimDestination) < 2) // once we're pretty close...
        {
            swimDestination = new Vector3( Random.Range(-10f,10f),
                                            Random.Range(-10f, 10f),
                                            Random.Range(-10f, 10f));     // find a new location in 3d space!
        }

        // alternate way to move...
		// move forward AFTER you look at your destination
        // transform.Translate(0,0, speed * Time.deltaTime);   // always moving forward wherever you look

    }
}
