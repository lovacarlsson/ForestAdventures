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

    public float timeBetweenShots = 2;
    public Transform player, shootPos;
    public float range, shootSpeed;
    private float distanceToPlayer;
    public GameObject fireBall;
    private bool canShoot;
    PlayerMovement Player;

    private void Start()
    {
        spriteRenderer.enabled = false;
        canShoot = true;
        Player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }


    private void Update()
    {
      distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= range)
        {

            if (canShoot) 
            {
                StartCoroutine(Shoot());


            }
           

        }


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

    IEnumerator Shoot()
    {

        if (spriteRenderer.enabled == true)
        {
            var r = Random.Range(0f, 2);

            canShoot = false;
            yield return new WaitForSeconds(timeBetweenShots);
            GameObject newFireball = Instantiate(fireBall, shootPos.position, Quaternion.identity);
            newFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * (-distanceToPlayer * r) * Time.fixedDeltaTime, 0);
            canShoot = true;
        }


        
    }
    
}



    
