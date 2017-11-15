using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	public bool finishedMovement = true;
    private Dish genericDish;

	// Use this for initialization
	void Start () {
        genericDish = Dish.getEmptyDish();
        GameManager game = Object.FindObjectOfType<GameManager>();
		if (game.femaleCharacter == true){
			Animator animator;
			animator = this.GetComponent<Animator>();
			animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("AnimatorControllers/chef_female", typeof(RuntimeAnimatorController )));
		}
	}

	// Update is called once per frame
	void Update () {
        Debug.Log(genericDish.getCookingStatus());
	}
		
    public void bakeDish()
    {
        genericDish.setCookingStatus(Dish.CookingStatus.BAKED);
    }

    public void stoveCookDish()
    {
        genericDish.setCookingStatus(Dish.CookingStatus.STOVE_COOKED);
    }

    public void boilDish()
    {
        genericDish.setCookingStatus(Dish.CookingStatus.BOILED);
    }

    public void fryDish()
    {
        genericDish.setCookingStatus(Dish.CookingStatus.FRIED);
    }
}