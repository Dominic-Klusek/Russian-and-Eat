using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script exists in the _preload scene. It is used to make
//the game start from the main menu.

public class _loadMenu : MonoBehaviour {

	void Awake()
	{
		GameManager game = Object.FindObjectOfType<GameManager>();
		game.LoadMenu();
	}	
}
