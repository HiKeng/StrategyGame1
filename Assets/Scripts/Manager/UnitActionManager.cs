using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitActionManager : MonoBehaviour
{
    [SerializeField] GameObject _actionMenu;


    [Header("Events")]
    [SerializeField] UnityEvent _onShowActionMenu;

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

        _onShowActionMenu.Invoke();
    }
}
