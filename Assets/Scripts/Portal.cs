using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        //gameObject.SetActive(false);
    }

    public void ActivatePortal()
    {
        gameObject.SetActive(true);
    }

    public void DeactivatePortal()
    {
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
