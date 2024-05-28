using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BossAnimationController : MonoBehaviour
{


    public GameObject player;
    float alertDistance = 20f;
    float attackDistance = 5f;
    private float distance;

    Animator animator;
    int attackingHash;
    int chasingHash;
    bool isAttacking;
    bool isChasing;

    NavMeshAgent agent;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();
        attackingHash = Animator.StringToHash("attack");
        chasingHash = Animator.StringToHash("chase");

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        isAttacking = animator.GetBool(attackingHash);
        isChasing = animator.GetBool(chasingHash);
        distance = Vector2.Distance(player.transform.position, this.transform.position);
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


    void Attack()
    {
        if (distance < attackDistance)
        {
            animator.SetBool(chasingHash, false);
            animator.SetBool(attackingHash, true);
            agent.destination = player.transform.position;
        }
    }



}
