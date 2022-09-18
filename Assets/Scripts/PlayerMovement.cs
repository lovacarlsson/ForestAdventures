using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    // Rigidbody2D referens
    private Rigidbody2D rigidbod;

    //referens till sprite renderer (f�r att kunna flippa x)
    private SpriteRenderer spriteRenderer;

    //F� tag p� animatorn som sitter p� gameobject
    private Animator animator;

    //Groundcheck referens
    public GameObject groundCheck;

    // Definierar hastigheten
    public float movementspeed = 1f;
    private float defaultMovementSpeed;

    private float defaultJumpForce;
    public float jumpforce = 1f;
    private float moveDirection = 0f;
    private float moveDirectionY = 0f;
    private bool isJumpPressed = true;

    //isgrounded?
    private bool isGrounded;


    public Transform ladder;

    //ishurt?

    public bool isHurt;
    public bool isFalling;
   

    //Boolean f�r sprite renderer (facing right)?
    private bool isfacingLeft = false;

    //Velocity
    private Vector3 velocity;

    //SmoothTime
    public float smoothTime = 0.2f;


    public TrailRenderer trail;

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask ladderLayer;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpClip;


    void Start()
    {
        //spelaren ska b�rja med hastigheten 1, s� vi sedan kan �ndra p� variabeln movementspeed f�r pickups
        defaultMovementSpeed = movementspeed;

        defaultJumpForce = jumpforce;
        //F� tag p� komponenten Animator
        animator = gameObject.GetComponent<Animator>();
        
        //Rigidbody-mekanik
        rigidbod = gameObject.GetComponent<Rigidbody2D>();

        //Spriterenderer
        spriteRenderer = rigidbod.GetComponent<SpriteRenderer>();

        //Isfacingright �r true vid start
        isfacingLeft = true;

    }

 

    private void Move(Vector3 moveDirection, bool isJumpPressed)

    {
        rigidbod.velocity = Vector3.SmoothDamp(rigidbod.velocity, moveDirection, ref velocity, smoothTime);
        if (isJumpPressed == true && isGrounded == true)
        {
            rigidbod.AddForce(new Vector2(0f, jumpforce));
        }

        if (moveDirection.x > 0f && isfacingLeft == true)
        {
            FlipSpriteDirection();
        }
        else if (moveDirection.x < 0f && isfacingLeft == false)
        {
            FlipSpriteDirection();
        }

    }



    void Update()

    {

        moveDirectionY = Input.GetAxis("Vertical");
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            isJumpPressed = true;
            animator.SetTrigger("DoJump");
            audioSource.PlayOneShot(jumpClip);
            audioSource.pitch = Random.Range(0.8f, 1.5f);

        }
        
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(moveDirection));
        animator.SetBool("IsHurt", isHurt);
        animator.SetBool("IsFalling", isFalling);


        if (isHurt == true) 
        {
            //print ("im hurt!")
        }
    }





    private void FixedUpdate()
    {

        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                isGrounded = true;
        }

        Vector3 calculatedMovement = Vector3.zero;
        float verticalVelocity = 0f;

        if (isGrounded == false)
        {
          verticalVelocity = rigidbod.velocity.y;
        }

        //Spelaren hoppar best�mt av jumpforce
        calculatedMovement.x = movementspeed * 100f * moveDirection * Time.fixedDeltaTime;
        if(isLadder()){
            rigidbod.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            animator.SetBool("isClimbing", false);
            if(moveDirectionY != 0f){
                rigidbod.constraints = RigidbodyConstraints2D.FreezeRotation;
                calculatedMovement.y = movementspeed * 5f * moveDirectionY;
                animator.SetBool("isClimbing", true);
            }
        }
        else{
            calculatedMovement.y = verticalVelocity;
            animator.SetBool("isClimbing", false);
            rigidbod.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        Move(calculatedMovement, isJumpPressed);
        isJumpPressed = false;
    }



    private void FlipSpriteDirection() //Funktion f�r att flippa x
    {
        spriteRenderer.flipX = !isfacingLeft;
        isfacingLeft = !isfacingLeft;

    }

    public bool IsFalling()
    {
        if (rigidbod.velocity.y < -1f)
        {
            isFalling = true;
            return true;
        }
        return false;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyAlien") == true)
        {
           
            isHurt = true;
            animator.SetBool("IsHurt", isHurt);
            Invoke("TakingDamageAnimation", 1f);
            print("Nu borde jag se skadad ut");
        }
    }

    private bool isLadder(){
        return Physics2D.OverlapCircle(groundCheck.transform.position, 0.1f, ladderLayer);
    }

    public void TakingDamageAnimation()
    {
        isHurt = false;

    }

    public void ResetMovementSpeed()
    {
        movementspeed = defaultMovementSpeed;

    }
    public void SetNewMovementSpeed(float multiplyBy)
    {
        movementspeed *= multiplyBy;

    }

    public void JumpCall(){
        rigidbod.velocity = new Vector2(rigidbod.velocity.x, 10f);
    }

    public void SetNewMovementJump(float multiplyBy){
        jumpforce *= multiplyBy;
    }

        public void ResetJumpForce()
    {
        jumpforce = defaultJumpForce;

    }

}






































