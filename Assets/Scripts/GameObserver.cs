using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObserver : MonoBehaviour
{
  
    public static void SaveStarsToMemory(int amount)
    {
        PlayerPrefs.SetInt("StarAmount", PlayerPrefs.GetInt("StarAmount") + amount);


    }


}
