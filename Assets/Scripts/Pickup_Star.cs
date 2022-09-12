using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Star : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupClip;

    [SerializeField] private SpriteRenderer spriterenderer;
    [SerializeField] private Animator animator;
    
    private bool canPickupStar = true;

    private bool removeGameObject = false;
    private float timer = 0f;
    [SerializeField] private float timeBeforeDeletion = 1f;


    private void Update()
    {
        if (removeGameObject == true)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeDeletion)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if (canPickupStar == true)
            {
                collision.GetComponent<PlayerState>().StarPickup();
                spriterenderer.sprite = null;
                animator.enabled = false;
                removeGameObject = true;
                canPickupStar = false;
                

                audioSource.PlayOneShot(pickupClip);
                audioSource.pitch = Random.Range(0.9f, 1.1f);
            }
          
            
        }
    }
}
