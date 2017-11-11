using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour {
	public Character character;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "Player")
			character.finishedMovement = true;
	}

	void OnTriggerExit2D(Collider2D coll)
	{
	}
}
