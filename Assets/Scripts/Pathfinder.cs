using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] public Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] bool isRunning = true;

    Waypoint searchCenter; // the current searchCenter

    List<Waypoint> path = new List<Waypoint>();
    bool isPathLoaded = false;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    public List<Waypoint> GetPath()
    {
        if(!isPathLoaded)
        {
            CalculatePath();
        }

        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        SetAsPath(endWaypoint);

        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            SetAsPath(previous);
            previous = previous.exploredFrom; 
        }

        SetAsPath(startWaypoint);
        path.Reverse();

        isPathLoaded = true;
    }

    void SetAsPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;

            HaltIfEndFound();
            ExploreNeighbors();
            // explore neighnours
        }

        // todo work-out path!
        //Debug.Log("Finished pathfinding?");
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            //Debug.Log("Searching from end node, therefore stopping");
            isRunning = false;
        }
    }

    private void ExploreNeighbors()
    {
        if(!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = searchCenter.GetGridPos() + direction;

            if(grid.ContainsKey(explorationCoordinates))
            {
                QueueNewNeighbours(explorationCoordinates);
            }
            //Debug.Log("Exploring " + explorationCoordinates);
        }
    }

    private void QueueNewNeighbours(Vector2Int explorationCoordinates)
    {
        Waypoint neighbour = grid[explorationCoordinates];

        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            // do noting
        }
        else {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }

    private void ColorStartAndEnd()
    {
        // todo consider moving out
        //startWaypoint.SetTopColor(Color.green);
        //endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();

        foreach(Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();

            if(grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
                //waypoint.SetTopColor(Color.grey);
            }
        }

        //Debug.Log("Loaded " + grid.Count + " blocks");
    }
}
