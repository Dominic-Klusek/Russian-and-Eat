using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FridgeUI : MonoBehaviour {
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
            button.transform.parent = scrollContentContainer.transform;
            button.transform.position = scrollContentContainer.transform.position;
            button.transform.position = new Vector3(scrollContentContainer.transform.position.x, 
                scrollContentContainer.transform.position.y - 30 * (i + 1), 0);
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
