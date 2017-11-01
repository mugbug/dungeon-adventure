using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
	public int score;

	public Text scoreText;
	public Text portalHintText;

	void Update () {
		scoreText.text = (""+score);
	}
}
