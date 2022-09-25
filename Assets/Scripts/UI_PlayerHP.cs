using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerHP : MonoBehaviour
{
    public PlayerState playerState;

    public Image hp;
     
    public Sprite hpHigh, hpMid, hpLow;
    void Start()
    {
        
    }

    
    void Update()
    {
        ChangeHP();
    }

    private void ChangeHP(){
        if(playerState.healthpoints == 3){
            hp.sprite = hpHigh;
        }
        if(playerState.healthpoints == 2){
            hp.sprite = hpMid;
        }
        if(playerState.healthpoints == 1){
            hp.sprite = hpLow;
        }
    }
}
