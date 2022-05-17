using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    // Reference to the player's transform. 
    public Transform player;

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x,
            player.transform.position.y, transform.position.z);
    }
}