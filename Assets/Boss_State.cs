using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Boss_State : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Animation bossIdle;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] new ParticleSystem particleSystem;

    private void Start()
    {
        spriteRenderer.enabled = false;
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            Invoke("EnableParticles", 1.8f);
            Invoke("EnableSprite", 2f);
            
            

        }
    }

    private void EnableSprite()
    {
        spriteRenderer.enabled = true;
        
    }

    private void EnableParticles()
    {
        particleSystem.Play();
    }
}



    
