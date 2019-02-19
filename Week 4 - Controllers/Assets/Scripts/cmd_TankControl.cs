using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmd_TankControl : MonoBehaviour
{

    public Rigidbody rigidBody;
    public Vector2 inputVector;
    public float forceMultiplier = 5;
    public float torqueMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        float inputVertical = Input.GetAxis("Vertical");
        float inputHorizontal = Input.GetAxis("Horizontal");


        inputVector = new Vector2 (inputHorizontal, inputVertical);


        // if (Input.GetButton("Horizontal") &&  Input.GetAxis("Horizontal") < 0)
        //     {
        //         this.transform.Rotate(Vector3.up * -torqueMultiplier);
        //     }
        // if (Input.GetButton("Horizontal") &&  Input.GetAxis("Horizontal") > 0)
        //     {
        //         this.transform.Rotate(Vector3.up * torqueMultiplier);
        //     }
    }

    void FixedUpdate()
    {
        if (rigidBody.velocity.magnitude < 4f)
        {
            rigidBody.AddForce(transform.forward * inputVector.y * forceMultiplier, ForceMode.Impulse);
        }

        rigidBody.AddTorque(0, inputVector.x * torqueMultiplier, 0, ForceMode.VelocityChange);
    }
}
