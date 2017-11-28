using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour {
	GameObject ovenTop;
	GameObject ovenBottom;
	public Canvas ovenUI;
    public GameObject[] floorTiles;
    public GameObject floorTileMove;
    public GameObject character;
    public bool interactable = true;

	// Use this for initialization
	void Start () {
		ovenTop = GameObject.Find ("Top");
		ovenBottom = GameObject.Find ("Bottom");
        ovenUI.tag = "Popup UI";
	}
	
	// Update is called once per frame
	void Update () {
	}

	//when mouse hovers over collider, change color of child sprite
	void OnMouseEnter()
	{
        ovenTop.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.5f);
        ovenBottom.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.5f);
    }

	//when mouse moves from collider, change color of child sprite
	void OnMouseExit()
	{
		ovenTop.GetComponent<SpriteRenderer>().color = new Color(1,1,1, 1f);
		ovenBottom.GetComponent<SpriteRenderer>().color = new Color(1,1,1, 1f);
    }

	//called on when click on collider
	void OnMouseDown()
	{
        floorTileMove = GameObject.Find("FloorTile (7)");
        floorTileMove.GetComponent<Move>().clickedOven = true;
        floorTileMove.GetComponent<Move>().OnMouseDown();
        character = GameObject.Find("Character");

		if (character.GetComponent<Character> ().finishedMovement) {
			//prevent multiple instances of popup UIs from existing
			if (GameObject.FindGameObjectWithTag ("Popup UI") == null)
				Instantiate (ovenUI);//create instance of oven ui

			floorTiles = GameObject.FindGameObjectsWithTag ("Floor");
			foreach (GameObject FloorTile in floorTiles) {
				FloorTile.GetComponent<Move> ().interactable = false;
			}
		}
    }
}
