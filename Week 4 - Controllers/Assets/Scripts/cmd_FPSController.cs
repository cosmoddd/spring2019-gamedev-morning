using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmd_FPSController : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody thisRigidBody;

    public float moveSpeed;

    public float fpForward;
    public float fpStrafe;

    public Vector3 inputVector;
    public Vector3 outputVector;

    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float pitch = Input.GetAxis("Mouse X");
        float yaw = Input.GetAxis("Mouse Y");

        this.transform.Rotate(0, pitch, 0);         // effects camera pitch
        Camera.main.transform.Rotate(-yaw, 0, 0);    // effect camera yaw

        fpForward = Input.GetAxis("Vertical");
        fpStrafe = Input.GetAxis("Horizontal");
    
        inputVector = transform.forward * fpForward;
        inputVector += transform.right * fpStrafe;
    }

    // physics update
    void FixedUpdate()
    {
        // thisRigidBody.AddRelativeForce(0, 0, fpForward, ForceMode.Impulse);
        // thisRigidBody.AddRelativeForce(fpStrafe, 0, 0, ForceMode.Impulse);
    
        thisRigidBody.velocity = inputVector * moveSpeed + (Physics.gravity * 0.69f);

        outputVector = thisRigidBody.velocity;
    }
}
