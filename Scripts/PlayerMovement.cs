using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    [SerializeField] float playerSpeed = 7.5f;
    float playerJump = 7f;
    float Dirt_X;
    bool PlayerOnGround = false;


    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer playerSprite;
    AudioSource jumpSound;
    public Vector2 ReSpawn;
    

    enum PlayerMoveMentStates { idle ,running, falling,jumping };
    PlayerMoveMentStates PlayerStates;
    void Start(){

        ReSpawn  = new Vector2(transform.position.x,transform.position.y);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        jumpSound = GetComponent<AudioSource>();

        PlayerStates = PlayerMoveMentStates.idle;
    }

    private void FixedUpdate(){
        Dirt_X = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(Dirt_X * playerSpeed, rb.velocity.y);

        if(Input.GetAxisRaw("Jump") == 1 && PlayerOnGround == true) {
            jump();
            
        }
        AnimationStates();
    }

    void jump() {
        rb.velocity = new Vector2(rb.velocity.x,playerJump);
        jumpSound.Play();
    }
    void AnimationStates() { 

        if(Dirt_X != 0f) {

            PlayerStates = PlayerMoveMentStates.running;

            if(Dirt_X >= 0) {
                playerSprite.flipX = false;
            }
            else {
                playerSprite.flipX = true;
            }
        }
        else {
            PlayerStates = PlayerMoveMentStates.idle;
        }
                    //--------------------------------------jump States Check
        if(Input.GetAxisRaw("Jump") == 1) {
            PlayerStates = PlayerMoveMentStates.jumping;
        }
        else if (PlayerOnGround == false)
        {
            PlayerStates = PlayerMoveMentStates.falling;
        }

        anim.SetInteger("States", (int)PlayerStates);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //print("enter");
       
        for(int i =0; i<collision.contactCount; i++) {

            Vector2 normal = collision.GetContact(i).normal;
            //print(normal);
            if(normal.x < 0.80f) {
                PlayerOnGround = true;
            }
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision){
        
        for (int i = 0; i < collision.contactCount; i++){

            Vector2 normal = collision.GetContact(i).normal;
            
            if (normal.x < 0.80f){
                PlayerOnGround = true;
            }
        }

    }
    private void OnCollisionExit2D(Collision2D collision){
        //print("exit");
        PlayerOnGround = false;

    }

    public void RestartLevel(){
            reswapn();
    }
    
    public void reswapn() {
        transform.position = ReSpawn;
        anim.SetTrigger("apper");
        
        rb.bodyType = RigidbodyType2D.Dynamic;
        //anim.SetInteger("states", 0);
    }
}
