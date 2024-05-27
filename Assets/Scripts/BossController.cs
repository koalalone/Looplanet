using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject portal;

    private void Start()
    {
        portal = GameObject.Find("Portal");
        if(portal != null)
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
}
