using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Level3Quest : MonoBehaviour
{   
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip questGiverClip;
    public GameObject mentorCanvas, enterPrompt;
    public TextMeshProUGUI questText;
    public Transform player, mentor, checkpoint;
    public Image mentorIcon;
    public Sprite shocked, calm;
    PlayerMovement Player;
    private bool promptBool = false;
    private bool questBool = false;
    private bool checkpointBool = false;
    void Start()
    {
        questText.GetComponent<TextMeshProUGUI>().enabled = true;
        Player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update(){
        MentorCheck();
    }

    void MentorCheck(){
        if(Vector2.Distance(player.position, mentor.position)<2.5f){
            if(questBool == false){
                mentorCanvas.SetActive(true);
            }

            if(promptBool == false){
              enterPrompt.SetActive(true);
              promptBool = true;
            }

            if(Input.GetKeyDown("return") && questBool == false){
              enterPrompt.SetActive(false);
              questText.text = "This cave has long been infested with all kinds of dangerous creatures but at some point an enormous plant-monster appeared, since then it has unendingly terrorized us.\n\nSince then life around here has become a nightmare, please get rid of the monster.";
              questBool = true;

            }
            else if(enterPrompt.activeSelf == true){
              questText.text = "Sorry to drag you all the way down here but I once again need your help. \n\nAfter seeing how well you handled bees in the previous cave I thought you might be up to the task";
              promptBool = false;
            }
        }
        else if(Vector2.Distance(player.position, checkpoint.position)<5f){
            
            if(checkpointBool == false){
                mentorCanvas.SetActive(true);
                questText.text = "Oh, wow! It hasn't rained this much since the monster originally appeared. \n\nYou may be in for a tough fight, I'm sorry but I'm of no help here, do your best!";
                mentorIcon.sprite = shocked;
                checkpointBool = true;
            }

        }
        else if(Player.killedPlant >= 3){
            enterPrompt.SetActive(true);
            mentorCanvas.SetActive(true);
            mentorIcon.sprite = shocked;
            questText.text = "You defeated the monster! I knew you had it in you the moment I first saw you! \n\n You saved us all, from the bottom of my heart, thank you!";
            if(Input.GetKeyDown("return")){
                SceneManager.LoadScene("MainMenu");                
            }
        }
        else{
            mentorCanvas.SetActive(false);
            enterPrompt.SetActive(false);
            mentorIcon.sprite = calm;
        }
    }
}

