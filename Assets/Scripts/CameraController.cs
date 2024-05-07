using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float offset = 5f;
    public float smoothSpeed = 2f;

    private void Update()
    {/*
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y + (3f * offset), player.position.z - (2f * offset));
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        /*
        if (this.transform.position.x >= 125f)
        {
            transform.position = new Vector3(125f, transform.position.y, transform.position.z);
        }
        if (this.transform.position.x <= -125f)
        {
            transform.position = new Vector3(-125f, transform.position.y, transform.position.z);
        }
        if (this.transform.position.z >= 126f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 126f);
        }
        if (this.transform.position.z <= -150f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -150f);
        }
        
        Vector3 mustPos = transform.position;
        mustPos = new Vector3(Mathf.Clamp(mustPos.x, -123f, 123f), mustPos.y, Mathf.Clamp(mustPos.z, -152f, 122f));
        transform.position = mustPos;*/
    }

    private void FixedUpdate()
    {
         Vector3 targetPosition = new Vector3(player.position.x, player.position.y + (3f * offset), player.position.z - (2f * offset));
         transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

         Vector3 mustPos = transform.position;
         mustPos = new Vector3(Mathf.Clamp(mustPos.x, -123f, 123f), mustPos.y, Mathf.Clamp(mustPos.z, -152f, 122f));
         transform.position = mustPos;
    }




}
