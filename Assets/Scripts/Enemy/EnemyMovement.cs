using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float delayBetweenMove = 0.5f;
    [SerializeField] Vector3 offsetPos;

    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        //Debug.Log("Start patrol...");

        foreach (Waypoint waypoint in path)
        {
            Vector3 nextWayPointPos = waypoint.transform.position;
            Vector3 finalNewPos = new Vector3(nextWayPointPos.x + offsetPos.x,
                                              nextWayPointPos.y + offsetPos.y,
                                              nextWayPointPos.z + offsetPos.z);

            transform.position = finalNewPos;
            yield return new WaitForSeconds(delayBetweenMove);
        }

        SendMessage("enemyDestoryed");
        //Debug.Log("Ending Patrol");
    }
}
