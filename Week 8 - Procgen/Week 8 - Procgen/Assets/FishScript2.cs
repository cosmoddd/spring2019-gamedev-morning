using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript2 : MonoBehaviour
{

    public Vector3 swimDestination;
    public float speed = 3f;

    void Start()
    {
        FindNewDestination();
    }

    // code for finding new swim destination
    void FindNewDestination()
    {
        swimDestination = new Vector3(Random.Range(-10f, 10), Random.Range(-10f,10f), Random.Range(-10f, 10f));
    }

    void Update()
    {
        // move towards destination
        this.transform.position = Vector3.MoveTowards(this.transform.position, swimDestination, speed * Time.deltaTime);

        // tell fish to look at destination
        this.transform.LookAt(swimDestination);

        // draw the debug line
        Debug.DrawLine(this.transform.position, swimDestination, Color.yellow);

        // when you reach the destination, find a new point

        if (Vector3.Distance(this.transform.position, swimDestination) < 2)
        {
                FindNewDestination();
        }
        

    }
}
