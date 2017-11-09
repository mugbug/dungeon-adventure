using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	public int damage;
	public float damageRate;
	public bool knockback;
	private float nextDamage;

	private PlayerBehavior player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerBehavior> ();
		nextDamage = 0f;
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.CompareTag("Player") && nextDamage < Time.time) {
			PlayerHealth playerHP = other.gameObject.GetComponent<PlayerHealth> ();
			playerHP.receiveDamage (damage);
			nextDamage = Time.time + damageRate;
			if (knockback) {
				StartCoroutine(player.Knockback(0.02f, 50, player.transform.position));
			}
		}
	}
}
