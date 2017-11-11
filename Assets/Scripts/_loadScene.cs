using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script exists in the _preload scene. It is used to make
//the game start from whichever scene was last open in the editor.

public class _loadScene : MonoBehaviour {

	void Awake()
	{
		string scene = GameObject.FindWithTag ("MainCamera").GetComponent<_preload>().sceneName;
		GameManager game = Object.FindObjectOfType<GameManager>();

		Destroy (GameObject.FindWithTag ("MainCamera"));

        game.LoadScene(scene);
	}	
}