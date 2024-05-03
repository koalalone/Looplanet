using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class ActivationCheck : MonoBehaviour
{
    public GameObject player;
    public static List<GameObject> props = new List<GameObject>();
    public float activationDistance = 30f;

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActivationControl());
    }

    
    IEnumerator ActivationControl()
    {
        while (true)
        {
            Debug.Log(props.Count);
            foreach (GameObject obj in props)
            {
                float distance = Vector3.Distance(player.transform.position, obj.transform.position);

                if (distance <= activationDistance)
                {
                    obj.gameObject.SetActive(true);
                }
                else
                {
                    obj.gameObject.SetActive(false);
                }
            }
            
            

            yield return new WaitForSeconds(1f);
        }
    }
}
