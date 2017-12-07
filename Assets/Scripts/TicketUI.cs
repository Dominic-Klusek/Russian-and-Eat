using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TicketUI : MonoBehaviour
{
    [Range(0, 10)]
    public int secondsUntilNewOrder = 5;
    public int maxTickets = 4;
    public int ingredientButtonsSpacing = 50;
    public GameObject ticketButtonPrefab;
    public bool tutorialMode = false;

    private static TicketUI instance;

    private List<Dish> dishList;
    private List<Dish> currentDishesRequested;
    private List<Button> currentTicketButtons;
    private Transform scrollContentContainer;
    private Character player;
    private float timer = 0;

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
    void Start()
    {
        init();
    }

    private void init()
    {
        dishList = FindObjectOfType<GameManager>().getDishesAvailable();
        currentDishesRequested = new List<Dish>();
        scrollContentContainer = transform.Find("Scroll View/Viewport/Content");
        currentTicketButtons = new List<Button>();
        Character player = FindObjectOfType<Character>();
        if (tutorialMode)
        {
            currentDishesRequested.Add(GameManager.getInstance().findDishByName("bread"));
            maxTickets = 0;
        }
        refreshTicketButtons();   
    }

    private void refreshTicketButtons()
    {
        StopAllCoroutines();
        foreach (Button button in currentTicketButtons)
            Destroy(button.gameObject);
        currentTicketButtons = new List<Button>();

        for (int i = 0; i < currentDishesRequested.Count; i++)
        {
            GameObject button = Instantiate(ticketButtonPrefab) as GameObject;

            // makes the button a child of the scroll container
            // false makes its transform local to the new parent
            button.transform.SetParent(scrollContentContainer.transform, false);
            button.transform.Translate(0, -ingredientButtonsSpacing * i, 0);

            Dish buttonDish = currentDishesRequested[i];

            Button buttonElement = button.GetComponent<Button>();
            buttonElement.GetComponentInChildren<Text>().text = buttonDish.ToString();
            currentTicketButtons.Add(buttonElement);

            if (player == null)
                player = FindObjectOfType<Character>();

            buttonElement.onClick.AddListener(
                delegate {
                    if (player.submitCreatedDishToMatchOrderedDish(buttonDish))
                        correctDishMade(buttonDish);
                    else
                        StartCoroutine(indicateIncorrectDishWasMade(buttonElement));
                });
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDishesRequested.Count < maxTickets)
        {
            timer += Time.deltaTime / secondsUntilNewOrder;
            if (timer >= 1)
            {
                generateNewTicket();
                timer = 0;
            }
        }
    }

    private void generateNewTicket()
    {
        currentDishesRequested.Add(GameManager.getInstance().getRandomAvailableDish());
        refreshTicketButtons();
    }

    private void OnDestroy()
    {
        instance = null;
    }

    public static TicketUI getInstance()
    {
        return instance;
    }

    private void correctDishMade(Dish dish)
    {
        currentDishesRequested.Remove(dish);
        refreshTicketButtons();
    }

    private IEnumerator indicateIncorrectDishWasMade(Button button)
    {
        button.image.color = Color.red;
        yield return new WaitForSeconds(1);
        button.image.color = Color.white;
    }
}
