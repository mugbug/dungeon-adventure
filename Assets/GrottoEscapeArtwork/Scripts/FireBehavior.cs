using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : MonoBehaviour {

	// shoot
	public float fireSpeed;
	Rigidbody2D rigidbody;

	// fire alive time
	public float aliveTime;

	// fire hit
	public int fireDamage;

	// Use this for initialization
	void Awake () {
		rigidbody = GetComponent<Rigidbody2D> ();

		if (transform.localRotation.z > 0) {
			rigidbody.AddForce (new Vector2 (-1, 0) * fireSpeed, ForceMode2D.Impulse);
		} else {
			rigidbody.AddForce (new Vector2 (1, 0) * fireSpeed, ForceMode2D.Impulse);
		}

		Destroy (gameObject, aliveTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			Destroy (gameObject);
			if (other.tag == "Enemy") {
				EnemyHealth enemyHp = other.gameObject.GetComponent<EnemyHealth> ();
				enemyHp.receiveDamage (fireDamage);
			}
		}
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			Destroy (gameObject);
			if (other.tag == "Enemy") {
				EnemyHealth enemyHp = other.gameObject.GetComponent<EnemyHealth> ();
				enemyHp.receiveDamage (fireDamage);
			}
		}
	}
}
