using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] int towerLimit = 0;

    [SerializeField] GameObject towerPrefab;
    [SerializeField] Vector3 placingOffset = new Vector3(0f, 10f, 0f);

    [Header("Tower list")]
    [SerializeField] int towerAmountLimit = 5;
    [SerializeField] int towerCurrentAmount = 0;

    [SerializeField] Queue<GameObject> towerQueue = new Queue<GameObject>();

    public void PlacingTower(Waypoint baseWaypoint)
    {
        if (!isCurrentTowerActive(baseWaypoint) && !isAtTowerLimit())
        {
            DroppingTower(baseWaypoint);
        }

        else if (isAtTowerLimit())
        {
            MoveExistingTower(baseWaypoint);
        }

        else
        {
            Debug.LogWarning("There is already a tower at " + baseWaypoint.name);
        }
    }

    private void DroppingTower(Waypoint baseWaypoint)
    {
        towerCurrentAmount = towerQueue.Count;
        
        Debug.Log("Placing tower at " + baseWaypoint.name);

        Vector3 placingPos = new Vector3(baseWaypoint.transform.position.x + placingOffset.x,
                                         baseWaypoint.transform.position.y + placingOffset.y,
                                         baseWaypoint.transform.position.z + placingOffset.z);

        GameObject newTower = Instantiate(towerPrefab, placingPos, Quaternion.identity);
        Transform towersParent = GameObject.Find("Towers").transform;
        newTower.transform.parent = towersParent.transform;

        Tower_Shooting newTower_Properties = newTower.GetComponent<Tower_Shooting>();
        newTower_Properties.baseWaypoint = baseWaypoint;


        // Adjust tower amount limit
        baseWaypoint.isTowerActive = true;
        baseWaypoint.placedTower = newTower;

        towerCurrentAmount++;
        towerQueue.Enqueue(newTower);
    }

    bool isAtTowerLimit()
    {
        bool isAtLimit;

        if(towerAmountLimit > towerCurrentAmount)
        {
            isAtLimit = false;
        }
        else
        {
            isAtLimit = true;
        }

        return isAtLimit;
    }

    bool isCurrentTowerActive(Waypoint baseWaypoint)
    {
        bool isCurrentTowerActive;

        if(baseWaypoint.placedTower != null)
        {
            isCurrentTowerActive = true;
        }
        else
        {
            isCurrentTowerActive = false;
        }

        return isCurrentTowerActive;
    }

    void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        // Take bottom tower off queue
        var oldTower = towerQueue.Dequeue();
        Tower_Shooting oldTower_Properties = oldTower.GetComponent<Tower_Shooting>();

        // Set the placeable flags
        oldTower_Properties.baseWaypoint.isPlaceable = true; // free-up the block
        newBaseWaypoint.isPlaceable = false;

        // Set the baseWaypoints
        oldTower_Properties.baseWaypoint = newBaseWaypoint;

        // Put the old tower on top of the queue
        oldTower.transform.position = new Vector3(newBaseWaypoint.transform.position.x + placingOffset.x,
                                                  newBaseWaypoint.transform.position.y + placingOffset.y,
                                                  newBaseWaypoint.transform.position.z + placingOffset.z); 

        towerQueue.Enqueue(oldTower);
    }
}
