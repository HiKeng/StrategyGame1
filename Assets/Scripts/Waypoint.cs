using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;

    // public ok here as is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;

    public bool isPlaceable = true;

    [Header("Current Tower State")]
    public GameObject placedTower;
    public bool isTowerActive = false;

    Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }
    /* public void SetTopColor(Color topColor)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = topColor;
    } */

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            if (isPlaceable)
            {
                FindObjectOfType<TowerPlacement>().PlacingTower(this);
                //gameObject.SendMessage("PlacingTower");
            }
            else
            {
                Debug.Log("Can't place here.");
            }
        }
    }
}
