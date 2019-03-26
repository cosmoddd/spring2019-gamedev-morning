using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrass : MonoBehaviour
{

    public GameObject grassPrefab;       // 1) prefab to spawn the grass
    public int grassLimit = 200;         // 2) how much grass to we spawn?

    void Start()
    {
        int i = 0;  // define the counter
        
        while (i < grassLimit)  // init the while loop
        {
            //  create the Vector3 'pointer' where the grass will spawn
            Vector3 spawnPoint = new Vector3(Random.Range(-5f,5f),     // define at the x     
                                            .5f,                   // define at the y
                                            Random.Range(-5f,5f)); // define at the z
        

        
            Instantiate(grassPrefab, spawnPoint, Quaternion.Euler(0, Random.Range(0,359f), 0)); // atually spawn it!  (and rotate it)
            i++;    // increase the counter to advance the spawn (and to avoid crashing on an infinite loop)
        }
        

    }

   
}
