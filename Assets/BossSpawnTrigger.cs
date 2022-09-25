using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnTrigger : MonoBehaviour
{
    Boss_State boss;
    public bool BossIsDead = true;
 

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") == true)
        {
            print("nu triggas partiklarna");
            BossIsDead = false;
        }
    }
}
