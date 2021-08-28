using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_To_Position : StateMachineBehaviour
{
    public Tile _position;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<UnitMovement>()._MoveToPosition(_position);

    }

    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
