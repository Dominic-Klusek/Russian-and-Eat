using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient {
    public Ingredient(string ingredientName, string transliteration, string russianName) {
        this.ingredientName = ingredientName;
        this.transliteration = transliteration;
        this.russianName = russianName;
    }

    public Ingredient(string ingredientName)
    {
        this.ingredientName = ingredientName;
        transliteration = "N/A";
        russianName = "N/A";
    }

    public override string ToString()
    {
        return this.ingredientName + ", " +
               this.transliteration + ", " +
               this.russianName;
    }

    public bool Equals(Ingredient other)
    {
        if (getIngredientName().Equals(other.getIngredientName()))
            return true;
        return false;
    }

    public string getIngredientName() {
        return ingredientName;
    }

    public string getTransliteration()
    {
        return transliteration;
    }

    public string getRussianName()
    {
        return russianName;
    }

    private string ingredientName;
    private string transliteration;
    private string russianName;
}
