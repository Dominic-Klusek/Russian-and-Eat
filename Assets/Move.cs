using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	
	public GameObject character;
	Rigidbody2D bodyCharacter;
	Transform positionCharacter;

	// Use this for initialization
	void Start () {
		bodyCharacter = character.GetComponent<Rigidbody2D> ();
		positionCharacter = character.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//called on when click on collider
	void OnMouseDown()
	{
		bool leftClick = Input.GetMouseButtonDown (0);
		if (leftClick) {
			Vector3 v = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			v = new Vector3 (Mathf.Floor (v.x), Mathf.Floor (v.y), Mathf.Floor (v.z));
			StartCoroutine(MoveX (v));

			StartCoroutine(MoveY (v));

		}
	}

	IEnumerator MoveX(Vector3 v)
	{
		//while loop doesn't work, need to figure out why
		//while(positionCharacter.position.x != v.x)
		//while the clicked position doesn't equal the object's position stay in loop
		while (positionCharacter.position.x != v.x) {
			if (positionCharacter.position.x > v.x) {
				bodyCharacter.MovePosition (new Vector2 (--positionCharacter.position.x, positionCharacter.position.y));
			}
			else if (positionCharacter.position.x < v.x) {
				bodyCharacter.MovePosition (new Vector2 (++positionCharacter.position.x, positionCharacter.position.y));
			}
			yield return null;
		}
			
	}

	IEnumerator MoveY(Vector3 v)
	{
		//while the clicked position doesn't equal the object's position stay in loop
		while (positionCharacter.position.y != v.y) {
			if (positionCharacter.position.y > v.y) {
				bodyCharacter.MovePosition (new Vector2 (positionCharacter.position.x, --positionCharacter.position.y));
			}
			else if (positionCharacter.position.y < v.y) {
				bodyCharacter.MovePosition (new Vector2 (positionCharacter.position.x, ++positionCharacter.position.y));
			}
			yield return null;
		}

	}
}
