using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float distanceThreshold = 20f;

    private void Update()
    {

        if (Vector3.Distance(transform.position, Camera.main.transform.position) > distanceThreshold)
        {
            Destroy(gameObject);
        }
    }
}
