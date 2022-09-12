using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Speed : MonoBehaviour
{

    [SerializeField] private float multiplySpeedBy = 1.5f;
    private PlayerMovement playerMovement;
    private bool isUsingMovementSpeed = false;
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip audioClip;
    private float timer = 0f;
    [SerializeField] private float timeBeforeReset;
    //Få tag på animatorn som sitter på gameobject
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Update()
    {
        if (isUsingMovementSpeed == true)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeReset)
            {
                playerMovement.ResetMovementSpeed();
                timer = 0f;
                isUsingMovementSpeed = false;
                animator.enabled = true;
                spriteRenderer.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUsingMovementSpeed == false) 
        { 
            if (collision.CompareTag("Player") == true)
            {
                if (playerMovement == null)
                {
                    playerMovement = collision.GetComponent<PlayerMovement>();
                }
            
                isUsingMovementSpeed = true;
            
                playerMovement.SetNewMovementSpeed(multiplySpeedBy);
                audiosource.PlayOneShot(audioClip);
                animator.enabled = false;
                spriteRenderer.enabled = false;

            }
            }

    }
}
