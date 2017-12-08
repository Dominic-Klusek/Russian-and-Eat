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

    // Use this for initialization
    void Start()
    {
        dialogue = GetComponent<Text>();
        player = Character.getInstance();
        gameManager = GameManager.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        switch (ingredient)
        {
            case "":
                dialogue.text = "What do you need translated?\n";
                break;
            case "water":
                dialogue.text = "That's water!";
                break;
            default:
                break;
        }
    }
}