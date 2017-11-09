using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlatform : MonoBehaviour {

	private Rigidbody2D rb;
	public bool mayFall;
	public float fallDelay;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.isKinematic = true;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.collider.CompareTag ("Player") && mayFall) {
			StartCoroutine (Fall ());
		}
	}

	IEnumerator Fall() {
		yield return new WaitForSeconds (fallDelay);
		rb.isKinematic = false;
		yield return 0;
	}
}
