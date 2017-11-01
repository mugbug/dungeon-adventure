using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PortalBehavior : MonoBehaviour {

	public int levelToLoad;

	private GameMaster gm;

	void Start() {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			gm.portalHintText.text = ("[E] to activate portal");
		}

	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			if (Input.GetKeyDown ("e")) {
				Application.LoadLevel (levelToLoad);
			}
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			gm.portalHintText.text = ("");
		}
	}
}
