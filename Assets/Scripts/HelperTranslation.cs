using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperTranslation : MonoBehaviour {

	GameObject helper;
	public Canvas helperUI;
	public Canvas textUI;
	public GameObject[] floorTiles;
	public GameObject character;

	// Use this for initialization
	void Start () {
		helper = GameObject.Find ("HelperGuy");
		helperUI.tag = "Popup UI";
		textUI.tag = "Popup UI";
	}

	// Update is called once per frame
	void Update () {
	}

	//when mouse hovers over collider, change color of child sprite
	void OnMouseEnter()
	{
		helper.GetComponent<SpriteRenderer>().color = new Color(0,0,0, 0.5f);
	}

	//when mouse moves from collider, change color of child sprite
	void OnMouseExit()
	{
		helper.GetComponent<SpriteRenderer>().color = new Color(1,1,1, 1f);
	}

	//called on when click on collider
	void OnMouseDown()
	{
		character = GameObject.Find("Character");

		if (character.GetComponent<Character>().finishedMovement) {
			//prevent multiple instances of popup UIs from existing
			if (GameObject.FindGameObjectWithTag ("Popup UI") == null){
				Instantiate (helperUI);//create instance of helper ui
				Instantiate (textUI);//create instance of textUI here
			}
			floorTiles = GameObject.FindGameObjectsWithTag ("Floor");
			foreach (GameObject FloorTile in floorTiles) {
				FloorTile.GetComponent<Move> ().interactable = false;

			}
		}
	}
}