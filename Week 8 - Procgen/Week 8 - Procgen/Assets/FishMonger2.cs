using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMonger2 : MonoBehaviour
{
    // references the fish prefab
    public GameObject fishPrefab;

    // a list of all our spawned fish clones  -- a dynamic list will be key
    public List<GameObject> fishClones = new List<GameObject>();

    void Start()
    {
        int i = 0;
        while (i < 100)
        {
            GameObject newFish = Instantiate(fishPrefab, new Vector3 (Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)), Quaternion.identity);

            fishClones.Add(newFish);
            i++;
        }
    }

    void Update()
    {
        // press x, all the fish go to the center
        if (Input.GetKeyDown(KeyCode.X))
        {
            for (int i = 0; i < fishClones.Count; i++)
            {
                fishClones[i].GetComponent<FishScript2>().swimDestination = Vector3.zero;
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            foreach (GameObject fishClone in fishClones)
            {
                fishClone.transform.localScale = Vector3.Normalize(fishClone.transform.localScale) 
                                                * Random.Range(.5f, 2f) *2f;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            foreach (GameObject fishClone in fishClones)
            {
                fishClone.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            }
        }
    }
}
