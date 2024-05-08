using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    Rigidbody rb;
    float alertDistance = 20f;
    float attackDistance = 2f;

    NavMeshAgent agent;

    float hp = 10f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, this.transform.position);
        

        if (distance < alertDistance)
        {
            agent.destination = player.transform.position;
            if (distance < attackDistance)
            {
                Debug.Log("hasar yedin");
            }
        }
    }

    //DENEME
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp -= 5f;
            if (hp <= 0)
            {
                ActivationCheck.props.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
