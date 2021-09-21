using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_UnitDeploySelect : MonoBehaviour
{
    [SerializeField] GameObject _playerUnit;
    
    public void _PrepareToPlaceUnit()
    {
        ClickStateManager.Instance._ChangeClickState(ClickStateManager.ClickState.PrepareToDeploy);
        UnitDeployManager.Instance._UnitPrefab = _playerUnit;
        UnitDeployManager.Instance._onPrepareDeployUnit.Invoke();
    }    
}
