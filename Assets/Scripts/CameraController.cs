using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float offset;
    public float smoothSpeed = 0.125f;

    private void Update()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y + (1.5f * offset), player.position.z - offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
