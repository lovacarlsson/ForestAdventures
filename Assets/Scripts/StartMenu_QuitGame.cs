using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu_QuitGame : MonoBehaviour
{

    [SerializeField] private float waitTime;
    public void QuitGame()
    {
        Invoke("QuitGameDelay", waitTime);
    }

    public void QuitGameDelay()
    {
        Application.Quit(); 
    }









    
}
