using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Jump : MonoBehaviour
{

    [SerializeField] private float multiplySpeedBy = 2f;
    private PlayerMovement playerMovement;
    private bool isUsingMovementSpeed = false;
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip audioClip;
    private float timer = 0f;
    [SerializeField] private float timeBeforeReset;
    //F� tag p� animatorn som sitter p� gameobject
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Update()
    {
        if (isUsingMovementSpeed == true)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeReset)
            {
                playerMovement.ResetJumpForce();
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
            
                playerMovement.SetNewMovementJump(multiplySpeedBy);
                audiosource.PlayOneShot(audioClip);
                animator.enabled = false;
                spriteRenderer.enabled = false;

            }
            }

    }
}
