using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressBtn_OpenGate : MonoBehaviour{
    Animator gateAnimation;
    
    private void Start(){
       gateAnimation = GameObject.FindWithTag("gates").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "boxs"){
            StartCoroutine(OpenGate());
        }
    }

    IEnumerator OpenGate() {

        gateAnimation.enabled = true;
        yield return new WaitForSeconds(4f);
        gateAnimation.SetTrigger("open");
    }

}
