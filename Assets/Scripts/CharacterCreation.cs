using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterCreation : MonoBehaviour {
    
    public int textSpot = 0;
	Text dialogue;
	public Texture btnTexture;
	public GameObject maleObject;
	public GameObject femaleObject;

	// Use this for initialization
	void Start () {
		dialogue = GetComponent<Text> ();
        maleObject = GameObject.Find("chef_male_0");
        femaleObject = GameObject.Find("chef_female_0");
    }
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){
		GameManager game = Object.FindObjectOfType<GameManager>();
		switch (textSpot) {
		case 0:
			dialogue.text = "Welcome to Russian-and-Eat. I'm your guide, Vladimir.\n" +
				"The goal of this game is to teach you the Russian language and to cook Russian cuisine.";
			if (GUI.Button (new Rect (Screen.width / 2 + 200, Screen.height / 2 + 35, 100, 50), "Next")) {
				textSpot++;
			}
			break;
		case 1:
			displayCharacters ();
			dialogue.text = "Before we get started I need to know,\nwho would you like to play as?";
			if (GUI.Button (new Rect (Screen.width / 2 - 165, Screen.height / 2 + 35, 100, 50), "Male")) {
				hideFemaleCharacter ();
				print ("Male");
				game.femaleCharacter = false;
				textSpot++;
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 80, Screen.height / 2 + 35, 100, 50), "Female")) {
				hideMaleCharacter ();
				print ("Female");
				game.femaleCharacter = true;
				textSpot++;
			}
			break;
		case 2:
			dialogue.text = "Great! Click Play when you're ready to start!";
			if (GUI.Button (new Rect(Screen.width / 2 + 200, Screen.height / 2 + 35, 100, 50), "PLAY")) {
				game.LoadNextScene();
			}
			break;
		default:
			break;
		}
	}

	void displayCharacters(){
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
