using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDeployManager : MonoBehaviour
{
    public GameObject _playerUnitPrefab;

    #region Singleton

    public static UnitDeployManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
}
