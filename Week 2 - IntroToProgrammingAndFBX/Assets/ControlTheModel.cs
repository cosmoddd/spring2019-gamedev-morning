using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTheModel : MonoBehaviour
{

    public GameObject weirdObject;  // THIS IS THE OBJECT I WANT TO MOVE
    public float speed;
    public float torque;

    void Update()       // MY INPUT COMMANDS GO HERE
    {
        if (Input.GetKey(KeyCode.W))
        {
            weirdObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            weirdObject.transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            weirdObject.transform.Rotate((new Vector3(0,-1,0)) * Time.deltaTime * torque);
        }

        if (Input.GetKey(KeyCode.D))
        {
            weirdObject.transform.Rotate((new Vector3(0,1,0)) * Time.deltaTime * torque);
        }

    }
}
