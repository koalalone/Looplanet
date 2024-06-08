using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanProjectileController : MonoBehaviour
{
    GameObject player;
    public PlayerController playerController;
    public GameObject explosionPrefab;
    public int damage;
    public float distanceThreshold = 100f;
    void Start()
    {
        player = GameObject.Find("player");
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > distanceThreshold)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" && playerController != null)
        {
            playerController.TakeDamage(damage);
        }
        //GameObject effect = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
