using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script ensures that the _preload scene runs first so that 
//globally used objects (i.e. GameManager) can be loaded in.

//We use this script in all scenes besides the _preload scene.

public class _preload:MonoBehaviour
	{
		void Awake()
		{
				GameObject check = GameObject.Find("__app");
				if (check==null)
				{
					UnityEngine.SceneManagement.SceneManager.LoadScene("_preload");
					Debug.Log ("Preloading...");
				}

		}	
	}