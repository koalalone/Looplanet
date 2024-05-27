using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    HealthSystem healthSystem;
    public Camera mainCamera;


    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();


        
    }
    public void SetUp(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
    }

    void Update()
    {
        transform.Find("Bar").localScale = new Vector3(healthSystem.GetHealthPercentage(),1);
        

    }
}
