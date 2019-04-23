using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaSpinner1 : MonoBehaviour
{

    void Update()
    {
        Spin();
    }

    public void Spin()
    {
        transform.Rotate(90f * Time.deltaTime,0f, 0f);
    }

}
