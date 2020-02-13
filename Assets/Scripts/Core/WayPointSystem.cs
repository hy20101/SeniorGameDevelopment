using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointSystem : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float distance = 0f;

    public Transform wayPointParent;
    public Transform[] wayPoints;
    public Transform targetWP;

    public int targetWPCount = 0;

    void Start()
    {
        GetWayPoints();
        targetWP = wayPoints[targetWPCount];
    }

    void Update()
    {
        FollowWayPoint();
    }

    void GetWayPoints()
    {
        int numOfWPs = wayPointParent.childCount;

        wayPoints = new Transform[numOfWPs];

        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = wayPointParent.GetChild(i);
        }
    }

    void FollowWayPoint()
    {
        distance = Vector3.Distance(transform.position, wayPoints[targetWPCount].position);
        if (distance > 1f)
        {
            Vector3 direction = (targetWP.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
        else
        {
            targetWPCount++;
            if (targetWPCount == wayPoints.Length)
            {
                targetWPCount = 0;
            }
        }
        targetWP = wayPoints[targetWPCount];
    }
}
