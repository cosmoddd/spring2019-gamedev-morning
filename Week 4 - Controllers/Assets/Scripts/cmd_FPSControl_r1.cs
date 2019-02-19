using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmd_FPSControl_r1 : MonoBehaviour
{

    Rigidbody thisRigidBody;

    public Vector3 inputVelocity;
    public float moveSpeed = 2f;

    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();  // tells the script which rigidbody to act on.
    }

    void Update()
    {
        
        float pitch;

        pitch = Input.GetAxis("Mouse X");
        this.transform.Rotate(0,pitch,0);

        float yaw;
        
        yaw = Input.GetAxis("Mouse Y");
        Camera.main.transform.Rotate(-yaw,0,0);

        float fPSForwardBackward;
        float fPSStrafe;

        fPSForwardBackward = Input.GetAxis("Vertical");
        fPSStrafe = Input.GetAxis("Horizontal");

        inputVelocity = transform.forward * fPSForwardBackward;
        inputVelocity += transform.right * fPSStrafe;

    }

    void FixedUpdate()
    {
        thisRigidBody.velocity = inputVelocity * moveSpeed + Physics.gravity * .69f;// Physics.gravity
    }
}
