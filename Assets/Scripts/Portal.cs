using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int scene;
    GameObject portalText;

    private void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        portalText = GameObject.Find("PortalText");
        //gameObject.SetActive(false);
    }

    public void ActivatePortal()
    {
        gameObject.SetActive(true);
        StartCoroutine(PortalText());
        
    }

    private IEnumerator PortalText()
    {
        portalText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        portalText.gameObject.SetActive(false);
    }

    public void DeactivatePortal()
    {
        portalText.gameObject.SetActive(false );
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ActivationCheck.props.Clear();
            if (scene + 1 > 3)
            {
                SceneManager.LoadScene(1);
                return;
            }
            SceneManager.LoadScene(scene + 1);
        }
    }
}
