using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RecipeShopping : MonoBehaviour {
    public int costPerRecipe= 100;
    public int buttonSpacing = 50;
    public GameObject buyItemButtonPrefab;

    private List<Dish> unpurchasedDishList;
    private List<Dish> unpurchasedCraftableDishList;
    private List<Button> displayedButtons;
    private Transform scrollContentContainer;
    private PlayerMoneyIndicator moneyDisplayer;
    // Use this for initialization
    void Start()
    {
        moneyDisplayer = GameObject.Find("Player Money Indicator").GetComponent<PlayerMoneyIndicator>();
        moneyDisplayer.updatePlayerMoneyDisplayed();

        init();
    }

    private void init()
    {
        unpurchasedDishList = new List<Dish>();
        unpurchasedCraftableDishList = new List<Dish>();
        initUnpurchasedDishList();
        updateCraftableDishList();

        scrollContentContainer = transform.Find("Viewport/Content");
        updateButtonsForEachCraftableDish();
    }

    private void initUnpurchasedDishList()
    {
        List<Dish> allDishes = GameManager.getInstance().getAllDishes();
        List<Dish> purchasedDishList = GameManager.getInstance().getDishesAvailable();
        unpurchasedDishList = allDishes.Except(purchasedDishList).ToList();
    }

    private void updateCraftableDishList()
    {
        if (unpurchasedDishList == null)
            initUnpurchasedDishList();
        foreach (Dish dish in unpurchasedDishList)
        {
            if (GameManager.getInstance().isDishCraftable(dish))
                unpurchasedCraftableDishList.Add(dish);
        }
    }

    private void updateButtonsForEachCraftableDish()
    {
        displayedButtons = new List<Button>();
        //Button button = scrollContentContainer.GetComponentInChildren<Button>();
        //button.GetComponentInChildren<Text>().text = dishList[1].ToString();
        for (int i = 0; i < unpurchasedCraftableDishList.Count; i++)
        {
            GameObject button = Instantiate(buyItemButtonPrefab) as GameObject;

            // makes the button a child of the scroll container
            // false makes its transform local to the new parent
            button.transform.SetParent(scrollContentContainer.transform, false);
            button.transform.Translate(0, -buttonSpacing * i, 0);

            Button buttonElement = button.GetComponent<Button>();
            buttonElement.GetComponentInChildren<Text>().text = unpurchasedCraftableDishList[i].ToString();
            // do not change this.
            // for some reason, passing i makes the method its being sent to get 2 (when tested with 2 ingredients)
            // throwing out of index exception. giving value of i to a variable
            // and passing the variable works fine though.
            int indexForArgument = i;
            buttonElement.onClick.AddListener(delegate {
                buyRecipeAndUpdateButtons(indexForArgument, buttonElement); });
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void buyRecipeAndUpdateButtons(int recipeIndex, Button button)
    {
        Debug.Log("index = " + recipeIndex);
        if (GameManager.getInstance().getPlayerMoney() >= costPerRecipe)
        {
            GameManager.getInstance().addDishToAvailableDishList(
                unpurchasedDishList[recipeIndex]);
            GameManager.getInstance().spendMoney(costPerRecipe);

            moneyDisplayer.updatePlayerMoneyDisplayed();

            unpurchasedDishList.RemoveAt(recipeIndex);
            unpurchasedCraftableDishList.RemoveAt(recipeIndex);
            updateButtonsForEachCraftableDish();
        }
        else
            StartCoroutine(indicateIngredientNotBought(button));
    }

    private IEnumerator indicateIngredientNotBought(Button button)
    {
        button.image.color = Color.red;
        yield return new WaitForSeconds(1);
        button.image.color = Color.white;
    }

    public void updateRecipeShopping()
    {
        int previousCraftableDishesCount = unpurchasedCraftableDishList.Count;
        updateCraftableDishList();
        if (previousCraftableDishesCount != unpurchasedCraftableDishList.Count)
            updateButtonsForEachCraftableDish();
    }
}
