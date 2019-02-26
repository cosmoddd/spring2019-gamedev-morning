using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPHSX : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float forceVariable;

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidBody.AddForce(new Vector3(0,1,0) * forceVariable, ForceMode.Force);
        }
    }

}
