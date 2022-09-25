using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnTrigger : MonoBehaviour
{
    Boss_State boss;
    public bool BossIsDead = true;
    public GameObject door, camera;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") == true)
        {
            print("nu triggas partiklarna");
            BossIsDead = false;
            GameObject.Find("Main Camera").GetComponent<CameraFollow>().enabled = false;
            camera.transform.position = new Vector3(117.889999f,47.6300011f,-10.4499998f);
            door.SetActive(true);
        }
    }
}
