using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
	static int score;

	public Text scoreText;
	public Text portalHintText;

    private PlayerHealth ph;
    private SpriteRenderer fireball;

    void Start () {
		if (Application.loadedLevel == 0) {
			score = 0;
		}
        ph = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

	void Update() { 
		scoreText.text = (""+score);
	}

	public void incrementScore() {
		score += 1;
        if (score % 50 == 0){
            SoundManager.PlaySound("specialItem");
            ph.addHealthPoint();
        }
        if (score % 100 == 0){
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().changeColor();
        }
	}
}
