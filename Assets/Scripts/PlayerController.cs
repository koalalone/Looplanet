using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody rb;

    float horizontalInput;
    float verticalInput;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0,1,0));
        float distanceToGround;

        if (groundPlane.Raycast(ray, out distanceToGround))
        {
            Vector3 targetPosition = ray.GetPoint(distanceToGround);

            transform.LookAt(targetPosition);
        }
    }

    private void FixedUpdate()
    {        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        rb.velocity = new Vector3(horizontalInput, 0, verticalInput) * movementSpeed * Time.deltaTime;

    }
}
