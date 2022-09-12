using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathCollider : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("SOMETHING"); 

       if (collision.CompareTag("Enemy") == true) {
        Destroy(collision.gameObject.transform.parent.gameObject);



       }

    }
  




}
