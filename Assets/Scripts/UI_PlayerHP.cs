using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerHP : MonoBehaviour
{
    public PlayerState playerState;
    private Slider slider;

    int maxplayerHealthPoints;

   
    
    void Start()
    {
        maxplayerHealthPoints = playerState.initalHealthPoints;
        slider = GetComponent<Slider>();
        slider.wholeNumbers = true;
        slider.maxValue = maxplayerHealthPoints;

    }

    
    void Update()
    {
        slider.value = playerState.healthpoints;



    }
}
