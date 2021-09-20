using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitMovement))]
public class UnitMoveLoop : MonoBehaviour
{
    [System.Serializable]
    public class PositionToMove
    {
        public Tile _tilePostion;
        public float _waitTimeBeforeMove;
    }

    [SerializeField] public float _waitBeforeStartMove = 0f;

    [SerializeField] public List<PositionToMove> _positionToMove;

    [HideInInspector] public bool _isStartMove = true;

    [HideInInspector] public float _waitTimeCount;
    [HideInInspector] public int _moveIndex;

    public virtual void Start()
    {
        if(_waitBeforeStartMove > 0)
        {
            _isStartMove = false;
            StartCoroutine(_StartWaitTimeCount(_waitBeforeStartMove));
        }
    }

    public virtual void Update()
    {
        if(!_isStartMove) { return; }

        _proceedLoopMove();
    }

    public virtual void _proceedLoopMove()
    {
        if(!GetComponent<UnitHealth>()._isAlive) { return; }
        if(GetComponent<UnitMovement>()._isMoving) { return; }


        if(_waitTimeCount < _positionToMove[_moveIndex]._waitTimeBeforeMove)
        {
            _waitTimeCount += Time.deltaTime;
        }
        else
        {
            GetComponent<UnitMovement>()._MoveToPosition(_positionToMove[_moveIndex]._tilePostion);

            _waitTimeCount = 0f;
            _modifyMoveIndex();
        }
    }

    public virtual void _modifyMoveIndex()
    {
        if (_moveIndex == _positionToMove.Count - 1)
        {
            _moveIndex = 0;
        }
        else
        {
            _moveIndex++;
        }
    }

    public virtual IEnumerator _StartWaitTimeCount (float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);

        _isStartMove = true;
    }


}
