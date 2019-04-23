using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    Rigidbody thisRigidbody;
    public float launchForce;

    void Start()
    {

        thisRigidbody = GetComponent<Rigidbody>();

        StartCoroutine(SlowLoop());
    }


    IEnumerator CountDownLaunch()
    {
        print("Countdown starts in 5...");

        yield return new WaitForSeconds(1f); // tells the coroutine to return  1 
                                            //(basically demarcates a 'step' in the coroutine process determined by length)

        print("4...");        

        yield return new WaitForSeconds(1f); 

        print("3...");  

        yield return new WaitForSeconds(1f); 

        print("2...");          

        yield return new WaitForSeconds(1f); 

        print("1...");      

        yield return new WaitForSeconds(1f); 

        thisRigidbody.AddForce(Vector3.up * launchForce, ForceMode.Impulse);   
    }

    IEnumerator SlowLoop()
    {
        for (int i = 0; i  < 10 ; i++)
        {
            print("We go through the slow loop.  We're at... "+ i);
          yield return new WaitForSeconds(1f);
        }

    }

}
