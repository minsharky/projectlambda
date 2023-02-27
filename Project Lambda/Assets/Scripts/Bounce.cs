using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player") {
            float bounce = 600f; //amount of force to 
            Rigidbody2D player_rb = collision.gameObject.GetComponent<Rigidbody2D>();
            //player_rb.AddForce(player_rb.normal * bounce);
            //player_rb.AddForce(collision.contacts[0].normal * bounce);

            Vector2 dir = collision.gameObject.transform.position - transform.position;
            player_rb.AddForce(dir * bounce, ForceMode2D.Impulse);
        }
    }
}
