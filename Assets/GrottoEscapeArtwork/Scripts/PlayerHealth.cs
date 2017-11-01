using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;

	PlayerBehavior controlMovement;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;

		controlMovement = GetComponent<PlayerBehavior> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void receiveDamage (int damage) {
		if (damage <= 0)
			return;
		currentHealth -= damage;
		gameObject.GetComponent<Animation> ().Play ("PlayerRedFlash");
		if (currentHealth <= 0) {
			makeDead ();
		}
	}

	public void makeDead () {
//		Destroy (gameObject);
		Application.LoadLevel(Application.loadedLevel);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag("EnergyCapsule")) {
			Destroy (col.gameObject);
			if (currentHealth + 1 >= 6)
				currentHealth = 6;
			else
				currentHealth += 1;
		}
		if (col.CompareTag ("EnergyTank")) {
			Destroy (col.gameObject);
			if (currentHealth + 3 >= 6)
				currentHealth = 6;
			else
				currentHealth += 3;
		}
	}
}
