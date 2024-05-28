using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject portal;

    int hp = 200;
    HealthSystem healthSystem;
    [SerializeField] HealthBar healthBar;
    GameObject player;
    public PlayerController playerController;

    private void Start()
    {
        
        portal = GameObject.Find("Portal");
        player = GameObject.Find("player");
        if (player != null)
        {
            Debug.Log("burdayým");
            playerController = player.GetComponent<PlayerController>();
        }
        healthSystem = new HealthSystem(hp);
        healthBar.SetUp(healthSystem);

        if (portal != null)
        {
            portal.SetActive(false);
        }
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
        portal.SetActive(true);
        gameObject.SetActive(false);
        //Destroy(this.gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
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
            playerController.TakeDamage(10);
        }
    }



}