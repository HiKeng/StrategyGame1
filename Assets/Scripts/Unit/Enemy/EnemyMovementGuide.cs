using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementGuide : UnitMoveLoop
{
    public override void _proceedLoopMove()
    {
        if (_waitTimeCount < _positionToMove[_moveIndex]._waitTimeBeforeMove)
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
}
