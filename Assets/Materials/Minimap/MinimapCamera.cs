using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Transform player;
    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);

        Vector3 mustPos = targetPosition;
        mustPos = new Vector3(Mathf.Clamp(mustPos.x, -115f, 115f), mustPos.y, Mathf.Clamp(mustPos.z, -115f, 115f));
        transform.position = mustPos;
    }
}
