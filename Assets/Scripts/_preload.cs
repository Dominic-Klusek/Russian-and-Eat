using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script ensures that the _preload scene runs first so that 
//globally used objects (i.e. GameManager) can be loaded in.

//We use this script in all scenes besides the _preload scene.
//To use: simply drag this script onto the Main Camera of your scene. That's it!

public class _preload:MonoBehaviour
	{
		public string sceneName = "";
		void Awake()
		{
				Scene scene = SceneManager.GetActiveScene();
				sceneName = scene.name;
				GameObject check = GameObject.Find("__app");
				if (check==null)
				{
					DontDestroyOnLoad (GameObject.FindWithTag ("MainCamera"));
					UnityEngine.SceneManagement.SceneManager.LoadScene("_preload");
					Debug.Log ("Preloading...");
				}
		}	
	}