using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingSaw : MonoBehaviour{
    
    List<Transform> SawMoveMent;
    Animator playerAnimation;
    Rigidbody2D PlayerRB;
    AudioSource DeathSound;
    

    float speed = 360f;
    int index = 0;

    void Start(){
        
        SawMoveMent = new List<Transform>(transform.parent.gameObject.GetComponentsInChildren<Transform>());
        SawMoveMent.RemoveAt(0);
        SawMoveMent.Remove(gameObject.transform);


        playerAnimation = GameObject.FindWithTag("Player").GetComponent<Animator>();
        PlayerRB = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        DeathSound  = GetComponent<AudioSource>();
    }

    
    void FixedUpdate(){

        sawMoveing();
        sawRotate();


    }
    void sawRotate() {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }


    void sawMoveing() {
        float speed = 2f * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, (Vector2)SawMoveMent[index].position, speed);

        if ((Vector2)transform.position == (Vector2)SawMoveMent[index].position)
        {

            if (index + 1 == SawMoveMent.Count)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        
        if(collision.gameObject.tag == "Player") {

            DeathSound.Play();
            playerAnimation.SetTrigger("die");
            PlayerRB.bodyType = RigidbodyType2D.Static;
        }
    }
}
