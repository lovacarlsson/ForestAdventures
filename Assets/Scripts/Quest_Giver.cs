using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest_Giver : MonoBehaviour
{   
    [SerializeField] private int amountToCollect;
    [SerializeField] private GameObject houseToAppearWhenQuestIsComplete;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip questGiverClip;

    PlayerState playerState;
    public GameObject mentorCanvas, enterPrompt;
    public TextMeshProUGUI questText, nameText;
    public Transform checkpoint, player, mentor;
    private bool promptBool = false;
    void Start()
    {
        questText.GetComponent<TextMeshProUGUI>().enabled = true;
        playerState = GameObject.Find("Player").GetComponent<PlayerState>();
    }

    void Update(){
        MentorCheck();
    }

    void MentorCheck(){
        if(Vector2.Distance(player.position, checkpoint.position)<5f){
            mentorCanvas.SetActive(true);

            questText.text = "You've reached a checkpoint! This means that if you die you will respawn here. \n\nThere's an enemy ahead, you can kill it by jumping on it.";
        }
        else if(Vector2.Distance(player.position, mentor.position)<5f){
            mentorCanvas.SetActive(true);

            if (playerState.starAmount >= amountToCollect)
            {
                Quest_Player.isQuestComplete = true;
                houseToAppearWhenQuestIsComplete.SetActive(true);
                questText.text = "You've already collected " + amountToCollect + " stars? That was quick! \n\nSorry but I may ask another favour of you later, you can go rest in the house for now.";
            }
            else
            {
                if(promptBool == false){
                    enterPrompt.SetActive(true);
                    promptBool = true;
                }

                if(Input.GetKeyDown("return")){
                    enterPrompt.SetActive(false);
                    questText.text = "I have a little mission for you, could you go and collect " + amountToCollect + " stars? \n\nPlease, return here after you've collected " + amountToCollect + " stars.";
                    nameText.text = "Fox the Mentor";
                }
                else if(enterPrompt.activeSelf == true){
                    promptBool = false;
                    questText.text = "Hello there! I'm Fox and I'm going to be your mentor. \n\nIn order to move around and climb ladders use WASD or the Arrow Keys. \n\nUse SPACE to jump.";
                    nameText.text = "Fox";
                }
            }

            audioSource.PlayOneShot(questGiverClip);
        }
        else{
            mentorCanvas.SetActive(false);
            enterPrompt.SetActive(false);
        }
    }
}

