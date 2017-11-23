using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HelperCookingTutorial : MonoBehaviour {
    
    public int textSpot = 0;
	Text dialogue;
	public Texture btnTexture;
	public GameObject maleObject;
	public GameObject femaleObject;

	// Use this for initialization
	void Start () {
		dialogue = GetComponent<Text> ();
        
}
	
	// Update is called once per frame
	void Update () {
        //if (GameObject.FindBB)
	}

	void OnGUI(){
		GameManager game = Object.FindObjectOfType<GameManager>();
		switch (textSpot) {
		case 0:
			dialogue.text = "Since you're new here, I'll show you around the kitchen.\n" +
				"Clicking on a floor tile will move you to that space.\n" +
                "Clicking on the fridge will move you to it and open it up." + 
                "Try it now.";
			break;
		case 1:
			displayCharacters ();
			dialogue.text = "Before we get started I need to know,\nwho would you like to play as?";
			if (GUI.Button (new Rect (375, 300, 60, 60), "Male")) {
				hideFemaleCharacter ();
				print ("Male");
				game.femaleCharacter = false;
				textSpot++;
			}
			if (GUI.Button (new Rect (550, 300, 60, 60), "Female")) {
				hideMaleCharacter ();
				print ("Female");
				game.femaleCharacter = true;
				textSpot++;
			}
			break;
		case 2:
			dialogue.text = "Great! Click Play when you're ready to start!";
			if (GUI.Button (new Rect (750, 400, 50, 50), "PLAY")) {
				game.LoadLevel1 ();
			}
			break;
		default:
			break;
		}
	}

	void displayCharacters(){
		maleObject = GameObject.Find ("chef_male_0");
		femaleObject = GameObject.Find ("chef_female_0");
		maleObject.GetComponent<SpriteRenderer>().enabled = true;
		femaleObject.GetComponent<SpriteRenderer>().enabled = true;
	}
	void hideMaleCharacter(){
		maleObject.GetComponent<SpriteRenderer>().enabled = false;
	}
	void hideFemaleCharacter(){
		femaleObject.GetComponent<SpriteRenderer>().enabled = false;
	}

	/*void TextChanger(){
		switch (textSpot) {
		case 0:
			dialogue.text = "Welcome to Russian-and-Eat. I'm your guide, Vladimir.\n" +
				"The goal of this game is to teach you the Russian language and to cook Russian cuisine.";
			break;
		case 1:
			dialogue.text = "Before we get started I need to know,\nAre you male or female.";
			if (GUI.Button (new Rect (10, 10, 50, 50), btnTexture)) {
				
			}
			break;
		case 2:
			dialogue.text = "Please enter you name: ";
			break;
		default:
			break;
		}
	}*/
}
