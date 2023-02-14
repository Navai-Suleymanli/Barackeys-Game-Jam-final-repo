using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    [SerializeField] Movement _playerRef;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
    }
    private void Update()
    {
        _animator.SetBool("isWalking", _playerRef.Iswalking());
    }

}
