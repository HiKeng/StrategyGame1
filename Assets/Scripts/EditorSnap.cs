using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Tile))]
public class EditorSnap : MonoBehaviour
{
    Tile _tile;

    void Awake()
    {
        _tile = GetComponent<Tile>();
    }
    
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int _gridSize = _tile.GetGridSize();

        transform.position = new Vector3(_tile.GetGridPos().x * _gridSize,
                                         0f,
                                         _tile.GetGridPos().y * _gridSize);
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();

        string labelText = _tile.GetGridPos().x + "," + _tile.GetGridPos().y;

        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
