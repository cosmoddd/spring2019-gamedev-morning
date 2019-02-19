using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmd_TankControl_r1 : MonoBehaviour
{
    Rigidbody thisRigidBody;

    public float verticalAmount;
    public float horizontalAmount;

    public float forceSpeed=3f;
    public float torqueSpeed = .5f;

    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();      ///  GetComponent< type of component that you want > ();
    }

    void Update()
    {
        verticalAmount = Input.GetAxis("Vertical");
        horizontalAmount = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if (thisRigidBody.velocity.x < 3)
            thisRigidBody.AddForce(transform.forward * verticalAmount * forceSpeed, ForceMode.Impulse);

        thisRigidBody.AddTorque(0, horizontalAmount * torqueSpeed, 0, ForceMode.VelocityChange);
    }
}
