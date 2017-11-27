using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth;
	static int currentHealth;

	PlayerBehavior controlMovement;
    Animator animator;
	// Use this for initialization
	void Start () {
		if (Application.loadedLevel == 1) {
			currentHealth = maxHealth;
		}

		controlMovement = GetComponent<PlayerBehavior> ();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void receiveDamage (int damage) {
		if (damage <= 0)
			return;
        SoundManager.PlaySound("damage");
		currentHealth -= damage;
		gameObject.GetComponent<Animation> ().Play ("PlayerRedFlash");
		if (currentHealth <= 0) {
			makeDead ();
		}
	}

	public void makeDead () {
//		Destroy (gameObject);
		Application.LoadLevel(6);
		currentHealth = maxHealth;
	}

	void OnTriggerEnter2D (Collider2D col) {
		/*if (col.CompareTag("EnergyCapsule")) {
			Destroy (col.gameObject);
			if (currentHealth + 1 >= 6)
				currentHealth = 6;
			else
				currentHealth += 1;
		}*/
		if (col.CompareTag ("EnergyTank")) {
            SoundManager.PlaySound("specialItem");
			Destroy (col.gameObject);
			if (currentHealth + 1 >= 6)
				currentHealth = 6;
			else
				currentHealth += 1;
		}
	}

	public int getCurrentHealth() {
		return currentHealth;
	}

    public void addHealthPoint(){
        if (currentHealth + 1 >= 6){
            currentHealth = 6;
        }
        else{
            currentHealth++;
        }
    }
}
