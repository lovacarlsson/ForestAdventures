using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainToBossFightMusic : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
  

    public AudioClip bossFightclip;

    void Start()
    {
        audioSource.Play();

    }






    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") == true)
        {
                audioSource.clip = bossFightclip;

                audioSource.Play();

            

        }

    }






}
