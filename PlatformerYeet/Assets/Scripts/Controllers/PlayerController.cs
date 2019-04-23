using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    //Used for walking and jumping
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;

    //Used to flip the player
    private bool facingRight = true;

    //Used to check if the player is on the ground, this is later used to reset the jumps
    //private bool isGrounded;
    public bool isGrounded { get { return Physics2D.Raycast(transform.position, -transform.up, checkRadius, whatIsGround); } }
    //public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //Used to set the amount of jumps the player can make in one go
    private int extraJumps;
    public int extraJumpsValue;

    //Animator is used for the player animations
    private Animator animator;
    public float timer = 0;
    private int inputValue;

	//Start is only called when the game starts
	void Start () {

        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        //animator.Play("Walk");
    }
	
    //FixedUpdate is called on every physical change in the game
    void FixedUpdate(){

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed,rb.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            Flip();
           
        } else if(facingRight == true && moveInput < 0)
        {
            Flip();
           
        }


    }

    //This update is called on every frame
    void Update()
    {
        timer += Time.deltaTime;

        Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - checkRadius), Color.red);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            inputValue = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            inputValue = 2;
        }

        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            inputValue = 0;
        }



        if (inputValue == 0)
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
            animator.Play("Idle");
        }
        else if (inputValue == 1)
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", true);
            animator.SetBool("isAttacking", false);
            animator.Play("Walk");
        }
        else if (inputValue == 2)
        {


            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", true);
            animator.Play("Attack");
           
            if(timer > 2.6f)
            {
                inputValue = 0;
                timer = 0;
            }

        }






        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
           
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;

            
        }
        else if(isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

    }

    //Flips the character if the player moves side to side
    void Flip()
    {

        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }

    void Attack()
    {
        

    }
}
