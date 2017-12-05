using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class IngredientShopping : MonoBehaviour {
    public int costPerIngredient = 100;
    public int buttonSpacing = 50;
    public GameObject buyItemButtonPrefab;

    private List<Ingredient> unPurchasedIngredientList;
    private List<Button> ingredientBuyingButtons;
    private PlayerMoneyIndicator moneyDisplayer;
    // Use this for initialization
    void Start()
    {
        // for testing
        //GameManager.getInstance().awardPlayerMoney(400);
        moneyDisplayer = GameObject.Find("Player Money Indicator").GetComponent<PlayerMoneyIndicator>();
        moneyDisplayer.updatePlayerMoneyDisplayed();

        ingredientBuyingButtons = new List<Button>();
        List<Ingredient> allIngredientList = GameManager.getInstance().getAllIngredients();
        List<Ingredient> purchasedIngredientList = GameManager.getInstance().getIngredientsAvailable();
        unPurchasedIngredientList = allIngredientList.Except(purchasedIngredientList).ToList();

        var scrollContentContainer = transform.Find("Viewport/Content");
        //Button button = scrollContentContainer.GetComponentInChildren<Button>();
        //button.GetComponentInChildren<Text>().text = dishList[1].ToString();
        for (int i = 0; i < unPurchasedIngredientList.Count; i++)
        {
            GameObject button = Instantiate(buyItemButtonPrefab) as GameObject;

            // makes the button a child of the scroll container
            // false makes its transform local to the new parent
            button.transform.SetParent(scrollContentContainer.transform, false);
            button.transform.Translate(0, -buttonSpacing * i, 0);

            Button buttonElement = button.GetComponent<Button>();
            ingredientBuyingButtons.Add(buttonElement);
            buttonElement.GetComponentInChildren<Text>().text = unPurchasedIngredientList[i].ToString();
            // do not change this.
            // for some reason, passing i makes the method its being sent to get 2 (when tested with 2 ingredients)
            // throwing out of index exception. giving value of i to a variable
            // and passing the variable works fine though.
            int indexForArgument = i;
            buttonElement.onClick.AddListener(delegate { buyIngredientAndRemoveButton(indexForArgument); });
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void buyIngredientAndRemoveButton(int ingredientIndex)
    {
        Debug.Log("index = " + ingredientIndex);
        if (GameManager.getInstance().getPlayerMoney() >= costPerIngredient)
        {
            Destroy(ingredientBuyingButtons[ingredientIndex].gameObject);
            //ingredientBuyingButtons.RemoveAt(ingredientIndex);

            GameManager.getInstance().addIngredientToAvailableIngredientsList(
                unPurchasedIngredientList[ingredientIndex]);
            GameManager.getInstance().spendMoney(costPerIngredient);
            moneyDisplayer.updatePlayerMoneyDisplayed();
        }
        else
            StartCoroutine(indicateIngredientNotBought(ingredientBuyingButtons[ingredientIndex]));
    }

    private IEnumerator indicateIngredientNotBought(Button button)
    {
        button.image.color = Color.red;
        yield return new WaitForSeconds(1);
        button.image.color = Color.white;
    }
}
