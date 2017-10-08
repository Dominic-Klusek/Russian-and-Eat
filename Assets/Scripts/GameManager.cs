using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	public int charSelect = 0;

	// Use this for initialization
	void Start () {
		//if this is not the official gamemanager, destroy it
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);//don't destroy official gamemanager
	}
	
	// Update is called once per frame
	void Update () {
	}
		
}
