using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour {

	public GameManager gm;//reference to GameManager
	public int numberCharacters;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	//load first Scene when start game is clicked
	public void StartGame()
	{
		SceneManager.LoadScene("Scene1");
	}

	//increment Sprite value
	public void incSprite ()
	{
		//if we are at last sprite go to first, otherwise increment regularly
		if (gm.charSelect == numberCharacters - 1)
			gm.charSelect = 0;
		else
			gm.charSelect++;
	}

	public void decSprite ()
	{
		//if we are at first sprite go to last, otherwise decrement regularly
		if (gm.charSelect == 0)
			gm.charSelect = numberCharacters - 1;
		else
			gm.charSelect--;
	}
}
