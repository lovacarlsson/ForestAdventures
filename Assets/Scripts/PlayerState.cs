using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int healthpoints = 3;
    public int initalHealthPoints = 3;

    
    public int starAmount = 0;

    private GameObject respawnPosition;
   [SerializeField] private GameObject startPosition;
    [SerializeField] private bool useStartPosition;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioClip hurtClip;

    private void Start()

    {
        if (useStartPosition == true)
        {
            gameObject.transform.position = startPosition.transform.position;
        }
            
        healthpoints = initalHealthPoints;
        respawnPosition = startPosition;
        
    }

    public void DoHarm(int doHarmByThisMuch)
    {
        healthpoints -= doHarmByThisMuch;
        print("doesdamage");

        if (healthpoints <= 0) {
            print("playerdead");

            Respawn();
        }else
        {
           audioSource.PlayOneShot(hurtClip);
        }

    }

    public void Respawn()
    {
        healthpoints = initalHealthPoints;

        gameObject.transform.position = respawnPosition.transform.position;
        audioSource.PlayOneShot(deathClip);

    }

    public void StarPickup()
    {
        starAmount++;

    }

    public void ChangeRespawnPosition(GameObject newRespawnPosition)
    {
        respawnPosition = newRespawnPosition;
    }


    //F�rs�k till att st�nga av animationen n�r spelaren d�r men vet inte hur jag ska referera till boolean i detta skript.
    public void StopDeathAnimation (Collider2D collision) 
    
    {
        if (initalHealthPoints <= 0) {
            collision.GetComponent<PlayerMovement>().isHurt = false;
            
        }
    }
}
