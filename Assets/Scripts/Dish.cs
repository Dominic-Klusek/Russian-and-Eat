using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish {
    public enum CookingStatus { RAW, BAKED, STOVE_COOKED, BOILED };

    public Dish(string name, List<Ingredient> ingredients, CookingStatus status)
    {
        this.name = name;
        this.ingredients = ingredients;
        this.cookingStatus = status;
    }

    private string name;
    private List<Ingredient> ingredients;
    private CookingStatus cookingStatus;
}