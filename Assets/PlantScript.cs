using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public int damage = 1;
    private bool isAlive = true;
    private bool isClose = false;
    private Animator animator;
    PlayerMovement Player;
    private SpriteRenderer spriteRenderer;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip deathclip;

    public Transform player, plant;

    private void Start(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        Player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    private void Update(){
        animator.SetBool("isAlive", isAlive);
        animator.SetBool("isClose", isClose);

        StartAttack();
    }

    private void StartAttack(){
        if(Vector2.Distance(player.position, plant.position)<5f){

            if(plant.transform.position.x > player.transform.position.x){
                spriteRenderer.flipX = false;
            }
            else{
                spriteRenderer.flipX = true;
            }

            isClose = true;

            if(this.animator.GetCurrentAnimatorStateInfo(0).IsName("P_PlantAttack")){

                isClose = false;
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;

            }
        }
        else{
            isClose = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(3);
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
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Player.JumpCall();
            //audioSource.PlayOneShot(deathclip); 
            Invoke("DestroyEnemy", 0.25f);
        }
    }


     private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void DumbAttack(){
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
