using UnityEngine;
using TMPro;

public class Points : MonoBehaviour{

    TMP_Text Score;
    AudioSource pickupSound;

    public static int point;
    void Start(){
        Score = GameObject.Find("points").GetComponent<TMP_Text>();
        pickupSound = GetComponent<AudioSource>();
        //scoreUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision){

        
        if (collision.gameObject.tag == "Player"){
            scoreUpdate();
        }

    }
    public void scoreUpdate() {
        pickupSound.Play();
        Points.point = Points.point + 1;
        Score.text = point.ToString();
        Destroy(gameObject);
    }
}
