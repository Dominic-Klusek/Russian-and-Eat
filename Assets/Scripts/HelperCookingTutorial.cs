using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HelperCookingTutorial : MonoBehaviour {
    private int tutorialStage = 0;
    private Text dialogue;
    private Character player;
    private GameManager gameManager;
	private GameObject arrowObject;
	private GameObject arrowObject1;
	private GameObject arrowObject2;
	private GameObject arrowObject3;
	private GameObject arrowObject4;
	private GameObject arrowObject5;
	private GameObject arrowObject6;
    private GameObject arrowObject7;
    private Button exitFridge;
	private Button exitStove;
    private PlayerIngredientDisplayer ingredientDisplayerScript;
    private Button ingredientsButton;
    private Button ingredientsButton1;

    // Use this for initialization
    void Start () {
		dialogue = GetComponent<Text> ();
        player = Character.getInstance();
        gameManager = GameManager.getInstance();
		arrowObject = GameObject.Find ("arrow");
		arrowObject1 = GameObject.Find ("arrow1");
		arrowObject2 = GameObject.Find ("arrow2");
		arrowObject3 = GameObject.Find ("arrow3");
		arrowObject4 = GameObject.Find ("arrow4");
		arrowObject5 = GameObject.Find ("arrow5");
		arrowObject6 = GameObject.Find ("arrow6");
        arrowObject7 = GameObject.Find("arrow7");
        ingredientsButton = GameObject.Find("Player Ingredients").GetComponent<Button>();
        ingredientsButton1 = GameObject.Find("Player Ingredient Displayer Button").GetComponent<Button>();
        ingredientsButton.interactable = false;
        ingredientsButton1.interactable = false;
    }
	
	// Update is called once per frame
	void Update () {
        //blinking arrow here
        if (tutorialStage == 0 && FridgeUI.getInstance() != null) {
            exitFridge = GameObject.Find("ExitButton").GetComponent<Button>();
            exitFridge.gameObject.SetActive(false);
            tutorialStage = 1;
        } else if (tutorialStage == 1 && player.getCharacterDish().getIngredientArray().Length == 2) {
            tutorialStage = 2;
            ingredientDisplayerScript = GameObject.Find("Player Ingredient Displayer Button").GetComponent<PlayerIngredientDisplayer>();
            ingredientsButton.interactable = true;
            ingredientsButton1.interactable = true;
        }
        else if (tutorialStage == 2 && ingredientDisplayerScript.isDisplayerHidden == false) {
            exitFridge.gameObject.SetActive(true);
            tutorialStage = 3;
		}
        else if (tutorialStage == 3 && FridgeUI.getInstance () == null) {
			tutorialStage = 4;
            
        }
        else if (tutorialStage == 4 && OvenUI.getInstance () != null) {
			tutorialStage = 5;
			exitStove = GameObject.Find ("ExitButton").GetComponent<Button> ();
			exitStove.gameObject.SetActive (false);
		}
        else if (tutorialStage == 5 && player.getCharacterDish ().getCookingStatus () == Dish.CookingStatus.BAKED) {
			exitStove.gameObject.SetActive (true);
			tutorialStage = 6;
		}
        else if (tutorialStage == 6 && player.getCharacterDish().getIngredientList().Count == 0)
            tutorialStage = 7;
    }

    void OnGUI(){
		switch (tutorialStage) {
		    case 0:
			arrowObject.GetComponent<SpriteRenderer> ().enabled = true;

                dialogue.text = "Since you're new here, I'll show you around the kitchen.\n" +
                                "Clicking on the floor will move you to that space.\n" +
                                "Clicking on the fridge will move you to it and open it up.\n" +
                                "Try seeing what we have in the fridge.";
			    break;
		    case 1:
			arrowObject.GetComponent<SpriteRenderer> ().enabled = false;
			arrowObject1.GetComponent<SpriteRenderer> ().enabled = true;

			dialogue.text = "Great! Now lets make a dish to fill out that ticket on the left.\n" +
			"The ticket counter explains what was ordered and how to make it.\n" +
			"To make bread, we'll need water (voda), and flour (muka).\n" +
			"Click on the ingredients to add them to your dish.\n";
            break;
            case 2:
                arrowObject1.GetComponent<SpriteRenderer>().enabled = false;
                arrowObject2.GetComponent<SpriteRenderer>().enabled = true;

                dialogue.text = "Now the ingredients are currently on your dish.\n" +
                "Click up here to see what is in your dish at any given time in case you forget.\n";
                break;
            case 3:
			arrowObject2.GetComponent<SpriteRenderer> ().enabled = false;
			arrowObject3.GetComponent<SpriteRenderer> ().enabled = true;


                dialogue.text = "Now that we have our ingredients together, let's bake our dish!\n" +
                                "First, click Exit to close the fridge.";
                break;
            case 4:
			arrowObject3.GetComponent<SpriteRenderer> ().enabled = false;
			arrowObject4.GetComponent<SpriteRenderer> ().enabled = true;


                dialogue.text = "Next, head over to the stove by clicking on it.\n";
                break;
            case 5:
			arrowObject4.GetComponent<SpriteRenderer> ().enabled = false;
			arrowObject5.GetComponent<SpriteRenderer> ().enabled = true;


                dialogue.text = "The stove will show you the available options for cooking.\n" +
                                "For now we can only bake, but when we can afford it, we can buy what we need to cook in other ways!\n" +
                                "For now, click on Bake/Roast to bake the bread.\n";
                break;
            case 6:
			arrowObject5.GetComponent<SpriteRenderer> ().enabled = false;
			arrowObject6.GetComponent<SpriteRenderer> ().enabled = true;


                dialogue.text = "Mmm, that smells great! Looks like the bread is ready!\n" +
                                "To deliver the order, just click on the ticket.\n" +
                                "If it disappears, that means you correctly filled out the order.\n" +
                                "If it flashes red, something went wrong! Try making the dish again.";
                break;
            case 7:
			arrowObject6.GetComponent<SpriteRenderer> ().enabled = false;
			arrowObject7.GetComponent<SpriteRenderer> ().enabled = true;


                dialogue.text = "Nice Job! Looks like you're ready to open the restaurant!\n" +
                                "After each day, we'll look at how much money we made.\n" +
                                "At that time, we can decide what to improve the restaurant.\n" +
                                "For now, let's get started!\n";
                if (GUI.Button(new Rect(900, 625, 50, 50), "START"))
                    gameManager.LoadNextScene();
                break;
            default:
			    break;
		}
	}
}
