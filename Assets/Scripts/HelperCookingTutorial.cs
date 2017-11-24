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
        if (tutorialStage == 0 && FridgeUI.getInstance() != null)
            tutorialStage = 1;
        else if (tutorialStage == 1 && player.getCharacterDish().getIngredientArray().Length == 2)
            tutorialStage = 2;
        else if (tutorialStage == 2 && FridgeUI.getInstance() == null)
            tutorialStage = 3;
        else if (tutorialStage == 3 && OvenUI.getInstance() != null)
            tutorialStage = 4;
        else if (tutorialStage == 4 && player.getCharacterDish().getCookingStatus() == Dish.CookingStatus.BAKED)
            tutorialStage = 5;
        else if (tutorialStage == 5 && player.getCharacterDish().getCookingStatus() == Dish.CookingStatus.BAKED)
            tutorialStage = 6;
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
                dialogue.text = "Great! Now lets make a dish to fill out that ticket on the left.\n" +
                                "The ticket counter explains what was ordered and how to make it.\n" +
                                "To make bread, we'll need water (voda), and flour (muka).\n" +
                                "Click on the ingredients to add them to your dish.\n";
                break;
		    case 2:
                dialogue.text = "Now that we have our ingredients together, let's bake our dish!\n" +
                                "First, click Exit to close the fridge.";
                break;
            case 3:
                dialogue.text = "Next, head over to the stove by clicking on it.\n";
                break;
            case 4:
                dialogue.text = "Clicking on the stove will show you the available options for cooking.\n" +
                                "For now we can only bake, but when we can afford it, we can buy what we need to cook in other ways!\n" +
                                "For now, click on bake to bake the bread.\n";
                break;
            case 5:
                dialogue.text = "Mmm, that smells great! Looks like the bread is ready!\n" +
                                "To deliver the order, just click on the ticket.\n" +
                                "If it flashes green, that means you correctly filled out the order.\n" +
                                "If it flashes red, something went wrong! Try making the dish again.";
                break;
            case 6:
                dialogue.text = "Nice Job! Looks like you're ready to open the restaurant!\n" +
                                "After each day, we'll look at how much money we made.\n" +
                                "At that time, we can decide what we can buy to improve the restaurant.\n" +
                                "For now, let's get started!\n";
                break;
            default:
			    break;
		}
	}
}
