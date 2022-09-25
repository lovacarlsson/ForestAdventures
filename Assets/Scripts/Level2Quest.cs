using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level2Quest : MonoBehaviour
{   
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip questGiverClip;
    public GameObject mentorCanvas;
    public TextMeshProUGUI questText;
    public Transform player, mentor;
    void Start()
    {
        questText.GetComponent<TextMeshProUGUI>().enabled = true;
    }

    void Update(){
        MentorCheck();
    }

    void MentorCheck(){
        if(Vector2.Distance(player.position, mentor.position)<2.5f){
            mentorCanvas.SetActive(true);
            questText.text = "Hello again! There's a cave up ahead infested with aggressive and dangerous bees. \n\nSorry to ask this of you but I want you to get rid of those bees. There's a cabin at the other end of the cave, you can rest there.\n\n Best of luck to you!";
        }
        else{
            mentorCanvas.SetActive(false);
        }
    }
}

