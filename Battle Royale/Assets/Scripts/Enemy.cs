using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

	public Transform player;
	float moveSpeed;
	public int moveDirection;
	public bool follow;
	private float maxRange = 5f;
	int counter = 0;
	// Use this for initialization
	void Start () {
		moveDirection = 1;
		moveSpeed = 1f;
		follow = false;
		//StartCoroutine(Move(moveDirection));
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		var heading = player.position - transform.position;

		if (heading.sqrMagnitude < maxRange * maxRange)
		{
			follow = true;
		} else
		{
			follow = false;
		}
		if (!follow)
		{
			if (counter % 50 == 0)
			{
				moveDirection = Random.Range (1, 5);

			}
			Move (moveDirection);
			//moveDirection = 1;
		} else
		{
			transform.position = Vector3.MoveTowards (transform.position, player.position, moveSpeed * Time.deltaTime);
		}


	}

	void MoveVertical(int dir)
	{
		if (dir == 1)
		{
			transform.Translate (0, Time.deltaTime * moveSpeed, 0);


		} else
		{
			transform.Translate(0, Time.deltaTime * -moveSpeed, 0);
		}
	}

	void MoveHorizontal(int dir)
	{
		if (dir == 3)
		{
			transform.Translate (Time.deltaTime * moveSpeed, 0, 0);
		} else
		{
			transform.Translate (Time.deltaTime * -moveSpeed, 0, 0);
		}
	}

	void Move(int dir)
	{
		

		if (moveDirection <= 2)
		{

			MoveVertical (moveDirection);

		} else
		{
			
			MoveHorizontal (moveDirection);

		}


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Debug.Log ("You Lose");
			SceneManager.LoadScene ("Lose");
		}
	}


}
