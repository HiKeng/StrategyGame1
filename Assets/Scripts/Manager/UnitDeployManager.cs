using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDeployManager : SingletonBase<UnitDeployManager>
{
    public GameObject _playerUnitPrefab;

    public bool _isUnitDeployPhase = true;
}
