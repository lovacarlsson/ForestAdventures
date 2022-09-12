using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest_DoorToNextLevel : MonoBehaviour
{

    [SerializeField] int levelToLoad;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip levelClearedClip;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if (Quest_Player.isQuestComplete == true) {
                GameObserver.SaveStarsToMemory(collision.GetComponent <PlayerState>().starAmount);
                audioSource.PlayOneShot(levelClearedClip);
                SceneManager.LoadScene(levelToLoad);

            }
        }
    }
}