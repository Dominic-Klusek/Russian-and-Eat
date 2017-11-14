using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	public bool finishedMovement = true;

	// Use this for initialization
	void Start () {
		GameManager game = Object.FindObjectOfType<GameManager>();
		if (game.femaleCharacter == true){
			Animator animator;
			animator = this.GetComponent<Animator>();
			animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("AnimatorControllers/chef_female", typeof(RuntimeAnimatorController )));
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
	}
		
}