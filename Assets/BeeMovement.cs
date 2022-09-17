using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    public Transform upperPos,downPos;
    [SerializeField] private float speed;
    public bool beeIsUp;
    public int damage = 1;
    private bool isAlive = true;
    private Animator animator;
    PlayerMovement Player;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        Player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        
    }



    private void Update()
    {
        animator.SetBool("isAlive", isAlive);
        StartMovement();
        
    }

    void StartMovement()
    {
        if(transform.position.y <= downPos.position.y){
            beeIsUp = false;
        }
        else if(transform.position.y >= upperPos.position.y)
        {
            beeIsUp = true;
        }

        if (beeIsUp == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, downPos.position, speed*Time.deltaTime);  

        }
        else if (beeIsUp == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, upperPos.position, speed * Time.deltaTime);
        }

            



}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            collision.gameObject.GetComponent<PlayerState>().DoHarm(damage);


        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            
            isAlive = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            Player.JumpCall();
            Invoke("DestroyEnemy", 0.25f);
        }
    }


     private void DestroyEnemy()
    {

        Destroy(gameObject);
    }


}
