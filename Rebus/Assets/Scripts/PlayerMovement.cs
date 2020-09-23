using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement of the player 
    private bool playerMoving;
    public float moveSpeed = 5.0f;
    public Vector3 mousePos;

    //for animation of the player
    private Animator anim;
    private Rigidbody2D myRigidbody;
    public Vector2 lastMove;
    public Vector2 posDif;
    private Vector2 movedir;


    public float moveX;
    public float moveY;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerMoving == true)
        {
            movement();
        }
        
        //check if player is idle
        movementCheck();
       
    }

    //set moving to true
    public void setMoving(bool moving)
    {
        playerMoving = moving;
    }

    void processInputs()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        movedir = new Vector2(moveX, moveY).normalized;
    }
    void movement()
    {
        playerMoving = false;

        

        processInputs();
        //horizontal
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            //collision
            myRigidbody.velocity = new Vector2(movedir.x * moveSpeed, movedir.y * moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            // lastMove = (mouseScreenPosition - (Vector2)transform.position).normalized;
        }
        //vertical 
        else if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime,0f));
            //collision
            myRigidbody.velocity = new Vector2(movedir.x * moveSpeed, movedir.y * moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));

            //  lastMove = (mouseScreenPosition - (Vector2)transform.position).normalized;
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        }
        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {

            //collision
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

    //check for movement
    void movementCheck()
    {
        if((Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) != true && (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) != true)
        {
            playerMoving = false;
        }
        else
        {
            playerMoving = true;
        }
    }
}
