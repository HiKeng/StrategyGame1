using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDeployManager : MonoBehaviour
{
    public static UnitDeployManager Instance;

    public GameObject _playerUnitPrefab;

    private void Awake()
    {
        Instance = this;
    }
}
