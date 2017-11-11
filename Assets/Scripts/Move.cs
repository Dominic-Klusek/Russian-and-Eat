using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public Character character;//reference to character script
	Rigidbody2D bodyCharacter;//reference to character's Rigidbody2D
	Transform positionCharacter;//reference to character's Transform
	Animator animatorCharacter;//reference to character's Animator Controller

	SpriteRenderer mousePlace;
	Vector3 v;//static Vector3 variable that is used very ofthen in script

	// Use this for initialization
	void Start () {
		bodyCharacter = character.GetComponent<Rigidbody2D> ();//reference to character Rigidbody2D
		positionCharacter = character.GetComponent<Transform> ();//reference to character Transform
		mousePlace = GetComponent<SpriteRenderer> ();
		animatorCharacter = character.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

		

	//when mouse hovers over collider, change color of child sprite
	void OnMouseEnter()
	{
		mousePlace.color = new Color(0,0,0, 0.5f);

	}

	//when mouse moves from collider, change color of child sprite
	void OnMouseExit()
	{
		mousePlace.color = new Color(1,1,1, 1f);
	}

	//called on when click on collider
	void OnMouseDown()
	{
		bool leftClick = Input.GetMouseButtonDown (0);
		//if we left clicked, and we are not moving
		if (leftClick && character.finishedMovement) {
			v = Camera.main.ScreenToWorldPoint (Input.mousePosition);//function to get input from mousecursor, and turn it into a Vector3

			fixedCoordinates ();//fix coordinates from mouse click

			StartCoroutine("MoveX");//coroutine to move in horizontal axis

			StartCoroutine("MoveY");//coroutine to move in the vertical axis
		}
	}

	//check if coordinates of positionCharacter == Vector3 v
	void checkMovement()
	{
		//if coordinates are equal, movement is finished set finishedMovement to true, otherwise set finishedmovement to false
		if (positionCharacter.position.x == v.x && positionCharacter.position.y == v.y) {
			character.finishedMovement = true;
			StopCoroutine ("MoveX");
			StopCoroutine ("MoveY");
		} else {
			character.finishedMovement = false;
		}
	}

	//coroutine that changes x position of character by 1 until it is equal to where player clicked
	IEnumerator MoveX()
	{ 	
		//while loop doesn't work, need to figure out why
		//while(positionCharacter.position.x != v.x)
		//while the clicked position doesn't equal the object's position stay in loop
		while (positionCharacter.position.x != v.x) {
			if (positionCharacter.position.x > v.x) {
				animatorCharacter.SetBool ("WalkingForward", false);//if these are true, set them to false to prevent errors
				animatorCharacter.SetBool ("WalkingBackward", false);
				animatorCharacter.SetBool ("WalkingLeft", true);//set appropriate horizontal bool
				animatorCharacter.SetBool ("WalkingRight", false);
				bodyCharacter.MovePosition (new Vector2 (positionCharacter.position.x - 1, positionCharacter.position.y));//decrement x position
			}
			else if (positionCharacter.position.x < v.x) {
				animatorCharacter.SetBool ("WalkingForward", false);//if these are true, set them to false to prevent errors
				animatorCharacter.SetBool ("WalkingBackward", false);
				animatorCharacter.SetBool ("WalkingLeft", false);//set appropriate horizontal bool
				animatorCharacter.SetBool ("WalkingRight", true);
				bodyCharacter.MovePosition (new Vector2 (positionCharacter.position.x + 1, positionCharacter.position.y));//increment x position
			}

			yield return new WaitForSeconds(0.1f);//delay next movement for 0.1 seconds
		}
		checkMovement ();//check if movement is finished
		animatorCharacter.SetBool ("WalkingLeft", false);
		animatorCharacter.SetBool ("WalkingRight", false);
		yield return null; //Done
	}

	//coroutine that changes y position of character by 1 until it is equal to where player clicked
	IEnumerator MoveY()
	{
		//while the clicked position doesn't equal the object's position stay in loop
		while (positionCharacter.position.y != v.y) {
			if (positionCharacter.position.y > v.y) {
				animatorCharacter.SetBool ("WalkingForward", true);//set appropriate vertical bool
				animatorCharacter.SetBool ("WalkingBackward", false);
				animatorCharacter.SetBool ("WalkingLeft", false);//if these are true, set them to false
				animatorCharacter.SetBool ("WalkingRight", false);
				bodyCharacter.MovePosition (new Vector2 (positionCharacter.position.x, positionCharacter.position.y - 1));//decrement y position
			} else if (positionCharacter.position.y < v.y) {
				animatorCharacter.SetBool ("WalkingForward", false);//set appropriate vertical bool
				animatorCharacter.SetBool ("WalkingBackward", true);
				animatorCharacter.SetBool ("WalkingLeft", false);//if these are true, set them to false
				animatorCharacter.SetBool ("WalkingRight", false);
				bodyCharacter.MovePosition (new Vector2 (positionCharacter.position.x, positionCharacter.position.y + 1));//increment y position
			}
			yield return new WaitForSeconds(0.1f);//delay next movement for 0.1 seconds
		}
		checkMovement ();//check if movement is finished
		animatorCharacter.SetBool ("WalkingForward", false);
		animatorCharacter.SetBool ("WalkingBackward", false);
		yield return null; //Done
	}

	//function fixes vector so that it correlates correctly to the collider tiles, then return fixed vector
	void fixedCoordinates()
	{
		float nx, ny;
		//if v.x is negative, we need to treat it differently from when it is positive
		if (v.x < 0) {
			//if decimal is greater than or equal to 0.5, we round down
			if (v.x % 1f < -0.5f) {
				nx = Mathf.Floor (v.x);
			}
			//else round up
			else {
				nx = Mathf.Ceil (v.x);
			}
		} 
		else {
			//if decimal is greater than or equal to 0.5, we round up
			if ((v.x % 1f) > 0.5f) {
				nx = Mathf.Ceil (v.x);
			} 
			//else round down
			else {
				nx = Mathf.Floor (v.x);
			}
		}

		//if v.y is negative, we need to treat it differently from when it is positive
		if (v.y < 0) {
			//if decimal is greater than or equal to 0.5, we round down
			if ((v.y % 1f) < -0.5f) {
				ny = Mathf.Floor (v.y);
			}
			//else round up
			else {
				ny = Mathf.Ceil (v.y);
			}
		} 
		else {
			//if decimal is greater than or equal to 0.5, we round up
			if ((v.y % 1f) > 0.5f) {
				ny = Mathf.Ceil (v.y);
			}
			//else round down
			else {
				ny = Mathf.Floor (v.y);
			}
		}

		v = new Vector3 (nx, ny, Mathf.Floor (v.z));//vector to send to move functions
	}
}
