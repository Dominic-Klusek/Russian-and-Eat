using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterCreation : MonoBehaviour {
    
    public int textSpot = 0;
	Text dialogue;
	public Texture btnTexture;
	// Use this for initialization
	void Start () {
		dialogue = GetComponent<Text> ();
        GameManager game = Object.FindObjectOfType<GameManager>();
}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){
		switch (textSpot) {
		case 0:
			dialogue.text = "Welcome to Russian-and-Eat. I'm your guide, Vladimir.\n" +
				"The goal of this game is to teach you the Russian language and to cook Russian cuisine.";
			if (GUI.Button (new Rect (10, 10, 50, 50), "Next")) {
				textSpot++;
			}
			break;
		case 1:
			dialogue.text = "Before we get started I need to know,\nAre you male or female.";
			if (GUI.Button (new Rect (10, 10, 50, 50), "Boy")) {
				print ("Boy");
				textSpot++;
			}
			if (GUI.Button (new Rect (70, 10, 50, 50), "Girl")) {
				print ("Girl");
				textSpot++;
			}
			break;
		case 2:
			
			if (GUI.Button (new Rect (50, 10, 50, 50), "Finished")) {
			}
			break;
		default:
			break;
		}
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
