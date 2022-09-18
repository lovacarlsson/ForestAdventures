using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float timeOffset, leftLimit, rightLimit, bottomLimit, topLimit;
    [SerializeField] Vector2 posOffset;
    private Vector3 velocity;
    private float verticalSize, horizontalSize;

    void Start(){

        verticalSize = Convert.ToSingle(Camera.main.orthographicSize * 2.0); //total height
        horizontalSize = verticalSize * Screen.width / Screen.height; //total width

        if(bottomLimit >= 0){
            bottomLimit -= Camera.main.orthographicSize;
        }
        else if(bottomLimit < 0){
            bottomLimit += Camera.main.orthographicSize;
        }

        if(topLimit >= 0){
            topLimit -= Camera.main.orthographicSize;
        }
        else if(topLimit < 0){
            topLimit += Camera.main.orthographicSize;
        }

        if(rightLimit >= 0){
            rightLimit -= horizontalSize/2;
        }
        else if(rightLimit < 0){
            rightLimit += horizontalSize/2;
        }

        if(leftLimit >= 0){
            leftLimit -= horizontalSize/2;
        }
        else if(leftLimit < 0){
            leftLimit += horizontalSize/2;
        }
    }

    void Update(){

        Vector3 startPos = transform.position;

        Vector3 endPos = player.transform.position;

        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
        );
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;

        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));

    }
}
