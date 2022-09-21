using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnTrigger : MonoBehaviour
{
    Boss_State boss;
    public bool BossIsDead = true;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            BossIsDead = false;
        }
    }
}
