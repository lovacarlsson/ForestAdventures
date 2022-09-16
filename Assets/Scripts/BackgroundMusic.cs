using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
     
     
   public AudioSource audioSource;

    public AudioClip ambientclip;
    public AudioClip battleclip;

    void Start()
    {

        audioSource.clip = ambientclip;

        audioSource.Play();

    }






        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.CompareTag("Player") == true)
            {

                if (audioSource.clip == ambientclip)
                {

                    audioSource.clip = battleclip;
                //spelar ljudet från 15 sekunder in i ljudklippet
                    audioSource.time = 15f;

                    audioSource.Play();

                }

                else
                {

                    audioSource.clip = ambientclip;

                    audioSource.Play();

            }

        }

    }
}
