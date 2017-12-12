using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour {

	GameObject fridgeTop;
	GameObject fridgeBottom;
	public Canvas fridgeUI;
    public GameObject[] floorTiles;
    public GameObject floorTileMove;
    public GameObject character;

    // Use this for initialization
    void Start () {
		fridgeTop = GameObject.Find ("FridgeTop");
		fridgeBottom = GameObject.Find ("FridgeBottom");
        fridgeUI.tag = "Popup UI";
	}

	// Update is called once per frame
	void Update () {
	}

	//when mouse hovers over collider, change color of child sprite
	void OnMouseEnter()
	{
		fridgeTop.GetComponent<SpriteRenderer>().color = new Color(0,0,0, 0.5f);
		fridgeBottom.GetComponent<SpriteRenderer>().color = new Color(0,0,0, 0.5f);
	}

	//when mouse moves from collider, change color of child sprite
	void OnMouseExit()
	{
		fridgeTop.GetComponent<SpriteRenderer>().color = new Color(1,1,1, 1f);
		fridgeBottom.GetComponent<SpriteRenderer>().color = new Color(1,1,1, 1f);
	}

	//called on when click on collider
	void OnMouseDown()
	{
        floorTileMove = GameObject.Find("FloorTile (2)");
        floorTileMove.GetComponent<Move>().clickedFridge = true;
        
        character = GameObject.Find("Character");

		if (character.GetComponent<Character>().finishedMovement) {
			//prevent multiple instances of popup UIs from existing
			if (GameObject.Find ("OvenUI(Clone)") != null){
				GameObject.Find("OvenUI(Clone)").GetComponent<OvenUI>().exitClick();
				Instantiate (fridgeUI);
			}
			else if (GameObject.FindGameObjectWithTag ("Popup UI") == null)
				Instantiate (fridgeUI);//create instance of oven ui
			
			floorTiles = GameObject.FindGameObjectsWithTag ("Floor");
			foreach (GameObject FloorTile in floorTiles) {
				FloorTile.GetComponent<Move> ().interactable = false;
			floorTileMove.GetComponent<Move>().OnMouseDown();
			//in else statement find popupUI object, delete that one
			//then do everything in the if statement
			}
		}
    }
}