using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject followTarget;

    public Transform player;
    public BoxCollider2D mapBounds;
    private Camera mainCam;

    private float xMin, xMax, yMin, yMax, camY, camX, camOrthsize, cameraRatio;

    public Vector3 offset = new Vector3(0f, 0f, -10f);

    public float smoothSpeed = 0.1f;
    
    
    void Start()
    {
        followTarget = GameObject.Find("Player");

        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;
        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
    }

    
    void LateUpdate()
    {
        camY = Mathf.Clamp(player.position.y, yMin + camOrthsize, yMax - (camOrthsize));
        camX = Mathf.Clamp(player.position.x, xMin + camOrthsize, xMax - (camOrthsize));

        Vector3 desiredPosition = new Vector3(camX, camY, this.transform.position.z);
        Vector3 smoothPosition = Vector3.Lerp(gameObject.transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        gameObject.transform.position = smoothPosition;






    }
}
