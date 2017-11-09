using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void exitClick()
	{
		Destroy(GameObject.Find("FridgeUI(Clone)"));
	}
}
