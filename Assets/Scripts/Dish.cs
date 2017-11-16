using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish {
    public enum CookingStatus { RAW, BAKED, STOVE_COOKED, BOILED, FRIED };

    public Dish(string name, List<Ingredient> ingredients, CookingStatus cookingStatus)
    {
        this.name = name;
        this.ingredients = ingredients;
        this.cookingStatus = cookingStatus;
    }
    
    public Dish(string name, Ingredient[] ingredients, CookingStatus cookingStatus)
    {
        this.name = name;
        this.ingredients = new List<Ingredient>(ingredients);
        this.cookingStatus = cookingStatus;
    }

    public Dish(string name, string[] ingredients, CookingStatus cookingStatus)
    {
        List <Ingredient> ingredientList = new List<Ingredient>();
        foreach (string str in ingredients)
            ingredientList.Add(new Ingredient(str));

        this.name = name;
        this.ingredients = ingredientList;
        this.cookingStatus = cookingStatus;
    }

    public override string ToString()
    {
        string ret = name + ": ";
        foreach (Ingredient ing in ingredients)
            ret += ing.getIngredientName() + ", ";
        ret += cookingStatus;
        return ret;
    }

    public override bool Equals(object obj)
    {
        Dish other = obj as Dish;
        if (!this.ingredients.Count.Equals(other.ingredients.Count))
            return false;
        if (!this.cookingStatus.Equals(other.cookingStatus))
            return false;

        List<Ingredient> sortedIngredients = ingredients;
        sortedIngredients.Sort();

        for (int i = 0; i < ingredients.Count; i++)
        {
            if (!this.ingredients[i].Equals(sortedIngredients[i]))
                return false;
        }
        
        return true;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + ingredients.GetHashCode();
        hash = hash * 23 + cookingStatus.GetHashCode();
        return hash;
    }

    public static Dish getEmptyDish()
    {
        return new Dish("Unfinished Dish", new List<Ingredient>(), CookingStatus.RAW);
    }

    // this may not take into account having a different order of ingredients.
    public bool dishMatches(Dish dish)
    {
        return ingredients.Equals(dish.ingredients) && 
            cookingStatus.Equals(dish.cookingStatus);
    }

    public string getName()
    {
        return name;
    }
    
    public List<Ingredient> getIngredientList()
    {
        return ingredients;
    }

    public Ingredient[] getIngredientArray()
    {
        return ingredients.ToArray();
    }

    public CookingStatus getCookingStatus()
    {
        return cookingStatus;
    }

    public void setCookingStatus(CookingStatus cookingStatus)
    {
        this.cookingStatus = cookingStatus;
    }

    public void addIngredient(Ingredient ingredient)
    {
        foreach (Ingredient i in ingredients)
            if (i.Equals(ingredient))
                return;
        ingredients.Add(ingredient);
    }

    private string name;
    private List<Ingredient> ingredients;
    private CookingStatus cookingStatus;
}