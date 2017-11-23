using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;

    void Start(){
        PauseUI.SetActive(false);
    }

    private void Update(){
        if (Input.GetButtonDown("Pause")){
            paused = !paused;
        }
        if (paused){
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        else{
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Resume(){
        paused = false;
    }

    public void RestartLevel(){
        Application.LoadLevel(Application.loadedLevel);
    }

    public void RestartGame(){
        Application.LoadLevel(0);
    }

    public void Quit(){
        Application.Quit();
    }
}
