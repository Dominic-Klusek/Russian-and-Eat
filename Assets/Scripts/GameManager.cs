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

    private List<Ingredient> allIngredients;
    private List<Dish> allDishes;

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
        /*
        foreach (Ingredient ing in allIngredients)
            Debug.Log(ing.ToString());
         */
        foreach (Dish d in allDishes)
            Debug.Log(d.ToString());
            
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
        char detailDelim = '\t';
        char lineDelim = '\n';
        string[] fileLines = ingredientsFile.text.Split(lineDelim);
        foreach (string line in fileLines)
        {
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
            ingredients.Sort();
            allDishes.Add(new Dish(dishDetails[0],
                ingredients,
                (Dish.CookingStatus) Enum.Parse(typeof(Dish.CookingStatus), dishDetails[2].ToUpper()))
            );
        }
    }

    public Ingredient findIngredientByName(string name)
    {
        foreach (Ingredient i in allIngredients)
        {
            if (i.getIngredientName().Equals(name))
                return i;
        }
        throw new Exception("\"" + name + "\" was listed as an ingredient for a recipe, " +
            "but was not found as a registered ingredient.\n" + 
            "Try checking that for typos, " + 
            "or try adding this ingredient to your text file listing ingredients.");
    }

    public List<Ingredient> getAllIngredients()
    {
        return allIngredients;
    }

    public List<Dish> getAllDishes()
    {
        return allDishes;
    }
}
