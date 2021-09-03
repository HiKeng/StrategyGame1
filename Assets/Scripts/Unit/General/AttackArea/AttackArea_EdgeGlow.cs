using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea_EdgeGlow : MonoBehaviour
{
    [SerializeField] SpriteRenderer _frontGlow, _backGlow, _rightGlow, _leftGlow;
    [SerializeField] public bool _hasFront, _hasBack, _hasRight, _hasLeft;

    [SerializeField] UnitAreaToAttack _unitAreaToAttack;
    void Start()
    {
        _unitAreaToAttack = transform.parent.parent.GetComponent<UnitAreaToAttack>();

        _unitAreaToAttack._CheckNearbyTile(GetComponent<AttackArea_EdgeGlow>());
    }
}
