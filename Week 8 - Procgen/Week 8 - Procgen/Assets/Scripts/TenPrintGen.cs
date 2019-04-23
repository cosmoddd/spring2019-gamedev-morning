using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenPrintGen : MonoBehaviour
{
    
    public Transform[] generators;
    void Start()
    {
    for (int vCount = 0; vCount < 10; vCount++ )
    {
        for (int hCount = 0; hCount < 10; hCount++)
        {
            // generates the position in the grid (ultimately creating a 50x50 grid)
            Vector3 spawnPosition = new Vector3 (hCount*5, vCount*5, 0);

            // instantiate a random prefab from an array
            int randomPrefabIndex = Random.Range(0, generators.Length);

            // create the new prefab now
            Transform newClone = Instantiate(generators[randomPrefabIndex], 
                                                spawnPosition,
                                                generators[randomPrefabIndex].rotation);   
                                                // keep the rotation attached


            // // randomly scale 50-200%?
            // newClone.localScale *= Random.Range(0.5f, 2f);

            // random color for each object?
            newClone.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();

        }
    }
    }
}
