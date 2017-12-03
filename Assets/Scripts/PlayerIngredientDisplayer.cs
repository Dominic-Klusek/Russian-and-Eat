using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIngredientDisplayer : MonoBehaviour {
    public string startingMessage = "Most Recent Ingredient";
    public string noIngredientsText = "Dish Emptied";
    public int ingredientButtonsSpacing = 30;
    public GameObject ingredientDisplayButtonPrefab;
    public Button secondaryIngredientDisplayerToggleButton;
    // Determine how many seconds before auto-hiding. Set to 0 to disable auto-hide.
    public float secondsUntilHidingIdleDisplayer = 7;

    private Text recentIngredientButtonText;
    private List<string> ingredientTransliterationsToDisplay;
    private string mostRecentIngredient;
    private int ingredientsCurrentlyDisplayedCount;
    private List<Button> allIngredientButtons;

    private Animator animator;
    public bool isDisplayerHidden;
    private float secondsDisplayerIdle = 0;
    private Button ingredientDisplayerToggleButton;

    // Use this for initialization
    void Start () {
		recentIngredientButtonText = GetComponentInChildren<Text>();
        recentIngredientButtonText.text = startingMessage;
        allIngredientButtons = new List<Button>();

        ingredientDisplayerToggleButton = GetComponent<Button>();
        ingredientDisplayerToggleButton.onClick.AddListener(toggleDisplayer);
        secondaryIngredientDisplayerToggleButton.onClick.AddListener(toggleDisplayer);

        animator = GetComponent<Animator>();
        isDisplayerHidden = animator.GetBool("isHidden");
    }
	
	// Update is called once per frame
	void Update () {
        if (secondsUntilHidingIdleDisplayer > 0)
        {
            if (!isDisplayerHidden)
            {
                secondsDisplayerIdle += Time.deltaTime;
                if (secondsDisplayerIdle >= secondsUntilHidingIdleDisplayer)
                {
                    toggleDisplayer();
                    secondsDisplayerIdle = 0;
                }
            }
        }
    }

    public void updatePlayerIngredientsDisplayed(Dish playerDish)
    {
        List<Ingredient> dishIngredients = playerDish.getIngredientList();
        mostRecentIngredient = dishIngredients[dishIngredients.Count - 1].getTransliteration();
        recentIngredientButtonText.text = mostRecentIngredient;

        updateAllPlayerIngredientDisplay();
    }

    private void updateAllPlayerIngredientDisplay()
    {
        // setting up all-ingredients display
        var playerIngredientsContainerTransform =
            transform.Find("Player Ingredients/All Player Ingredients/Viewport/Content");

        List<Ingredient> ingredientList = Character.getInstance().getCharacterDish().getIngredientList();
        for (int i = ingredientsCurrentlyDisplayedCount; i < ingredientList.Count; i++)
        {
            GameObject button = Instantiate(ingredientDisplayButtonPrefab) as GameObject;

            // makes the button a child of the scroll container
            // false makes its transform local to the new parent
            button.transform.SetParent(playerIngredientsContainerTransform.transform, false);
            button.transform.Translate(0, -ingredientButtonsSpacing * i, 0);

            string ingredientTransliteration = ingredientList[i].getTransliteration();

            Button buttonElement = button.GetComponent<Button>();
            buttonElement.GetComponentInChildren<Text>().text = ingredientTransliteration;
            allIngredientButtons.Add(buttonElement);
            ingredientsCurrentlyDisplayedCount++;
        }
    }

    public void clearPlayerIngredientsDisplayer()
    {
        recentIngredientButtonText.text = noIngredientsText;
        clearAllPlayerIngredientDisplay();
    }

    private void clearAllPlayerIngredientDisplay()
    {
        foreach (Button b in allIngredientButtons)
            Destroy(b.gameObject);
        allIngredientButtons.Clear();
        Debug.Log("Buttons: " + allIngredientButtons.Count);
        ingredientsCurrentlyDisplayedCount = 0;
    }

    private void toggleDisplayer()
    {
        isDisplayerHidden = !isDisplayerHidden;
        animator.SetBool("isHidden", isDisplayerHidden);
    }
}
