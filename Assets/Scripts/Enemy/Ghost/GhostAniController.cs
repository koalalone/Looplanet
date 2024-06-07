using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAniController : EnemyAniAbst
{
    public override void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
        base.FixedUpdate();
    }
    public override void Attack()
    {

        if (distance < attackDistance)
        {

            animator.SetBool(chasingHash, false);
            animator.SetBool(attackingHash, true);
            agent.destination = player.transform.position + new Vector3(2, 0, 2);
        }
    }
}
