using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Fireball : MonoBehaviour
{
    public float dieTime;
    PlayerState Player;
    
    private int damage = 1;
    void Start()
    {
        StartCoroutine (CountDownTimer ());
        Player = GameObject.Find("Player").GetComponent<PlayerState>();
        
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            Player.DoHarm(damage);
        }

        Die();
    }



    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
