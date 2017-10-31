using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient {
    public Ingredient(string name) {
        ingredientName = name;
    }

    public string getIngredientName()
    {
        return ingredientName;
    }

    private string ingredientName;
}
