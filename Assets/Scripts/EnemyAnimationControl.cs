using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationControl : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyController _enemyController;

    private void Awake()
    {
       
        
    }
    private void Update()
    {
        _animator.SetBool("isAttacking", _enemyController.IsPlayer());
        _animator.SetBool("isFlying",_enemyController.IsFlying());
    }
}
