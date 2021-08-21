using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionManager : MonoBehaviour
{
    [SerializeField] GameObject _actionMenu;

    #region Singleton

    public static UnitActionManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion


    public void _ShowActionMenu()
    {
        _actionMenu.SetActive(true);
        _actionMenu.transform.position = ClickStateManager.Instance._unitToFocus.transform.position;
    }
}
