using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	float moveSpeed = 3f;
	public int moveDirection;
	// Use this for initialization
	void Start () {
		moveDirection = 1;
		StartCoroutine(Move(moveDirection));
	}
	
	// Update is called once per frame
	void Update () {
		

		//moveDirection = 1;


	}

	IEnumerator MoveVertical(int dir)
	{
		if (dir == 1)
		{
			transform.Translate (0, Time.deltaTime * moveSpeed, 0);
			yield return new WaitForSeconds (3);
		} else
		{
			transform.Translate(0, Time.deltaTime * -moveSpeed, 0);
			yield return  new WaitForSeconds (3);
		}
	}

	IEnumerator MoveHorizontal(int dir)
	{
		if (dir == 3)
		{
			transform.Translate (Time.deltaTime * moveSpeed, 0, 0);
			yield return new WaitForSeconds (3);
		} else
		{
			transform.Translate (Time.deltaTime * -moveSpeed, 0, 0);
			yield return new WaitForSeconds (3);
		}
	}

	IEnumerator Move(int dir)
	{
		
		while (true)
		{
			moveDirection = Random.Range (1, 4);



			if (moveDirection <= 2)
			{
			
				StartCoroutine(MoveVertical (moveDirection));


			} else
			{
			
				StartCoroutine(MoveHorizontal (moveDirection));

			}
		}

			
	}
}
