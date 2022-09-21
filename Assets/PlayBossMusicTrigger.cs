using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBossMusicTrigger : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    BossSpawnTrigger BossSpawn;

    public AudioClip bossFightclip;
    Boss_State boss;

    void Start()
    {
        audioSource.Play();
        BossSpawn = GameObject.Find("SpawnTrigger").GetComponent<BossSpawnTrigger>();
    }

        private void OnTriggerEnter2D(Collider2D collider)
    {

        if (BossSpawn.BossIsDead == false) 
        {
            audioSource.clip = bossFightclip;
            audioSource.Play();
   
        }

    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    private void Update()
    {
        if (BossSpawn.BossIsDead == true)
        {
            StopMusic();
        }

    }


}
