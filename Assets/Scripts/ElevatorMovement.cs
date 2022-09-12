using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    //Serialized s� vi ser att den funkar
    [SerializeField] private GameObject nextTarget;

    [SerializeField] private float speed = 2f;

    [SerializeField] private List<GameObject> targetPoints; //Gl�m inte att fylla p� listan om du g�r ny hiss!
    private int currentTargetPointIndex;

    
    void Start()
    {
        if (targetPoints.Count > 0)
        {
            nextTarget = targetPoints[0];
        }
    }

    void FixedUpdate()
    {
        if (nextTarget != null)
        {
            MoveToPosition(nextTarget);
        }
    }

    private void MoveToPosition(GameObject moveToTarget) 
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, moveToTarget.transform.position, speed * Time.fixedDeltaTime);
        if (gameObject.transform.position == moveToTarget.transform.position)
        {
            ChangeTarget();
        }
    }

    private void ChangeTarget()
    {

        currentTargetPointIndex++;
        
            if (currentTargetPointIndex >= targetPoints.Count)
            {
                currentTargetPointIndex = 0;
            }
        nextTarget = targetPoints[currentTargetPointIndex];
    }

        


    }





