using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on a different Sphere, assign variables
// PURPOSE: show a more complicated tween, using curves
public class JuicyCoroutine : MonoBehaviour
{
    // assign in Inspector!
    public Transform sphere, cube;

    // public means we can edit the animation curve in the inspector
    public AnimationCurve animationCurve;
    
    void Start()
    {
        StartCoroutine(JuicyTweenCurve());
    }

    // always declare couritnes w the IEnumerator 
    IEnumerator JuicyTweenCurve()
    {
        yield return null;  // IEnumerator must ALWAYS return SOMETHING (even if it's nothing)

        // setup the variables in the coroutine before we start tweening

        float t = 0f; // "t" = time.  like a counter variable
        Vector3 startPos = sphere.transform.position; // start position is the position of the ball
        Vector3 endPos = cube.transform.position; // end position is the position of the cube

        while (t < animationCurve[animationCurve.keys.Length-1].time) // as long as t is less than 100%, keep repeating this curve
        {
            sphere.position = Vector3.LerpUnclamped(

                startPos,  // go from the start position
                endPos,     // to the end position
                animationCurve.Evaluate(t) // during the point on the curve at the given point in time.  NICE!  JUICY!

            );
            t += Time.deltaTime;  // need to manually add more time to T based on time.detlatime so that we can move forward in the process.
            yield return null;  // pause for 1 frame.  if you don't do this, the while loop will get caught up in itself.  BAD!
        }


    }

//         while (t < animationCurve[animationCurve.keys.Length-1].time) // as long as t is less than 100%, keep repeating this curve
//              ^-- dynamic way of getting length of the curve, man.

}
