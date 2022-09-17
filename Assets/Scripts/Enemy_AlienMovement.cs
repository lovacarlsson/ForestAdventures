using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AlienMovement : MonoBehaviour
{
    public float speed = 5f;
    private float movementDirection = 1f;

    Rigidbody2D rigidBod;

    private Animator animator;

    PlayerMovement Player;


    bool isGrounded;

    public GameObject groundCheck;

    private bool isAlive = true;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip enemyDeathClip;
    [SerializeField] private LayerMask groundLayer;




    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        rigidBod = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {

        //Animationer d�d/alive
        animator.SetBool("IsAlive", isAlive);
        animator.SetBool("IsGrounded", isGrounded);


    }
    void FixedUpdate()
    {
        if (isGrounded == true && isAlive == true)
        {
            Vector3 newPosition = gameObject.transform.position;
            newPosition.x += speed * Time.fixedDeltaTime * movementDirection;
            rigidBod.MovePosition(newPosition);


        }

        if (isAlive)
        {
            CheckforGround();

            if (isGrounded == false)
            {
                ChangeDirection();
            }
        }

        

    }

    private void CheckforGround()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f, groundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                isGrounded = true;
        }
    }
    private void ChangeDirection()
    {
        movementDirection = -movementDirection;
        Vector3 newScale = gameObject.transform.localScale;
        newScale.x = movementDirection;
        gameObject.transform.localScale = newScale;

    }

    public void KillMe()
    {
        isAlive = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Vector2 killForce = new Vector2(movementDirection, 4f);
        //f� den att inte falla
        rigidBod.gravityScale = 0;
        Player.JumpCall();


        audioSource.PlayOneShot(enemyDeathClip);

        Invoke("DestroyEnemy", 0.25f);
          
        

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") == true)
        {
             ChangeDirection();
        }
    }


    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

}
