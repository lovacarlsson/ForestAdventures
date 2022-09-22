using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public int damage = 1;
    private bool isAlive = true;
    private Animator animator;
    PlayerMovement Player;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip deathclip;

    private void Start(){
        animator = gameObject.GetComponent<Animator>();
        Player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    private void Update(){
        animator.SetBool("isAlive", isAlive);
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
            audioSource.PlayOneShot(deathclip); 
            Invoke("DestroyEnemy", 0.25f);
        }
    }


     private void DestroyEnemy()
    {

        Destroy(gameObject);
    }
}
