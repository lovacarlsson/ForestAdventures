using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest_DoorToNextLevel : MonoBehaviour
{

    [SerializeField] int levelToLoad;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip levelClearedClip;

    Quest_Giver quest_Giver;
    PlayerState playerState;

    void Start(){
        quest_Giver = GameObject.Find("QuestGiverChest").GetComponent<Quest_Giver>();
        playerState = GameObject.Find("Player").GetComponent<PlayerState>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(quest_Giver.amountToCollect <= playerState.starAmount){
            GameObserver.SaveStarsToMemory(collision.GetComponent<PlayerState>().starAmount);
            audioSource.PlayOneShot(levelClearedClip);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}