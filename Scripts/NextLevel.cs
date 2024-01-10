using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour{

    AudioSource victorySound;
 
    bool soundPlay;

    private void Start(){
        
        soundPlay = false;
        
        victorySound = GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.gameObject.tag == "Player" && soundPlay == false) {
            victorySound.Play();
            soundPlay = true;
            Invoke("nextLevel", 2f);
            //print("next stage");
        }
    }

    void nextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
