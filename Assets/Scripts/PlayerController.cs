using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //MOVING
    public float movementSpeed;
    public Rigidbody rb;
    float horizontalInput;
    float verticalInput;

    //LOOKING MOUSE
    Ray ray;
    Plane groundPlane;
    float distanceToGround;
    Vector3 targetPosition;

    //SHOOTING
    public float fireRate = 0.5f;
    public float bulletSpeed = 10f;
    public GameObject bulletPrefab;
    private float timer;

    private void Update()
    {
        //LOOKING MOUSE
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        groundPlane = new Plane(Vector3.up, new Vector3(0,1,0));

        if (groundPlane.Raycast(ray, out distanceToGround))
        {
            targetPosition = ray.GetPoint(distanceToGround);
            targetPosition.y = transform.position.y;
            transform.rotation = Quaternion.LookRotation(targetPosition - transform.position, Vector3.up);
        }

        //SHOOTING
        if (Input.GetButtonDown("Fire1"))
        {
            if (timer <= 0)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward, Quaternion.FromToRotation(transform.forward, Vector3.up));

                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);

                timer = fireRate;
            }
        }
        timer -= Time.deltaTime;

    }

    private void FixedUpdate()
    {        
        //WALKING
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput, 0, verticalInput) * movementSpeed * Time.deltaTime;

    }
}
