using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmd_TankControl_r2 : MonoBehaviour
{

    public Rigidbody thisRigidBody; // variable for our rigidbody
    public Vector2 inputAxis;       // input axes for controlling rigidbody
    public float tankVelocity;      // velocity of the tank
    public float forceMultiplier;   // scale the force of the tank
    public float torqueMultiplier;  // scale the torque of the tank

    public float inputToTorque;     // assigns input to a torque

    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();  
    }

    
    void Update()
    {
        inputAxis.y = Input.GetAxis("Vertical");
        inputAxis.x = Input.GetAxis("Horizontal");

        inputToTorque = inputAxis.x;    // turns input axis into variable to feed into Torque control

    }

    void FixedUpdate()
    {
        tankVelocity = thisRigidBody.velocity.magnitude;

        if(thisRigidBody.velocity.magnitude < 8f)
        {
            thisRigidBody.AddForce(transform.forward * inputAxis.y * forceMultiplier, ForceMode.Impulse);
        }

        thisRigidBody.AddTorque(0, inputToTorque * torqueMultiplier, 0, ForceMode.VelocityChange);
    }

}
