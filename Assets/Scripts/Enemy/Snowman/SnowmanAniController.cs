using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SnowmanAniController : MonoBehaviour
{ 
    [SerializeField]
    public GameObject projectile;
    [SerializeField]
    public Transform attackPoint;
     

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
    float shootingInterval = 0;



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


    void Attack()
    {
        if (distance < attackDistance)
        {
            animator.SetBool(chasingHash, false);
            animator.SetBool(attackingHash, true);
            agent.destination = player.transform.position;
            
            if (shootingInterval>0)
            {
                shootingInterval -= Time.deltaTime;
            }
            else
            {
                shootingInterval = 0.3f;
                Shoot();
            }
            

        }
    }
    void Shoot()
    {
        transform.LookAt(player.transform.position);
        GameObject currentProjectile = Instantiate(projectile, attackPoint.position, Quaternion.identity);
        Vector3 projectileVector = player.transform.position - attackPoint.position;
        projectileVector.y = 0.2f;
        currentProjectile.transform.forward = projectileVector;
        currentProjectile.GetComponent<Rigidbody>().AddForce(projectileVector.normalized*15,ForceMode.Impulse);
    }


}