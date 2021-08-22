using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAreaToAttack : MonoBehaviour
{
    [SerializeField] List<ActionArea> _actionAreaList;


    void Start()
    {
        
    }

    void Update()
    {
        _getAllActionAreaInChild();
    }

    void _getAllActionAreaInChild()
    {
        foreach(ActionArea actionArea in transform)
        {
            _actionAreaList.Add(actionArea.GetComponent<ActionArea>());
        }
    }
}
