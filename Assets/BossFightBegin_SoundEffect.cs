using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BossFightBegin_SoundEffect : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip screechClip;
    [SerializeField] private AudioClip explosionClip;
    [SerializeField] private AudioClip growingClip;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] public bool spawnBoss = false;
    bool HasBeenTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
           if (HasBeenTriggered == false)
            {
                audioSource.PlayOneShot(screechClip);
                audioSource.PlayOneShot(explosionClip);

                Invoke("PlayGrowingClip", 2f);
                HasBeenTriggered = true;
            }
      
           
        }

        // TODO:skaka kameran

        

    }

    private void PlayGrowingClip()
    {
        audioSource.PlayOneShot(growingClip);

    }


    private void SpawnBoss()
    {
        trailRenderer.enabled = true;
        Invoke("ShowBossAnimation", 0.5f);
    }

  
}





