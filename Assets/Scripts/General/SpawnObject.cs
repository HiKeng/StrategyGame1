using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public void _SpawnVFX(GameObject _vfxPrefab)
    {
        GameObject _newVFX = Instantiate(_vfxPrefab, transform.position, Quaternion.identity);
        Destroy(_newVFX, 3f);
    }
}
