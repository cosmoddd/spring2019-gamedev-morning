using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest2 : MonoBehaviour
{
    // Start is called before the first frame update
        Rigidbody thisRigidbody;
        public float thisForce = 5;

    void Start()
    {
       thisRigidbody  = GetComponent<Rigidbody>();

       StartCoroutine(SlowLoop());
    }

    IEnumerator CountDownLaunch()
    {
        print("Countdown timer in 5...");

        yield return new WaitForSeconds(1f);

        print("4...");

        yield return new WaitForSeconds(1f);

        print("3...");

        yield return new WaitForSeconds(1f);

        print("2...");

        yield return new WaitForSeconds(1f);        

        print("1...");

        yield return new WaitForSeconds(1f);    

        thisRigidbody.AddForce(Vector3.up * thisForce, ForceMode.Impulse);
    }

    IEnumerator SlowLoop()
    {
        for (int i = 0; i < 10; i ++)
        {
            print("We go through the sloooooow loop.  We're currently at... " + i);
            yield return new WaitForSeconds(1f);
        }

    }

}
