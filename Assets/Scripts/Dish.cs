using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish {
    public enum CookingStatus { RAW, BAKED, STOVE_COOKED, BOILED, FRIED };

    public Dish(string name, List<Ingredient> ingredients, CookingStatus cookingStatus, int price)
    {
        init(name, ingredients, cookingStatus, price);
    }

    public Dish(string name, Ingredient[] ingredients, CookingStatus cookingStatus, int price)
    {
        this.name = name;
        this.ingredients = new List<Ingredient>(ingredients);
        init(name, new List<Ingredient>(ingredients), cookingStatus, price);
    }

    public Dish(string name, string[] ingredients, CookingStatus cookingStatus, int price)
    {
        List <Ingredient> ingredientList = new List<Ingredient>();
        foreach (string str in ingredients)
            ingredientList.Add(new Ingredient(str));

        init(name, ingredientList, cookingStatus, price);
    }
    
    private void init(string name, List<Ingredient> ingredients, CookingStatus cookingStatus, int price)
    {
        this.name = name;
        this.ingredients = ingredients;
        this.cookingStatus = cookingStatus;
        this.purchasePrice = price;
    }

    public override string ToString()
    {
        string ret = name + ": ";
        foreach (Ingredient ing in ingredients)
            ret += ing.getIngredientName() + ", ";
        ret += cookingStatus + ", ";
        ret += purchasePrice;
        return ret;
    }

    public string ToStringWithoutPurchasePrice()
    {
        string ret = name + ": ";
        foreach (Ingredient ing in ingredients)
            ret += ing.getIngredientName() + ", ";
        ret += cookingStatus + ", ";
        return ret;
    }

    public override bool Equals(object obj)
    {
        Dish other = obj as Dish;
        if (!this.ingredients.Count.Equals(other.ingredients.Count))
            return false;
        if (!this.cookingStatus.Equals(other.cookingStatus))
            return false;

        // deep copy
        List<Ingredient> sortedOtherIngredients = 
            other.getIngredientList().ConvertAll(i => new Ingredient(i));
        sortedOtherIngredients.Sort();

        // deep copy
        List<Ingredient> sortedThisIngredients =
            this.getIngredientList().ConvertAll(i => new Ingredient(i));
        sortedThisIngredients.Sort();

        for (int i = 0; i < ingredients.Count; i++)
        {
            if (!sortedThisIngredients[i].Equals(sortedOtherIngredients[i]))
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
        return new Dish("Unfinished Dish", new List<Ingredient>(), CookingStatus.RAW, 0);
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

    public int getPurchasePrice()
    {
        return purchasePrice;
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

    public bool addIngredient(Ingredient ingredient)
    {
        foreach (Ingredient i in ingredients)
            if (i.Equals(ingredient))
                return false;
        ingredients.Add(ingredient);
        return true;
    }

    private string name;
    private List<Ingredient> ingredients;
    private CookingStatus cookingStatus;
    private int purchasePrice;
}