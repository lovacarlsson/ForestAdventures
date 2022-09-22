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
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip deathclip;

    public Transform player, plant;

    private void Start(){
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
            isClose = true;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            if(this.animator.GetCurrentAnimatorStateInfo(0).IsName("PlantAttack")){
               StartCoroutine(Attack(100f)); 
            }
        }
        else{
            isClose = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    IEnumerator Attack(float timeOut){
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        isClose = false;
        yield return new WaitForSeconds(timeOut);
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
            audioSource.PlayOneShot(deathclip); 
            Invoke("DestroyEnemy", 0.25f);
        }
    }


     private void DestroyEnemy()
    {

        Destroy(gameObject);
    }
}
