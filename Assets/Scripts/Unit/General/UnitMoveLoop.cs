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

    [SerializeField] float _waitBeforeStartMove = 0f;

    [SerializeField] List<PositionToMove> _positionToMove;

    bool _isStartMove = true;

    float _waitTimeCount;
    int _moveIndex;

    private void Start()
    {
        if(_waitBeforeStartMove > 0)
        {
            _isStartMove = false;
            StartCoroutine(_StartWaitTimeCount(_waitBeforeStartMove));
        }
    }

    void Update()
    {
        if(!_isStartMove) { return; }

        _proceedLoopMove();
    }

    void _proceedLoopMove()
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

    void _modifyMoveIndex()
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

    IEnumerator _StartWaitTimeCount (float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);

        _isStartMove = true;
    }


}
