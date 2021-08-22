using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareMoveText : MonoBehaviour
{
    [SerializeField] GameObject _text;
    
    void Update()
    {
        if(ClickStateManager.Instance._CurrentState == ClickStateManager.ClickState.UnitPrepareToMove)
        {
            gameObject.SetActive(true);
        }
        else
        {
            _text.SetActive(false);
        }
    }
}
