using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] GameObject[] wayPoints;
    [SerializeField] float speed = 1f;
    private int currentWayPoint = 0;

    void Update()
    {
        // Find the the wayPoint index
        if (Vector3.Distance(transform.position, wayPoints[currentWayPoint].transform.position) < 0.1f)
        {
            currentWayPoint++;
            if (currentWayPoint >= wayPoints.Length) currentWayPoint = 0; // reset the index if past the last point
        }

        transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentWayPoint].transform.position, speed * Time.deltaTime);
    }
}
