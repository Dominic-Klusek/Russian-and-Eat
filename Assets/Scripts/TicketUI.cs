using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TicketUI : MonoBehaviour
{
    public int ingredientButtonsSpacing = 50;
    private List<Dish> dishList;
    public GameObject ticketButtonPrefab;

    // Use this for initialization
    void Start()
    {
        dishList = FindObjectOfType<GameManager>().getDishesAvailable();
        var scrollContentContainer = transform.Find("Scroll View/Viewport/Content");
        //Button button = scrollContentContainer.GetComponentInChildren<Button>();
        //button.GetComponentInChildren<Text>().text = dishList[1].ToString();
        for (int i = 0; i < dishList.Count; i++)
        {
            GameObject button = Instantiate(ticketButtonPrefab) as GameObject;

            // makes the button a child of the scroll container
            // false makes its transform local to the new parent
            button.transform.SetParent(scrollContentContainer.transform, false);
            button.transform.Translate(0, -ingredientButtonsSpacing * i, 0);
            
            Dish buttonDish = dishList[i];
            
            Button buttonElement = button.GetComponent<Button>();
            buttonElement.GetComponentInChildren<Text>().text = buttonDish.ToString();
            Character player = GameObject.FindObjectOfType<Character>();
            buttonElement.onClick.AddListener(
                delegate {
                    if (player.submitCreatedDishToMatchOrderedDish(buttonDish))
                        StartCoroutine(indicateCorrectDishWasMade(buttonElement));
                    else
                        StartCoroutine(indicateIncorrectDishWasMade(buttonElement));
                });
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator indicateCorrectDishWasMade(Button button)
    {
        button.image.color = Color.green;
        yield return new WaitForSeconds(1);
        button.image.color = Color.white;
    }

    private IEnumerator indicateIncorrectDishWasMade(Button button)
    {
        button.image.color = Color.red;
        yield return new WaitForSeconds(1);
        button.image.color = Color.white;
    }

    public void exitClick()
    {
        Destroy(gameObject);
    }
}
