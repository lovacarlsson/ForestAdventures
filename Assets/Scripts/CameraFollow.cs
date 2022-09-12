using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject followTarget;

    public Vector3 offset = new Vector3(0f, 0f, -10f);

    public float smoothSpeed = 0.1f;
    
    
    void Start()
    {
        followTarget = GameObject.Find("Player");

    }

    
    void LateUpdate()
    {
        Vector3 desiredPosition = followTarget.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(gameObject.transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        gameObject.transform.position = smoothPosition;






    }
}
