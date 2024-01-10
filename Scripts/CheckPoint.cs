using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour{
    
    Transform checkPointPostion;
    AudioSource checkPointSound;
    Animator FlagAnimation;
    PlayerMovement playerScript;

    bool checkPointStates = false;


    private void Start(){
        checkPointPostion = GetComponent<Transform>();
        checkPointSound = GetComponent<AudioSource>();
        FlagAnimation = GetComponent<Animator>();
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.gameObject.tag == "Player") {

            FlagAnimation.enabled = true;
            playerScript.ReSpawn = (Vector2)checkPointPostion.position;

            if(checkPointStates == false) {
                checkPointSound.Play();
                checkPointStates = true;
            }

        }
    }
}
