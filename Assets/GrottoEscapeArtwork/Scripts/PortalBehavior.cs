using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PortalBehavior : MonoBehaviour {

	public int levelToLoad;

	public Vector3 destination;
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
				if (levelToLoad >= 0) {
					// play portal sound
					SoundManager.PlaySound ("portal");
					Application.LoadLevel (levelToLoad);
				} else {
					// play teleport sound
					SoundManager.PlaySound ("teleport");
					col.gameObject.transform.position = destination;
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			gm.portalHintText.text = ("");
		}
	}
}
