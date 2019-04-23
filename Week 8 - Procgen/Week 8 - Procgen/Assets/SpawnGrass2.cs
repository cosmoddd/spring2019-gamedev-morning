using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrass2 : MonoBehaviour
{
    public GameObject grassPrefab;
    public int grassLimit = 200;

    void Start()
    {
        int i = 0; // define the counter

        while (i < grassLimit)
        {
            // create the Vector3 'pointer' where the the grass will spawn
            Vector3 spawnPoint = new Vector3(Random.Range(-5f,5f), 0.5f, Random.Range(-5f,5));

            // actually instantiate the grass!
            Instantiate (grassPrefab, spawnPoint, Quaternion.Euler(0, Random.Range(0, 360f), 0));

            // count up (prevents breaking Unity)
            i++;
        } 
    }

}
