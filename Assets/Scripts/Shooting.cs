using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float fireRate = 0.5f;
    public float bulletSpeed = 10f;
    public GameObject bulletPrefab;

    private float timer;

    private void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            if (timer <= 0) { 
                GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward, Quaternion.Euler(new Vector3(90,0,0)));

                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);

                timer = fireRate;
            }
        }

        timer -= Time.deltaTime;
    }
}
