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
    [SerializeField] private AudioClip battleClip;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] public bool spawnBoss = false;
    bool hasSoundBeenPlayed;

  public void BeginSound ()
    {
        if (hasSoundBeenPlayed == false)
        {
            audioSource.PlayOneShot(screechClip);
            audioSource.PlayOneShot(explosionClip);
            audioSource.PlayOneShot(battleClip);
            Invoke("PlayGrowingClip", 2f);
            hasSoundBeenPlayed = true;
        }
      
    }

    private void PlayGrowingClip()
    {
        audioSource.PlayOneShot(growingClip);

    }


    /* private void SpawnBoss()
    {
        
        //Invoke("ShowBossAnimation", 0.5f);
    }
    */

}


       
  






