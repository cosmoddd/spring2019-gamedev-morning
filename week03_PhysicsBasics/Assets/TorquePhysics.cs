using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorquePhysics : MonoBehaviour
{

    public GameObject thisGameObject;
    public Rigidbody objectPhysics;
    public float torqueMultiplier = 10f;
    // Start is called before the first frame up

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            objectPhysics.AddTorque( Vector3.up * torqueMultiplier, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.T))
        {
            objectPhysics.AddTorque( Vector3.down * torqueMultiplier, ForceMode.Force);
        }
    }
}
