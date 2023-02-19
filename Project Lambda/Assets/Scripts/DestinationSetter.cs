using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DestinationSetter : MonoBehaviour
{
    IAstarAI a;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<IAstarAI>();
        player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        a.destination = player.position;
    }
}
