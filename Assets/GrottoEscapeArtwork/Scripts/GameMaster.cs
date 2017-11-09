using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
	static int score;

	public Text scoreText;
	public Text portalHintText;

	void Start () {
		if (Application.loadedLevel == 0) {
			score = 0;
		}
	}

	void Update () {
		scoreText.text = (""+score);
	}

	public void incrementScore() {
		score += 1;
	}
}
