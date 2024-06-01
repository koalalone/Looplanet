using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class EnemyCont : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] int damage;
    HealthSystem healthSystem;
    [SerializeField] HealthBar healthBar;
    GameObject player;
    public PlayerController playerController;
    private void Start()
    {

        player = GameObject.Find("player");
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
        healthSystem = new HealthSystem(hp);
        healthBar.SetUp(healthSystem);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Death();
        }
    }

    public void Death()
    {
        gameObject.SetActive(false);
        //Destroy(this.gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("vursana");
            healthSystem.Damage(5);
            if (healthSystem.GetHealth() <= 0)
            {
                Death();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" && playerController != null)
        {
            playerController.TakeDamage(damage);
        }
    }
}
