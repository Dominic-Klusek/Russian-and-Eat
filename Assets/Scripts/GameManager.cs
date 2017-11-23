using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
    public TextAsset ingredientsFile;
    public TextAsset recipesFile;
	public bool femaleCharacter = false;
    public bool isBakingAvailable = true;
    public bool isFryingAvailable = false;
    public bool isBoilingAvailable = false;

    public string[] namesOfStartingIngredients = { "water", "flour" };
    public string[] namesOfStartingDishes = { "bread" };

    private List<Ingredient> allIngredients;
    private List<Dish> allDishes;

    private List<Ingredient> ingredientsAvailable;
    private List<Dish> dishesAvailable;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        allIngredients = new List<Ingredient>();
        initIngredients();
        allDishes = new List<Dish>();
        initDishes();

        ingredientsAvailable = new List<Ingredient>();
        initIngredientsAvailable();
        dishesAvailable = new List<Dish>();
        initDishesAvailable();
        /*
        foreach (Ingredient ing in ingredientsAvailable)
            Debug.Log(ing.ToString());
        
        foreach (Dish d in dishesAvailable)
            Debug.Log(d.ToString());
            */
    }     

	public void StartGame()
	{
		SceneManager.LoadScene("CharacterCreation");
		Debug.Log ("Loaded Character Creation.");
	}

	public void LoadCredits()
	{
		SceneManager.LoadScene("Credits");
		Debug.Log ("Loaded Credits.");

	}

	public void LoadMenu()
	{
		SceneManager.LoadScene("Menu");
		Debug.Log ("Loaded Menu.");
	}

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Debug.Log("Loaded " + scene + ".");
    }
	public void LoadLevel1()
	{
		SceneManager.LoadScene("scene1");
		Debug.Log ("Loaded scene1.");
	}
    // Update is called once per frame
    void Update () {

	}

    private void initIngredients()
    {
        char commentMarker = '#';
        char detailDelim = '\t';
        char lineDelim = '\n';
        string[] fileLines = ingredientsFile.text.Split(lineDelim);
        foreach (string line in fileLines)
        {
            // if the first char is the same as the commentMarker, 
            // skip all this and go to next iteration of the loop.
            if (line[0] == commentMarker)
                continue;
            string[] ingredientDetails = line.Split(detailDelim);
            allIngredients.Add(new Ingredient(ingredientDetails[0],
                ingredientDetails[1],
                ingredientDetails[2]));
        }
    }

    private void initDishes()
    {
        char detailDelim = '\t';
        char ingredientDelim =',';
        char lineDelim = '\n';
        string[] fileLines = recipesFile.text.Split(lineDelim);
        foreach (string line in fileLines)
        {
            string[] dishDetails = line.Split(detailDelim);
            string[] ingredientNames = dishDetails[1].Split(ingredientDelim);

            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (string s in ingredientNames)
            {
                ingredients.Add(findIngredientByName(s));
            }
            // sort to ensure the ingredients of a dish are in the same order whenever made.
            // this is important for comparing the player's dish's list of ingredients
            // to a ticket's dish's list of ingredients. 
            // The player's dish must also be sorted before the comparison is made.
            ingredients.Sort();
            allDishes.Add(new Dish(dishDetails[0],
                ingredients,
                (Dish.CookingStatus) Enum.Parse(typeof(Dish.CookingStatus), dishDetails[2].ToUpper()))
            );
        }
    }

    private void initIngredientsAvailable()
    {
        foreach (string ingredientName in namesOfStartingIngredients)
        {
            ingredientsAvailable.Add(findIngredientByName(ingredientName));
        }
    }

    private void initDishesAvailable()
    {
        foreach (string dishName in namesOfStartingDishes)
        {
            dishesAvailable.Add(findDishByName(dishName));
        }
    }

    public Ingredient findIngredientByName(string name)
    {
        foreach (Ingredient i in allIngredients)
        {
            if (i.getIngredientName().Equals(name))
                return i;
        }
        throw new Exception("\"" + name + "\" was searched for as an existing ingredient, " +
            "but was not found as a registered ingredient.\n" + 
            "Try checking for typos, " + 
            "or try adding this ingredient to your text file listing ingredients.");
    }

    public Dish findDishByName(string name)
    {
        foreach (Dish i in allDishes)
        {
            if (i.getName().Equals(name))
                return i;
        }
        throw new Exception("\"" + name + "\" was searched for as an existing Dish, " +
            "but was not found as a registered Dish.\n" +
            "Try checking for typos, " +
            "or try adding this Dish to your text file listing recipes.");
    }

    public List<Ingredient> getAllIngredients()
    {
        return allIngredients;
    }

    public List<Dish> getAllDishes()
    {
        return allDishes;
    }

    public List<Ingredient> getIngredientsAvailable()
    {
        return ingredientsAvailable;
    }

    public List<Dish> getDishesAvailable()
    {
        return dishesAvailable;
    }

    public bool getIsBakingAvailable()
    {
        return isBakingAvailable;
    }

    public bool getIsFryingAvailable()
    {
        return isFryingAvailable;
    }

    public bool getIsBoilingAvailable()
    {
        return isBoilingAvailable;
    }
}
