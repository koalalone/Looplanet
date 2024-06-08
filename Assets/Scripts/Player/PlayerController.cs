using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //PLAYER STATS
    public int maxHealth = 100;
    public int currentHealth = 100;

    public PlayerHealthBar healthBar;

    //MOVING
    public float movementSpeed;
    public Rigidbody rb;
    float horizontalInput;
    float verticalInput;
    float spaceInput;
    float dashTime = 0f;
    float dashCooldown = 2f;
    float movespeedBoost = 50f;
    float currentspeed;

    //LOOKING MOUSE
    Ray ray;
    Plane groundPlane;
    float distanceToGround;
    Vector3 targetPosition;

    //SHOOTING
    public float fireRate = 0.5f;
    public float bulletSpeed = 10f;
    public GameObject bulletPrefab;
    public GameObject bulletFrom;
    private float timer;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentspeed = movementSpeed;
    }

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

        if (Input.GetKeyDown(KeyCode.R)) { TakeDamage(5); }

        //SHOOTING
        if (Input.GetButton("Fire1"))
        {
            if (timer <= 0)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletFrom.transform.position + transform.forward, bulletFrom.transform.rotation);

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
        spaceInput = Input.GetAxis("Jump");
        
        rb.velocity = new Vector3(horizontalInput, 0, verticalInput) * currentspeed;

        //rb.velocity = (transform.forward * verticalInput + transform.right * horizontalInput) * movementSpeed;

        Vector3 dir = rb.velocity.normalized;

        if (Input.GetButton("Fire2"))
        {
            
            if (Time.time >= dashTime)
            {
                StartCoroutine(Dashing());
                dashTime = Time.time+dashCooldown;
                /*
                Vector3 targetPos = transform.position + dir * 100f;
                transform.position = Vector3.Lerp(transform.position, targetPos, 3f * Time.deltaTime);
                //rb.AddForce(rb.velocity * 5000f, ForceMode.Impulse);
                
                */
            }
        }
        

        //BOUND
        Vector3 mustPos = transform.position;
        mustPos = new Vector3(Mathf.Clamp(mustPos.x, -149f, 149f), mustPos.y, Mathf.Clamp(mustPos.z, -149f, 149f));
        transform.position = mustPos;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) 
        {
            ActivationCheck.props.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        healthBar.SetHealth(currentHealth);
    }


    private IEnumerator Dashing()
    {

        currentspeed = movespeedBoost;
        yield return new WaitForSeconds(0.1f);
        currentspeed = movementSpeed;
    }
}
