using System.Collections;
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
        allIngredients = new List<Ingredient>();
        initIngredients();
        allDishes = new List<Dish>();
        initDishes();
    }

    // Use this for initialization
    void Start () {
		//if this is not the official gamemanager, destroy it
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);//don't destroy official gamemanager
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
        string detailDelim = ";";
        string lineDelim = "\n";
        string[] fileLines = ingredientsFile.text.Split(lineDelim[0]);
        foreach (string line in fileLines)
        {
            string[] ingredientDetails = line.Split(detailDelim[0]);
            allIngredients.Add(new Ingredient(ingredientDetails[0],
                ingredientDetails[1],
                ingredientDetails[2]));
        }
    }

    private void initDishes()
    {
        
    }
}
