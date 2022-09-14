using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_DisplayStarsCollected : MonoBehaviour

{
    
    [SerializeField] private TextMeshProUGUI textComponent;

    void Start()
    {
        textComponent.text = "" + PlayerPrefs.GetInt("StarAmount");
    }


}