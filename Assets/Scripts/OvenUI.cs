﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OvenUI : MonoBehaviour {
    Character player;
    Button fry;
    Button boil;
    Button bake;
    public GameObject[] floorTiles;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Character>();
        GameManager game = Object.FindObjectOfType<GameManager>();

        fry = GameObject.Find("FryButton").GetComponent<Button>();
        if (!game.getIsFryingAvailable())
            fry.gameObject.SetActive(false);
        else
            fry.onClick.AddListener(player.fryDish);

        boil = GameObject.Find("BoilButton").GetComponent<Button>();
        if (!game.getIsBoilingAvailable())
            boil.gameObject.SetActive(false);
        else
            boil.onClick.AddListener(player.boilDish);

        bake = GameObject.Find("Roast/BakeButton").GetComponent<Button>();
        if (!game.getIsBakingAvailable())
            bake.gameObject.SetActive(false);
        else
            bake.onClick.AddListener(player.bakeDish);
    }

    // Update is called once per frame
    void Update () {
		
	}

	public void exitClick()
	{
        floorTiles = GameObject.FindGameObjectsWithTag("Floor");
        foreach (GameObject FloorTile in floorTiles)
        {
            FloorTile.GetComponent<Move>().interactable = true;
        }
        
        Destroy(gameObject);
	}
}
