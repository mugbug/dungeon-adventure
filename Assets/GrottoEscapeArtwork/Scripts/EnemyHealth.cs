using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth;
	private int currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void receiveDamage (int damage) {
		currentHealth -= damage;
		if (currentHealth <= 0) {
			Destroy (gameObject);
		}
	}
}
