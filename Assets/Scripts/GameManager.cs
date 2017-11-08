using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	public int charSelect = 0;
    public TextAsset ingredientsFile;
    public TextAsset recipesFile;

    private List<Ingredient> allIngredients;
    private List<Dish> allDishes;

    private void Awake()
    {
        //if this is not the official gamemanager, destroy it
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);//don't destroy official gamemanager

        allIngredients = new List<Ingredient>();
        initIngredients();
        allDishes = new List<Dish>();
        initDishes();

        foreach (Ingredient ing in allIngredients)
            Debug.Log(ing.ToString());

        foreach (Dish d in allDishes)
            Debug.Log(d.ToString());
    }

    // Use this for initialization
    void Start () {
		
	}

	public void StartGame()
	{
		SceneManager.LoadScene("Scene1");
	}

	public void LoadCredits()
	{
		SceneManager.LoadScene("Credits");
	}
	public void LoadMenu()
	{
		SceneManager.LoadScene("Menu");
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
            Debug.Log(dishDetails.Length);
            string[] ingredients = dishDetails[1].Split(ingredientDelim);
            allDishes.Add(new Dish(dishDetails[0],
                ingredients,
                (Dish.CookingStatus) Enum.Parse(typeof(Dish.CookingStatus), dishDetails[2].ToUpper()))
            );
        }
    }
}
