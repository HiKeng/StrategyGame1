using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [System.Serializable]
    public class UnitSpawn
    {
        [SerializeField] public GameObject _unitPrefab;
        [SerializeField] public Tile _tileSpawnPoint;
    }

    [SerializeField] List<UnitSpawn> _unitToSpawnList;

    void Start()
    {
        _spawnUnits();   
    }

    void _spawnUnits()
    {
        for (int i = 0; i < _unitToSpawnList.Count; i++)
        {
            if(_unitToSpawnList[i]._unitPrefab != null && _unitToSpawnList[i]._tileSpawnPoint != null)
            {
                Tile_UnitPlacement _tilePlacement = _unitToSpawnList[i]._tileSpawnPoint.GetComponent<Tile_UnitPlacement>();
                _tilePlacement._DroppingUnit(_unitToSpawnList[i]._unitPrefab);
            }
        }
    }
}
