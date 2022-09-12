using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Player : MonoBehaviour
{

    //När mnan ska läsa eller modidfiera en klass från flera andra klasser kan man göra den static då den inte behöver vara ett objekt. Hjälpte mot felet null reference exception. 
    static public bool isQuestComplete = false;
}
