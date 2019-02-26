using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{
    public GameObject movingObject;
    public float force = 5f;
    public float torque  = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))         // MOVE FORWARD WHEN YOU HIT "W" KEY
        {
            movingObject.transform.Translate(Vector3.forward * Time.deltaTime * force);
        }

        if (Input.GetKey(KeyCode.S))        // MOVE BACKWARDS WHEN YOU HIT "S" KEY
        {
            movingObject.transform.Translate(Vector3.back * Time.deltaTime * force);
        }

        if (Input.GetKey(KeyCode.A))            // ROTATE LEFT WHEN YOU HIT "A" KEY
        {
            movingObject.transform.Rotate(new Vector3 (0,-1,0) * Time.deltaTime * torque);
        }

        if (Input.GetKey(KeyCode.D))            // ROTATE RIGHT WHEN YOU HIT "D KEY
        {
            movingObject.transform.Rotate(new Vector3 (0,1,0) * Time.deltaTime * torque);
        }

    }
}
