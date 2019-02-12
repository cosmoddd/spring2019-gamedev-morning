using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapePhysics : MonoBehaviour
{
    public Queue funky;
    public GameObject thisGameObject;
    public Rigidbody objectPhysics;
    public float forceMultiplier = 5f;
    // Start is called before the first frame update
    void Start()
    {  
       thisGameObject = this.gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetButton("Input1"))
        {
            objectPhysics.AddForce( Vector3.up * forceMultiplier, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.E))
        {
            objectPhysics.AddForce( Vector3.forward * forceMultiplier, ForceMode.Force);
        }

    }

}
