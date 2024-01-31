using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownEnemyAnimationController : TopDownAnimations
{
    private static readonly int IsHit = Animator.StringToHash("IsHit");

    private HealthSystem _healthSystem;

    protected override void Awake()
    {
        base.Awake();
        _healthSystem = GetComponent<HealthSystem>();
    }

    void Start()
    {

        if (_healthSystem != null)
        {
            _healthSystem.OnDamage += Hit;
        }
    }

    private void Hit()
    {
        animator.SetBool(IsHit, true);
    }
    public void HitEnd()
    {
        animator.SetBool(IsHit, false);
    }
}