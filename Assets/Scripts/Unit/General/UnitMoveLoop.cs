using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMoveLoop : MonoBehaviour
{
    [System.Serializable]
    public class PositionToMove
    {
        public Tile _tilePostion;
        public float _waitTimeBeforeMove;
    }

    public List<PositionToMove> _positionToMove;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
