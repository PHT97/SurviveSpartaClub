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
            //나와 플레이어 사이에 막혀있는 지형이 있는지 검사하는 코드

            //RaycastHit2D = 오브젝트가 있고 Physics2D.Raycast 의 첫번째인자 = 나의위치(가상의 레이저를 쏠 위치) / 두번째인자 = 어느방향으로 레이저를쏠지(방향찾기)
            // 세번째인자 = 거리 / 네번째(주석처리부분) = 비트연산(Rayermask)

            //RaycastAll = Raycast에 맞은 모든것을 가져오도록 하겠다

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, shootRange, layerMaskTarget); //(1 << LayerMask.NameToLayer("Level")) | layerMaskTarget);
            

            //.GetMask("Player")                                                                             //문제구역
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
