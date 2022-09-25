using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winningmusic : MonoBehaviour
{
   [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip musicClip;
    public void PlayMusic()
    {
        audiosource.clip = musicClip;
        audiosource.Play();
    }
}
