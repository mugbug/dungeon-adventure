using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] HealthSprites;

	public Image HealthUI;

	private PlayerHealth playerHealth;

	void Start(){
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
	}

	void Update(){
		HealthUI.sprite = HealthSprites [playerHealth.getCurrentHealth()];
	}
}
