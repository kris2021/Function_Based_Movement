using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	float moveSpeed = 3f;
	public int moveDirection;
	// Use this for initialization
	void Start () {
		moveDirection = 1;
		//StartCoroutine(Move(moveDirection));
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection = Random.Range (1, 5);
		StartCoroutine(Move (moveDirection));
		//moveDirection = 1;


	}

	IEnumerator MoveVertical(int dir)
	{
		if (dir == 1)
		{
			transform.Translate (0, Time.deltaTime * moveSpeed, 0);
			yield return new WaitForSeconds (5f);

		} else
		{
			transform.Translate(0, Time.deltaTime * -moveSpeed, 0);
			yield return new WaitForSeconds (5f);
		}
	}

	IEnumerator MoveHorizontal(int dir)
	{
		if (dir == 3)
		{
			transform.Translate (Time.deltaTime * moveSpeed, 0, 0);
			yield return new WaitForSeconds (5f);
		} else
		{
			transform.Translate (Time.deltaTime * -moveSpeed, 0, 0);
			yield return new WaitForSeconds (5f);
		}
	}

	IEnumerator Move(int dir)
	{
			if (moveDirection <= 2)
			{

			StartCoroutine(MoveVertical (moveDirection));


			} else
			{
			
			StartCoroutine(MoveHorizontal (moveDirection));

			}
		yield return new WaitForSeconds (3);
			
	}
}
