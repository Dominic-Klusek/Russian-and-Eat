using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FridgeUI : MonoBehaviour {
    public int ingredientButtonsSpacing = 30;
    private List<Ingredient> ingredientList;
    public GameObject ingredientButtonPrefab;

    // Use this for initialization
    void Start () {
        ingredientList = FindObjectOfType<GameManager>().getAllIngredients();
        GameObject scrollContentContainer = GameObject.Find("Content");
        Button [] buttons = scrollContentContainer.GetComponentsInChildren<Button>();
        for (int i = 0; i < ingredientList.Count; i++)
        {
            GameObject button = Instantiate(ingredientButtonPrefab) as GameObject;

            // makes the button a child of the scroll container
            // false makes its transform local to the new parent
            button.transform.SetParent(scrollContentContainer.transform, false);
            button.transform.Translate(0, -ingredientButtonsSpacing * i, 0);
            button.AddComponent(typeof(Ingredient));
            Ingredient buttonIngredient = button.GetComponent<Ingredient>();
            buttonIngredient = ingredientList[i];
            Debug.Log(buttonIngredient.ToString());
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void exitClick()
	{
		Destroy(GameObject.Find("FridgeUI(Clone)"));
	}
}
