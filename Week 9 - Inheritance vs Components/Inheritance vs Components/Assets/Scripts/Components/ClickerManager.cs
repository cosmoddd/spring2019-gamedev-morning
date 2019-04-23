using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerManager : MonoBehaviour
{

 	// "SINGLETON" = only one instance of this object in the game
	// usually used for "manager" type objects

	// "static" means "global", any script can access this
	public static ClickerManager instance;
	// "static" also means it lives in the code, not the scene
	// that means every gameobject shares this same variable

	public int myScore = 0;

	void Start ()
	{
		instance = this; // initialize our static shortcut      //POWER OF THE SINGLETON -- DON'T ABUSE IT
	}
	
	void Update () {
		if (myScore > 30)
		{
			Debug.Log("You win!");
		}
	}   

}
