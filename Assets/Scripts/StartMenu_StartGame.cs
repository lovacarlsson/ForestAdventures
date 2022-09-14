using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu_StartGame : MonoBehaviour
{
    [SerializeField] private float waitTime;


    public void StartGame()
    {
        Invoke("StartGameDelay", waitTime);
            

        
        

    }

    public void StartGameDelay ()
    {
        SceneManager.LoadScene(1);

    }

}
