using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DestinationSetter : MonoBehaviour
{
    IAstarAI a;
    Transform player;
    Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<IAstarAI>();
        player = FindObjectOfType<Player>().transform;
        enemy = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, enemy.position) < 10)
        {
            a.destination = player.position;
        }
    }
}
