using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMonger : MonoBehaviour
{

    // reference to our fish prefab
    public GameObject fishPrefab;

    // a list of all our spawned fish clones  -- a dynamic list will be important here
    public List<GameObject> fishClones = new List<GameObject>();

    // spawn some new fish!
    void Start()
    {

        int i = 0;
        while (i <100)
        {
            
            GameObject newFish = Instantiate(fishPrefab, new Vector3 (Random.Range(-10f,10f),        // random location
                                                Random.Range(-10f, 10f),
                                                Random.Range(-10f,10f)), 
                                               Quaternion.Euler(0,Random.Range(0,360f), 0));   // random rotation!
        
            fishClones.Add(newFish);
            i++;  // and don't forget this!!

            // could change this to the length of the list, but we'll just leave it as is for now.
        }

    }

    void Update()
    {
        
        // press x to make all fish go to (0,0,0)

        if (Input.GetKeyDown(KeyCode.X))
        {
            // use a for() loop to go through the list
            for (int i = 0; i < fishClones.Count; i++)
            {
                fishClones[i].GetComponent<Fish>().swimDestination = new Vector3(0,0,0);
            }
        }

        // press K to randomly enlarge all the fish
        if (Input.GetKeyDown(KeyCode.K))
        {
            foreach (GameObject fishClone in fishClones)
            {
                fishClone.transform.localScale = Vector3.Normalize(fishClone.transform.localScale) * Random.Range(.5f, 2f);  
                // maybe multiply by 2?
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            foreach (GameObject fishClone in fishClones)
            {
                fishClone.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            }
        }

		// misc list operations you might find useful
		
		// remove items from the list?
		// myFishList.RemoveAt(5); // "remove item #5 from the list"
		
		// reset the list?
		// myFishList.Clear(); // Clear() will blank-out the list, set size=0
    }
}
