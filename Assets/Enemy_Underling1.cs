using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Underling1: MonoBehaviour
{
    [SerializeField] Animator animator;
    bool isAlive = true;
    PlayerMovement Player;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip deathClip;
    bool underling1IsKilled = false;
    private void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        animator.SetBool("isAlive", isAlive);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("kollision");
            isAlive = false;
            print ("isAlive is false");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Player.JumpCall();
            audioSource.PlayOneShot(deathClip);
            underling1IsKilled = true;
            Invoke("DestroyEnemy", 0.25f);
           
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
