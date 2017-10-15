using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHit : MonoBehaviour {

	public float fireDamage;
	FireBehavior fireBehavior;

	// Use this for initialization
	void Awake () {
		fireBehavior = GetComponentInParent<FireBehavior> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			Destroy (gameObject);
		}
	}
}
