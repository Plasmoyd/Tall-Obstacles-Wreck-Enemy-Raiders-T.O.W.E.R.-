using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float delayTime = 1f;

    void Start()
    {
        StartCoroutine(DisplayWaypointNames());
        StartCoroutine(FollowPath());
    }

    private IEnumerator DisplayWaypointNames()
    {
        foreach(Waypoint waypoint in path)
        {
            Debug.Log(waypoint.name);
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds (delayTime);
        }
    }
}
