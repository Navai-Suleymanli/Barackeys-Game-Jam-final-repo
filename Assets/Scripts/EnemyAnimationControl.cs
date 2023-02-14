using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationControl : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private EnemyController _enemyController;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
    }
    private void Update()
    {
        _animator.SetBool("IsAttacking", _enemyController.IsPlayer());
    }
}
