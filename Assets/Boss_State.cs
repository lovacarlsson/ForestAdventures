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
    [SerializeField] AudioClip deathclip;
    [SerializeField] AudioClip deatheffect;
    
    [SerializeField] AudioSource audioSource;
    public float timeBetweenShots = 2;
    public Transform player, shootPos;
    public float range, shootSpeed;
    private float distanceToPlayer;
    public GameObject fireBall;
    private bool canShoot;
    PlayerMovement Player;
    PlayBossMusicTrigger BossEntrance;
    BossSpawnTrigger BossSpawn;
    private Vector3 lastPlayerPosition;
    private int damage = 1;
    bool isDead = false;
    bool hasMusicPlayed = false;
    ParticleSystem BossAlwaysParticles;
    bool hasparticlesbeenplayed;
    BossFightBegin_SoundEffect BossEntranceSound;
    ParticleSystem BossSpawnParticles;
    bool attack;
    Winningmusic WinningmusicScript;

    private void Start()
    {
        spriteRenderer.enabled = false;
        canShoot = true;
        Player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        BossEntrance = GameObject.Find("Music_Bossfight").GetComponent<PlayBossMusicTrigger>();
        BossSpawn = GameObject.Find("SpawnTrigger").GetComponent<BossSpawnTrigger>();
        BossSpawn.BossIsDead = true;
        BossAlwaysParticles = GameObject.Find("BossAlwaysParticles").GetComponent<ParticleSystem>();
        BossEntranceSound = GameObject.Find("BossFightBeginEffect").GetComponent<BossFightBegin_SoundEffect>();
        BossSpawnParticles  = GameObject.Find("BossSpawnParticles").GetComponent<ParticleSystem>();
        WinningmusicScript = GameObject.Find("Winningmusic").GetComponent<Winningmusic>();
    }


    private void Update()
    {
        
        animator.SetBool("attack", attack);
        animator.SetBool("isDead", isDead);
      distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= range)
        {
            if (canShoot) 
            {
                StartCoroutine(Shoot());
            }
        }

        if (Player.killedPlant >= 3)
        {
            canShoot = false;
            isDead = true;
            if (hasMusicPlayed == false)
            {
                BossEntranceSound.StopMusic();  
                PlayDeathSoundEffects();
                Invoke("DisableSprite", 0.5f);
                WinningmusicScript.PlayMusic();
           

            }
            
            BossSpawn.BossIsDead = true;
            DisableSprite();

        }

        if (BossSpawn.BossIsDead == false)
        {
            BossEntranceSound.BeginSound(); //L�gg till battlemusik och partikelexplosion
            
            if (hasparticlesbeenplayed == false)
            {
                
                Invoke("EnableSpriteAndAlwaysParticles", 2f);
                BossSpawnParticles.Play();
                hasparticlesbeenplayed = true;
            }


        }
        if (canShoot == true)
        {
            Invoke("DoAttackAnimation", 1f);
            attack = false;
        }
       if (canShoot == false)
        {
            attack = false;
        }

    }

    
  void DoAttackAnimation()
    {
        attack = true;
    }

    

    IEnumerator Shoot()
    {
        if (spriteRenderer.enabled == true)
        {
           
            var r = 1f;
            if (lastPlayerPosition != player.position)
            {
                Random.Range(0f, 2);
            }
           
            canShoot = false;
            yield return new WaitForSeconds(timeBetweenShots);
            GameObject newFireball = Instantiate(fireBall, shootPos.position, Quaternion.identity);
            newFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * (-distanceToPlayer * r) * Time.fixedDeltaTime, 0);

            lastPlayerPosition = player.position;

            canShoot = true;
           
        }

    }



  
    private void EnableParticles()
    {
        particleSystem.Play();
    }
    private void DisableParticles ()
    {
        particleSystem.Stop();
    }
    private void EnableSprite()
    {
        spriteRenderer.enabled = true;

    }
    private void DisableSprite()
    {
        spriteRenderer.enabled = false;

    }
    private void PlayDeathSoundEffects()
    {
        audioSource.PlayOneShot(deatheffect);
        audioSource.PlayOneShot(deathclip);
        hasMusicPlayed = true;
    }
    private void EnableAlwaysParticles ()
    {
        BossAlwaysParticles.Play();
    }
    private void EnableSpriteAndAlwaysParticles ()
    {
        EnableSprite();
        EnableAlwaysParticles();
    }
}




