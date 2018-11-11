using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float playerHealth;//player's health
	private float moveSpeed;//Players speed
	private float horizontalVelocity;//velocity going up and down
	private float verticalVelocity;//velocity going left and right



	// Use this for initialization
	void Start () {
		playerHealth = 100f;
		moveSpeed = 3f;
	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

	/*This method is so that the player can take damage from enemies.
	 * The strength of the enemy is passed in and then subtracted
	 * from the player. The enemy script or maybe the bullet script
	 * will have to call this function.
	 */
	public void takeDamage(float enemyStrength)
	{
		playerHealth -= enemyStrength;
	}

	/*This method is so that the player can get health from a health pickup.
	 * The amount that the health pick up gives is passed in and added to the
	 * player's health. There will be different sizes of health packs.
	 */
	public void getHealth(float healthPickup)
	{
		playerHealth += healthPickup;

		//This prevents the player from getting too much health
		if (playerHealth > 100)
		{
			playerHealth = 100;
		}
	}

	#region PlayerMovement
	/*Controls movement for the player*/
	public void move()
	{
		horizontalVelocity = 0f;
		verticalVelocity = 0f;
		if (Input.GetKey (KeyCode.D))
		{
			//GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			horizontalVelocity = moveSpeed;
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			//GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			horizontalVelocity = -moveSpeed;
		}

		if (Input.GetKey (KeyCode.W)) 
		{
			verticalVelocity = moveSpeed;
		}

		if (Input.GetKey (KeyCode.S)) 
		{
			verticalVelocity = -moveSpeed;
		}


		GetComponent<Rigidbody2D> ().velocity = new Vector2 (horizontalVelocity, verticalVelocity);
		//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, moveVelocity);

		//This flips the sprite depending on which direction you are going.
		//Needs to be added back in when there is a sprite to work with
		/*
		if (GetComponent<Rigidbody2D> ().velocity.x > 0)
			transform.localScale = new Vector3 (1f, 1f, 1f);
		else if (GetComponent<Rigidbody2D> ().velocity.x < 0)
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			*/
	}
	#endregion //PlayerMovement

	/*Method used to shoot*/
	public void shoot()
	{

	}
}
