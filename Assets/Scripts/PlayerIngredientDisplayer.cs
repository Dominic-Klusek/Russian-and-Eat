using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIngredientDisplayer : MonoBehaviour {
    private Text buttonText;
    private List<string> ingredientTransliterationsToDisplay;
    private string mostRecentIngredient;

	// Use this for initialization
	void Start () {
		buttonText = GetComponentInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        //buttonText.text = "s";
    }

    public void updateIngredientsDisplayed(Dish playerDish)
    {
        List<Ingredient> dishIngredients = playerDish.getIngredientList();
        mostRecentIngredient = dishIngredients[dishIngredients.Count - 1].getTransliteration();
        buttonText.text = mostRecentIngredient;
    }
}
