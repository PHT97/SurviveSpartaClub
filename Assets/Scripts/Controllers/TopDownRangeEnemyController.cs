using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownRangeEnemyController : TopDownEnemyController
{
    [SerializeField] private float shootRange = 100f;

    //public GameObject Aim;

    protected override void FixedUpdate()
    {
        if(GameManager.instance.IsPlaying == false)
        {
            return;
        }
        base.FixedUpdate();

        float distance = DistanceToTarget();
        Vector2 direction = DirectionToTarget();

        IsAttacking = false;
        if (distance <= shootRange)
        {
            int layerMaskTarget = Stats.CurrentStats.attackSO.target;
            //int layerMaskTarget = 1 << LayerMask.NameToLayer("Player");
            //���� �÷��̾� ���̿� �����ִ� ������ �ִ��� �˻��ϴ� �ڵ�

            //RaycastHit2D = ������Ʈ�� �ְ� Physics2D.Raycast �� ù��°���� = ������ġ(������ �������� �� ��ġ) / �ι�°���� = ����������� ������������(����ã��)
            // ����°���� = �Ÿ� / �׹�°(�ּ�ó���κ�) = ��Ʈ����(Rayermask)

            //RaycastAll = Raycast�� ���� ������ ���������� �ϰڴ�

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, shootRange, layerMaskTarget); //(1 << LayerMask.NameToLayer("Level")) | layerMaskTarget);
            

            //.GetMask("Player")                                                                             //��������
            if (hit.collider != null && hit.collider.gameObject.name.Equals("Player")) //layerMaskTarget == (layerMaskTarget | (1 << hit.collider.gameObject.layer)))
            {
                CallLookEvent(direction);
                CallMoveEvent(Vector2.zero);
                IsAttacking = true;
            }
            else
            {
                CallMoveEvent(Vector2.zero);
            }
        }
        else
        {
            CallMoveEvent(Vector2.zero);
        }
    }
}
