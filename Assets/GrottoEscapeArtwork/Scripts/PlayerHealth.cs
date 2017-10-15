using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public float maxHealth;
	private float currentHealth;

	PlayerBehavior controlMovement;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;

		controlMovement = GetComponent<PlayerBehavior> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void receiveDamage (float damage) {
		if (damage <= 0)
			return;
		currentHealth -= damage;
		if (currentHealth <= 0) {
			makeDead ();
		}
	}

	public void makeDead () {
		Destroy (gameObject);
	}
}
