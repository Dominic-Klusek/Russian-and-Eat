using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void StartGame()
    {
        GameManager game = Object.FindObjectOfType<GameManager>();
        game.StartGame();
    }

    public void LoadCredits()
    {
        GameManager game = Object.FindObjectOfType<GameManager>();
        game.LoadCredits();
    }

    public void LoadMenu()
    {
        GameManager game = Object.FindObjectOfType<GameManager>();
        game.LoadMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }
}