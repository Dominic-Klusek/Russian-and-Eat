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
    private string fileDelim = "\n";

    private List<Ingredient> allIngredients = new List<Ingredient>();
    private List<Dish> allDishes;

    private void Awake()
    {
        string [] fileContents = ingredientsFile.text.Split(fileDelim [0]);
        foreach (string i in fileContents)
            allIngredients.Add(new Ingredient(i));
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
		
}
