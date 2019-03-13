using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastKnock : MonoBehaviour
{

    RaycastHit hit;
    public AudioSource thisAudioSource;
    public GameObject hitObject;
    public AudioClip elevatorMusic;

    void FixedUpdate()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f))
        {
            hitObject = hit.transform.gameObject;
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.transform.gameObject.tag == "Door")
                {
                    print("Play sounds");
                    thisAudioSource.Play();
                    hitObject.gameObject.GetComponent<AudioSource>().Stop();    // stops sound
                    hitObject.gameObject.GetComponent<AudioSource>().clip = elevatorMusic;    // replace w elevator music
                    hitObject.gameObject.GetComponent<AudioSource>().Play();    // play elevator music

                    
                }
            }
        }
    }
}
