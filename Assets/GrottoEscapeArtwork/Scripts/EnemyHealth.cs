using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth;
	private int currentHealth;
	private Rigidbody2D rigidbody;
	private int direction;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		direction = -1;
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.velocity = new Vector2 (direction*2f, rigidbody.velocity.y);
	}

	public void receiveDamage (int damage) {
		currentHealth -= damage;
		gameObject.GetComponent<Animation> ().Play ("WhiteFlashAnimation");
		if (currentHealth <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Invisible")) {
			direction *= -1;
			flip ();
		}
	}


	void flip() {
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
