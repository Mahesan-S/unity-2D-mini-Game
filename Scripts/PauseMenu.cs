using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{
    
    public static bool GameIsPause = false;
    public GameObject pauseBtnUI;
    AudioSource BGM;

    void Start(){

        BGM = GameObject.Find("BGM").GetComponent<AudioSource>();   
    }
    void Update(){

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPause)
                {
                    resume();
                }
                else
                {
                    pause();
                }
            }
        
    }

    public void resume() {
        
        pauseBtnUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        BGM.Play();
    }

    public void pause() {
        
        pauseBtnUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        BGM.Pause();        
    }
    public void StatingMenu() {
        SceneManager.LoadScene("menu");
    }
    public void quit() {
        Application.Quit();
    }
}
