using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{

    [SerializeField] GameObject[] WayPoints;
    int CurrentWayPointIndex = 0;

    [SerializeField] float speed = 1f;

    void Update()
    {
        if (Vector3.Distance(transform.position, WayPoints[CurrentWayPointIndex].transform.position) < .1f)
        {
            CurrentWayPointIndex++;
            if (CurrentWayPointIndex >= WayPoints.Length)
            {
                CurrentWayPointIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, WayPoints[CurrentWayPointIndex].transform.position, speed * Time.deltaTime);
    }
}
