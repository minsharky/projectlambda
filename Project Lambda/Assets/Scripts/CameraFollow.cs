using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Start()
    {
        offset = new Vector3(0.5f, 0.5f, -10);
    }

    // Update is called once per frame
    void Update()
    {
        // Camera follows the player with specified offset position
        //transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); 
        transform.position = new Vector3(player.position.x, player.position.y, offset.z);
    }
}
