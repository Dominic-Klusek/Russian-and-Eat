using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FridgeUI : MonoBehaviour {
    private static FridgeUI instance;
    private List<Ingredient> ingredientList;

    public int ingredientButtonsSpacing = 30;
    public GameObject ingredientButtonPrefab;
    public GameObject[] floorTiles;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        ingredientList = FindObjectOfType<GameManager>().getIngredientsAvailable();
        var scrollContentContainer = transform.Find("Scroll View/Viewport/Content");// GameObject.Find("Content");
        for (int i = 0; i < ingredientList.Count; i++)
        {
            GameObject button = Instantiate(ingredientButtonPrefab) as GameObject;

            // makes the button a child of the scroll container
            // false makes its transform local to the new parent
            button.transform.SetParent(scrollContentContainer.transform, false);
            button.transform.Translate(0, -ingredientButtonsSpacing * i, 0);

            Ingredient buttonIngredient = ingredientList[i];

            Button buttonElement = button.GetComponent<Button>();
            buttonElement.GetComponentInChildren<Text>().text = 
                buttonIngredient.getTransliteration() + "\t\t\t" + 
                buttonIngredient.getRussianName();

            Character player = GameObject.FindObjectOfType<Character>();
            buttonElement.onClick.AddListener(delegate { player.addIngredientToDish(buttonIngredient); });
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static FridgeUI getInstance()
    {
        return instance;
    }

	public void exitClick()
	{
        floorTiles = GameObject.FindGameObjectsWithTag("Floor");
        foreach (GameObject FloorTile in floorTiles)
        {
            FloorTile.GetComponent<Move>().interactable = true;
        }

        Destroy(gameObject);
	}
}
