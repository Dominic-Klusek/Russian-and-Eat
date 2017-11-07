﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour {
	GameObject ovenTop;
	GameObject ovenBottom;
	public Canvas ovenUI;

	// Use this for initialization
	void Start () {
		ovenTop = GameObject.Find ("Top");
		ovenBottom = GameObject.Find ("Bottom");
	}
	
	// Update is called once per frame
	void Update () {
	}

	//when mouse hovers over collider, change color of child sprite
	void OnMouseEnter()
	{
		ovenTop.GetComponent<SpriteRenderer>().color = new Color(0,0,0, 0.5f);
		ovenBottom.GetComponent<SpriteRenderer>().color = new Color(0,0,0, 0.5f);
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
		if(GameObject.Find("OvenUI(Clone)") == null)//don't allow multiple instances
			Instantiate (ovenUI);//create instance of oven ui
	}

}
