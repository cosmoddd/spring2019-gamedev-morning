using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenPrint2 : MonoBehaviour
{
    public Transform[] generators;
    
    
    void Start()
    {

        for(int verticalCount = 0; verticalCount < 10; verticalCount++) 
        {
            for (int horizontalCount = 0; horizontalCount < 10; horizontalCount++)
            {
                // generates the positionin the grid (creating 50x50 grid)
                Vector3 spawnPosition = new Vector3 (horizontalCount *5, verticalCount*5, 0);

                // instantiate a random prefab from array
                int randomPrefabIndex = Random.Range(0, generators.Length);

                // create the prefab
                
                Transform newClone = Instantiate(generators[randomPrefabIndex], spawnPosition, generators[randomPrefabIndex].rotation);

                newClone.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            }
        }   

    }


}
