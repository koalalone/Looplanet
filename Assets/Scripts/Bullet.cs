using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float distanceThreshold = 20f;
    public GameObject explosionPrefab;

    private void Update()
    {

        if (Vector3.Distance(transform.position, Camera.main.transform.position) > distanceThreshold)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.transform.tag)
        {
            default:
                GameObject effect = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(effect, 0.5f);
                
                break;
        }
    }
}
