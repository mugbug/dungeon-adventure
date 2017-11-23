﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(OpenMainMenu());
	}
	
    IEnumerator OpenMainMenu()
    {
        print(Time.time);
        // wait for 2 seconds then open main menu
        yield return new WaitForSeconds(2);
        print(Time.time);
        Application.LoadLevel(5);
    }
}
