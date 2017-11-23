using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour {

    GameObject trash;
    public GameObject[] floorTiles;
    public GameObject floorTileMove;
    public GameObject character;
    public bool interactable = true;

    // Use this for initialization
    void Start()
    {
        trash = GameObject.Find("TrashSprite");
    }

    // Update is called once per frame
    void Update()
    {
    }

    //when mouse hovers over collider, change color of child sprite
    void OnMouseEnter()
    {
        trash.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.5f);
    }

    //when mouse moves from collider, change color of child sprite
    void OnMouseExit()
    {
        trash.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
    }

    //called on when click on collider
    void OnMouseDown()
    {
        floorTileMove = GameObject.Find("FloorTile (9)");
        floorTileMove.GetComponent<Move>().OnMouseDown();
        character = GameObject.Find("Character");

        floorTiles = GameObject.FindGameObjectsWithTag("Floor");
        foreach (GameObject FloorTile in floorTiles)
        {
            FloorTile.GetComponent<Move>().interactable = false;
        }
        Character player = GameObject.FindObjectOfType<Character>();
        player.restartDish();
        Debug.Log("Dish reset.");
    }
}
