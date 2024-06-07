using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyAniAbst : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    protected float alertDistance;

    [SerializeField]
    protected float attackDistance;
    protected float distance;

    protected Animator animator;
    protected int attackingHash;
    protected int chasingHash;
    protected bool isAttacking;
    protected bool isChasing;

    protected NavMeshAgent agent;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();
        attackingHash = Animator.StringToHash("attack");
        chasingHash = Animator.StringToHash("chase");

    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        isAttacking = animator.GetBool(attackingHash);
        isChasing = animator.GetBool(chasingHash);
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        Idle();
        Chase();
        Attack();
        
    }

    void Idle()
    {
        if (distance > attackDistance)
        {
            animator.SetBool(attackingHash, false);
        }
        if (distance > alertDistance)
        {
            animator.SetBool(chasingHash, false);
        }

    }

    void Chase()
    {
        if (distance < alertDistance && !isAttacking)
        {
            animator.SetBool(chasingHash, true);
            agent.destination = player.transform.position;
        }

    }


    public virtual void Attack()
    {
        
        if (distance < attackDistance)
        {
            
            animator.SetBool(chasingHash, false);
            animator.SetBool(attackingHash, true);
            
        }
    }


}