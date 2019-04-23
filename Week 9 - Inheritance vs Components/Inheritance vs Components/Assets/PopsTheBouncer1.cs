using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopsTheBouncer1 : GrandmaSpinner1
{
    public float amplitude = 1f;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Spin();
        BounceToTheOunce();
    }

    public void BounceToTheOunce()
    {
        Vector3 bounceOffset = Vector3.up * Mathf.Sin(Time.time * 2f) * amplitude;
        transform.position= startPos+bounceOffset;
    }

}
