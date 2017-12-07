using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RecipeShopping : MonoBehaviour {
    public int costPerRecipe= 100;
    public int buttonSpacing = 50;
    public GameObject buyItemButtonPrefab;

    private List<Dish> unpurchasedUncraftableDishList;
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
        unpurchasedUncraftableDishList = new List<Dish>();
        unpurchasedCraftableDishList = new List<Dish>();
        displayedButtons = new List<Button>();
        initUnpurchasedUncraftableDishList();
        updateCraftableDishList();

        scrollContentContainer = transform.Find("Viewport/Content");
        updateButtonsForEachCraftableDish();
    }

    private void initUnpurchasedUncraftableDishList()
    {
        List<Dish> allDishes = GameManager.getInstance().getAllDishes();
        List<Dish> purchasedDishList = GameManager.getInstance().getDishesAvailable();
        unpurchasedUncraftableDishList = allDishes.Except(purchasedDishList).ToList();
    }

    private void updateCraftableDishList()
    {
        if (unpurchasedUncraftableDishList == null)
            initUnpurchasedUncraftableDishList();

        List<Dish> dishesMarkedAsCraftable = new List<Dish>();
        foreach (Dish dish in unpurchasedUncraftableDishList)
        {
            if (GameManager.getInstance().isDishCraftable(dish))
            {
                unpurchasedCraftableDishList.Add(dish);
                dishesMarkedAsCraftable.Add(dish);
            }
        }

        foreach (Dish dish in dishesMarkedAsCraftable)
            unpurchasedUncraftableDishList.Remove(dish);
    }

    private void updateButtonsForEachCraftableDish()
    {
        foreach (Button b in displayedButtons)
            Destroy(b.gameObject);
        displayedButtons = new List<Button>();
        //Button button = scrollContentContainer.GetComponentInChildren<Button>();
        //button.GetComponentInChildren<Text>().text = dishList[1].ToString();
        for (int i = 0; i < unpurchasedCraftableDishList.Count + unpurchasedUncraftableDishList.Count; i++)
        {
            GameObject button = Instantiate(buyItemButtonPrefab) as GameObject;

            // makes the button a child of the scroll container
            // false makes its transform local to the new parent
            button.transform.SetParent(scrollContentContainer.transform, false);
            button.transform.Translate(0, -buttonSpacing * i, 0);

            Button buttonElement = button.GetComponent<Button>();
            if (i < unpurchasedCraftableDishList.Count)
            {
                buttonElement.GetComponentInChildren<Text>().text = unpurchasedCraftableDishList[i].ToString();
            }
            else
            {
                buttonElement.GetComponentInChildren<Text>().text = 
                    unpurchasedUncraftableDishList[i - unpurchasedCraftableDishList.Count].ToString();
                buttonElement.interactable = false;
            }
            // do not change this.
            // for some reason, passing i makes the method its being sent to get 2 (when tested with 2 ingredients)
            // throwing out of index exception. giving value of i to a variable
            // and passing the variable works fine though.
            int indexForArgument = i;
            displayedButtons.Add(buttonElement);
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
        if (GameManager.getInstance().getPlayerMoney() >= costPerRecipe)
        {
            GameManager.getInstance().addDishToAvailableDishList(
                unpurchasedCraftableDishList[recipeIndex]);
            GameManager.getInstance().spendMoney(costPerRecipe);

            moneyDisplayer.updatePlayerMoneyDisplayed();

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
