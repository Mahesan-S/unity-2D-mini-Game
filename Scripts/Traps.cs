
using UnityEngine;

public class Traps : MonoBehaviour{
    
    Transform sawTranform;
    Animator playerAnimation;
    Rigidbody2D playerRB;
    AudioSource DeathSound;
    
    
    public float Speed;

    void Start(){
        Speed = 10f;

        DeathSound = GetComponent<AudioSource>();
        sawTranform = GetComponent<Transform>();
        playerAnimation = GameObject.FindWithTag("Player").GetComponent<Animator>();
        playerRB = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        

    }

    void FixedUpdate(){
        
        if (gameObject.tag == "traps") {
            sawRotate();  
        }
        
    }

    public void sawRotate() {
        sawTranform.Rotate(0f, 0f, Speed);
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player") {

            DeathSound.Play();
            playerAnimation.SetTrigger("die");
            playerRB.bodyType = RigidbodyType2D.Static;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
