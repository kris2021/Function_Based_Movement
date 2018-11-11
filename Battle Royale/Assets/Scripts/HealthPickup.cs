using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

	private float healthAmount;//the amount that it has to give


	// Use this for initialization
	void Start () {
		healthAmount = Random.Range (25f, 100f);//Sets the health between 25 and 100

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		other.gameObject.GetComponent<Player> ().getHealth (healthAmount);//this gets the player script from the instance of the player and increases the health
		Destroy (gameObject);
	}
}
