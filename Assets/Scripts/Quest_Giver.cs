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
    public Image mentorIcon;
    public Sprite shocked, calm;
    public TextMeshProUGUI questText, nameText;
    public Transform checkpoint, player, mentor, powerUp, secondCheckpoint, mentorCanvasTransform;
    private bool promptBool = false;
    private bool checkpointBool = false;
    private bool powerUpBool = false;
    private bool beeBool = false;
    Vector3 originalPos;
    void Start()
    {
        questText.GetComponent<TextMeshProUGUI>().enabled = true;
        playerState = GameObject.Find("Player").GetComponent<PlayerState>();
        originalPos = mentorCanvasTransform.transform.position;
    }

    void Update(){
        MentorCheck();
    }

    void MentorCheck(){
        if(Vector2.Distance(player.position, checkpoint.position)<5f){
            
            
            if(checkpointBool == false){
                mentorCanvas.SetActive(true);
                questText.text = "You've reached a checkpoint! This means that if you die you will respawn here. \n\nThere's an enemy ahead, you can kill it by jumping on it.";
                checkpointBool = true;
            }

        }
        else if(Vector2.Distance(player.position, mentor.position)<2.5f){
            mentorCanvas.SetActive(true);

            if (playerState.starAmount >= amountToCollect)
            {
                Quest_Player.isQuestComplete = true;
                houseToAppearWhenQuestIsComplete.SetActive(true);
                mentorIcon.sprite = shocked;
                questText.text = "You've already collected " + amountToCollect + " stars!? That was quick! \n\nSorry but I may ask another favour of you later, you can go rest in the house for now.";
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
                }
                else if(enterPrompt.activeSelf == true){
                    questText.text = "Hello there! I'm Fox and I'm going to be your mentor. \n\nIn order to move around and climb ladders use WASD or the Arrow Keys. \n\nUse SPACE to jump.";
                    promptBool = false;
                }
            }
        }
        else if(Vector2.Distance(player.position, powerUp.position)<7.5f){
            if(powerUpBool == false){
                mentorCanvas.SetActive(true);
                mentorCanvasTransform.transform.position = new Vector3(525f, 300f);
                questText.text = "See that thing? That's a power up. \n\nPower ups are temporary buffs that can help you, for example, traverse otherwise untraversable terrain";

                powerUpBool = true;
            }
        }
        else if(Vector2.Distance(player.position, secondCheckpoint.position)<5f){
            if(beeBool == false){
                mentorCanvas.SetActive(true);
                questText.text = "You may have noticed that upon killing an enemy you get a little boost. \n\nTry using that boost to your advantage to traverse this chasm.s";
                beeBool = true;
            }
        }
        else{
            mentorCanvas.SetActive(false);
            enterPrompt.SetActive(false);
            mentorCanvasTransform.transform.position = originalPos;
            mentorIcon.sprite = calm;
        }
    }
}

