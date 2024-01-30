using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownBossContreoller : TopDownEnemyController
{
    [SerializeField] private float followRange = 15f;
    [SerializeField] private float shootRange = 10f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        float distance = DistanceToTarget();
        Vector2 direction = DirectionToTarget();

        IsAttacking = false;
        if (distance <= followRange)
        {
            int layerMaskTarget = Stats.CurrentStats.attackSO.target;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, shootRange, layerMaskTarget); //(1 << LayerMask.NameToLayer("Level")) | layerMaskTarget);

            //문제구역
            if (hit.collider != null && hit.collider.gameObject.name.Equals("Player")) //layerMaskTarget == (layerMaskTarget | (1 << hit.collider.gameObject.layer)))
            {
                CallLookEvent(direction);
                CallMoveEvent(Vector2.zero);
                IsAttacking = true;
            }
        }
        CallMoveEvent(direction);
    }
}