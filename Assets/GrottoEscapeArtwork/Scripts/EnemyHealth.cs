using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float maxHealth;
	private float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void receiveDamage (float damage) {
		currentHealth -= damage;
		if (currentHealth <= 0) {
			Destroy (gameObject);
		}
	}
}
