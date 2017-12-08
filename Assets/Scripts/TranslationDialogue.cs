using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TranslationDialogue : MonoBehaviour
{
    private string ingredient = "";

    private Text dialogue;
    private Character player;
    private GameManager gameManager;
    public GameObject helperUI;

    // Use this for initialization
    void Start()
    {
        dialogue = GetComponent<Text>();
        player = Character.getInstance();
        gameManager = GameManager.getInstance();
        helperUI = GameObject.Find("HelperTranslationUI(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void translateIngredient(string transliteration)
    {
        ingredient = transliteration;
        Debug.Log(ingredient);
    }

    void OnGUI()
    {
        switch (ingredient)
        {
            case "":
                dialogue.text = "What do you need translated?\n";
                break;
            case "voda":
                dialogue.text = "That's water!";
                break;
            case "muka":
                dialogue.text = "That's flour!";
                break;
            case "soda":
                dialogue.text = "That's soda!";
                break;
            case "sakhar":
                dialogue.text = "That's sugar!";
                break;
            case "moloko":
                dialogue.text = "That's milk!";
                break;
            case "yaytsa":
                dialogue.text = "That's eggs!";
                break;
            case "shokolad":
                dialogue.text = "That's chocolate!";
                break;
            default:
                break;
        }
    }
}