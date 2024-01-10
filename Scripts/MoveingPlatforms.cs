using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingPlatforms : MonoBehaviour{

    List<Transform> platFormMoveLocation;
    
    int index = 0;
    void Start(){
        
        platFormMoveLocation = new List<Transform>(transform.parent.gameObject.GetComponentsInChildren<Transform>());
        platFormMoveLocation.RemoveAt(0);
        platFormMoveLocation.Remove(gameObject.transform);
    
    }

    
    void FixedUpdate(){

        float speed = 2 * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, (Vector2)platFormMoveLocation[index].position, speed);
        if((Vector2) transform.position == (Vector2) platFormMoveLocation[index].position) { 
            
            if(index + 1 == platFormMoveLocation.Count) {
                index = 0;
            }
            else{
                index++;
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.gameObject.tag == "Player") {
            collision.gameObject.transform.SetParent(gameObject.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
