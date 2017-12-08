using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TranslationDialogue : MonoBehaviour
{
    private int next = 0;
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
        switch (next)
        {
            case 0:
                dialogue.text = "What do you need translated?\n";
                break;
            default:
                break;
        }
    }
}