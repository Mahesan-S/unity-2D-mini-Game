using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour{

    public void Play() {
        Points.point = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit() { 
        
        Application.Quit();
    }
    public void PlayAgain() {
        Points.point = 0;
        SceneManager.LoadScene("Level 1");
    }
    public void Startmenu() {
        SceneManager.LoadScene("menu");
    }
    
}
