using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour{

    [SerializeField] Transform destination;
    Transform playerTranform;
    Rigidbody2D playerRB;
    Animator playerAnimation;

    void Start(){
        playerTranform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        playerRB = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        playerAnimation = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    void Update(){
        //print(Vector2.Distance(playerTranform.position, destination.position));
    }
    private void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject.CompareTag("Player")) {

            if (Vector2.Distance(playerTranform.position, transform.position) > 0.3f) {
                StartCoroutine(PortalIn());
            }
        }
    }

    IEnumerator PortalIn() {
        
        playerRB.simulated = false;
        playerAnimation.SetTrigger("PortalIn");
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(PortalObserve());
        playerTranform.position = destination.position;
        playerRB.velocity = Vector2.zero;
        playerAnimation.SetTrigger("apper");
        
        yield return new WaitForSeconds(0.5f);
        playerRB.simulated= true;
    }

    IEnumerator PortalObserve() {
        float timer = 0f;
        while(timer < 0.5f) {
            playerTranform.position = Vector2.MoveTowards(playerTranform.position, this.transform.position, 3 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }

    }
}
