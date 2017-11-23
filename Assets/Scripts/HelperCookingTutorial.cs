using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HelperCookingTutorial : MonoBehaviour {
    private int tutorialStage = 0;
    private Text dialogue;
    private Character player;

    public Texture btnTexture;
	public GameObject maleObject;
	public GameObject femaleObject;

	// Use this for initialization
	void Start () {
		dialogue = GetComponent<Text> ();
        player = Character.getInstance();
}
	
	// Update is called once per frame
	void Update () {
        if (FridgeUI.getInstance() != null && tutorialStage == 0)
            tutorialStage = 1;
        if (player.getCharacterDish().getIngredientArray().Length == 2 && tutorialStage == 1)
            tutorialStage = 2;
    }

    void OnGUI(){
		GameManager game = Object.FindObjectOfType<GameManager>();
		switch (tutorialStage) {
		    case 0:
                dialogue.text = "Since you're new here, I'll show you around the kitchen.\n" +
                    "Clicking on the floor will move you to that space.\n" +
                    "Clicking on the fridge will move you to it and open it up.\n" +
                    "Try seeing what we have in the fridge.";
			break;
		    case 1:
                dialogue.text = "Great! Now lets make a dish.\n" +
                                "If you look to the left, you'll see a ticket.\n" +
                                "It explains what food was ordered and how to make it.\n" +
                                "Clicking on an ingredient will add it to your dish.\n";
                break;
		    case 2:
                dialogue.text = "\n" +
                                "\n" +
                                "\n" +
                                "\n";
                break;
            case 3:
                dialogue.text = "\n" +
                                "\n" +
                                "\n" +
                                "\n";
                break;
            default:
			    break;
		}
	}
}
