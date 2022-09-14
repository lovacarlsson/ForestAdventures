using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Giver : MonoBehaviour
{

    [SerializeField] private GameObject questGiverText;

    //Byta sprite när kistan är nära player
    [SerializeField] private Sprite ChestClosed;
    [SerializeField] private Sprite ChestOpen;

    [SerializeField] private Text textComponent;

    [SerializeField] private int amountToCollect = 1;
    [SerializeField] private string questBeginText;
    [SerializeField] private string questCompleteText;
    [SerializeField] private GameObject houseToAppearWhenQuestIsComplete;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip questGiverClip;

    //[SerializeField] public bool isQuestComplete = false;

    void Start()
    {
        questGiverText.SetActive(false);
        textComponent.text = questBeginText;



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //byta till sprite för öppen kista
        gameObject.GetComponent<SpriteRenderer>().sprite = ChestOpen;
        
        questGiverText.SetActive(true);
        if (collision.CompareTag("Player") == true) 
        {
            if (collision.GetComponent<PlayerState>().starAmount >= amountToCollect)
            {
                textComponent.text = questCompleteText;
                Quest_Player.isQuestComplete = true;
                houseToAppearWhenQuestIsComplete.SetActive(true);
            }

            else
            {
                textComponent.text = questBeginText;
            }

           
            //byta till sprite för öppen kista
            gameObject.GetComponent<SpriteRenderer>().sprite = ChestOpen;
            audioSource.PlayOneShot(questGiverClip);
       
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player") == true)
        {
            questGiverText.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().sprite = ChestClosed;
        }

    }



}

