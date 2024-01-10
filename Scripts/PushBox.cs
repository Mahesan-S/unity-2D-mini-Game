using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour {

    bool NowMove;
    Rigidbody2D boxRB;
    [SerializeField] GameObject instru;
    private void Start(){
        boxRB = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        if(Input.GetKey(KeyCode.V)){
            NowMove = true;
        }
        else {
            NowMove = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player") {
            instru.SetActive(true);
        }
    }
    private void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            if (NowMove) {
                boxRB.mass = 70;
                transform.SetParent(collision.gameObject.transform);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        transform.SetParent(null);
        boxRB.mass = 100;
        NowMove = false;
        instru.SetActive(false);
    }
}
