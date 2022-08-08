using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f; //f stands for float 
    public float jumpSpeed = 4f;
    private float direction = 0f; //basicaly if we move left... this value will become -1 . and if we go to the right... it will become 1 ... or just left = negative, right = positive 
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private Animator playerAnimation; //to connect with animator 

    private Vector3 respawnPoint;
    public GameObject FallDetector;

    public HealthBar healthBar;

    

    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>(); // is also used to move on the ladder, leave it as is.. dont delete this ... 

        playerAnimation = GetComponent<Animator>(); //allows to change the parameters 

        respawnPoint = transform.position;


    }

    // Update is called once per frame
    void Update()
    {

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        // to draw a circle around the players feet, and checks if its overlapping on the ground layer ...aka the floor .. if it is touching ground, the variable will become true 
        //otherwise it will become false ... 


        Debug.Log(direction);
        direction = Input.GetAxis("Horizontal"); ///find out what the direction is .. is it negative or a positive number ... 

        if(direction > 0f) //for the right movement 
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);//vector is based on the x and y axis 
            transform.localScale = new Vector2(0.2224039f, 0.2224039f); //transform code.. this is the video about getting the character to change directions ... 
            // also the values in it are based on the characters x and y axis .. literally just copy and paste it .. THIS IS BASED ON THE SCALE VALUE! 

        }
        //these two are for the sprites, if the player is facing left or right .. 

        else if(direction < 0f) //for the left movement  
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);//vector is based on the x and y axis 
            transform.localScale = new Vector2(-0.2224039f, 0.2224039f); //same code as above.. however.. theres a negative so that the player can actually fucking turn wow ...
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y); //if the user is not moving left or right.. we must assume that the velocity is 0 

        }

        if(Input.GetButtonDown("Jump") && isTouchingGround == true) // if you press the space ... jump is in the settings and it has space assigned as the button for it...also checks 
                                                            //touching ground is true 

        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }



        playerAnimation.SetFloat("speed", Mathf.Abs(player.velocity.x)); //make sure that the variable name speed is the same as the one you chose to add back in animator ... 
        //remember that we are connecting with animator 
        //so in here we are getting the velocity of the player based on the x axis (when moving left, negative and right = positive) 
        playerAnimation.SetBool("onGround", isTouchingGround); //if the player is touching ground, it will pass that to the parameter of onGround that is based on the animator 


        FallDetector.transform.position = new Vector2(transform.position.x, FallDetector.transform.position.y); //y axis will keep their current position ... 






    }


    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }

        else if(collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }


        else if (collision.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //basically finding out the current scene that we are apart of . .
            //you can use SceneManager.LoadScene(0) where 0 is the number n where the level is avaiable .. 


            respawnPoint = transform.position;
        }

        else if (collision.tag == "PreviousLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            respawnPoint = transform.position;

        }

        else if(collision.tag == "Crystal")
        {
            Scoring.totalScore += 1;
            Debug.Log(Scoring.totalScore);
            collision.gameObject.SetActive(false);
        }


    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Spike")
        {
            healthBar.Damage(0.002f); // how much you will tkae off from the player ... 

        }
    }


    





}
