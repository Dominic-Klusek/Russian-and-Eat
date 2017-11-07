using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour {

	GameObject fridgeTop;
	GameObject fridgeBottom;
	public Canvas fridgeUI;

	// Use this for initialization
	void Start () {
		fridgeTop = GameObject.Find ("FridgeTop");
		fridgeBottom = GameObject.Find ("FridgeBottom");
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
		if(GameObject.Find("FridgeUI(Clone))") == null)//don't allow multiple instances
			Instantiate (fridgeUI);//create instance of oven ui
	}

}
