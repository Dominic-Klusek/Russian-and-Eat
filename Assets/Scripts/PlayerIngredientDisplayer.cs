using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIngredientDisplayer : MonoBehaviour {
    public string startingMessage = "Most Recent Ingredient";
    public string noIngredientsText = "Dish Emptied";

    private Text buttonText;
    private List<string> ingredientTransliterationsToDisplay;
    private string mostRecentIngredient;

	// Use this for initialization
	void Start () {
		buttonText = GetComponentInChildren<Text>();
        buttonText.text = startingMessage;
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void updatePlayerIngredientsDisplayed(Dish playerDish)
    {
        List<Ingredient> dishIngredients = playerDish.getIngredientList();
        mostRecentIngredient = dishIngredients[dishIngredients.Count - 1].getTransliteration();
        buttonText.text = mostRecentIngredient;
    }

    public void clearPlayerIngredientsDisplayer()
    {
        buttonText.text = noIngredientsText;
    }
}
