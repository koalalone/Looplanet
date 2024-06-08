using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject portal;

    int hp = 200;
    HealthSystem healthSystem;
    [SerializeField] HealthBar healthBar;
    GameObject player;
    public PlayerController playerController;
    Portal portalScript;

    private void Start()
    {
        
        portal = GameObject.Find("Portal");
        player = GameObject.Find("player");
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
        healthSystem = new HealthSystem(hp);
        healthBar.SetUp(healthSystem);

        if (portal != null)
        {
            portalScript = portal.GetComponent<Portal>();
            portalScript.DeactivatePortal();
            //portal.SetActive(false);
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
        portalScript.ActivatePortal();
        //portal.SetActive(true);
        gameObject.SetActive(false);
        //Destroy(this.gameObject);

    }

    

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player" && playerController != null)
        {
            playerController.TakeDamage(10);
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            healthSystem.Damage(5);
            if (healthSystem.GetHealth() <= 0)
            {
                Death();
                ScoreController.score += 200;
            }
        }
    }



}