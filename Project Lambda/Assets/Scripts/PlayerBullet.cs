using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float time;

    void Start()
    {
        time = Time.time;
    }
    void Update()
    {
        if (Time.time > time + 5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") ||
          collision.gameObject.CompareTag("Wall") ||
          collision.gameObject.CompareTag("Bounce") ||
          collision.gameObject.CompareTag("Tunnel"))
        {
            Destroy(this.gameObject);
        }
    }
}
