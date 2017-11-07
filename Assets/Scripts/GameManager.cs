using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager gm = null;
	public int charSelect = 0;

	// Use this for initialization
	void Start () {
		//if this is not the official gamemanager, destroy it
		if (gm == null)
			gm = this;
		else
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);//don't destroy official gamemanager
	}
	
	// Update is called once per frame
	void Update () {
	}
		
}
