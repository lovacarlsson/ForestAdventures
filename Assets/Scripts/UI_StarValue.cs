using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class UI_StarValue : MonoBehaviour

{
    public Text textComponent;
    private PlayerState playerState;

  


    // Start is called before the first frame update
    void Start()
    {
        playerState = GameObject.Find("Player").GetComponent<PlayerState>();
        textComponent = gameObject.GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = playerState.starAmount + "";


    }
}
