using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea_EdgeGlow : MonoBehaviour
{
    [SerializeField] SpriteRenderer _frontGlow, _backGlow, _rightGlow, _leftGlow;
    [SerializeField] public bool _hasFront, _hasBack, _hasRight, _hasLeft;

    void Start()
    {
        transform.parent.parent.GetComponent<UnitAreaToAttack>()._CheckNearbyTile(GetComponent<AttackArea_EdgeGlow>());
        _setActiveEdgeGlow();
    }

    void _setActiveEdgeGlow()
    {
        _frontGlow.gameObject.SetActive(!_hasFront);
        _backGlow.gameObject.SetActive(!_hasBack);
        _rightGlow.gameObject.SetActive(!_hasRight);
        _leftGlow.gameObject.SetActive(!_hasLeft);
    }
}
