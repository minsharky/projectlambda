using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float time;
    void Start()
    {
        time = Time.time;
        int bulletLayer = LayerMask.NameToLayer("Enemy Bullet");
        int ignoreLayer = LayerMask.NameToLayer("Enemy");
        Physics.IgnoreLayerCollision(bulletLayer, ignoreLayer, true);
        Physics.IgnoreLayerCollision(bulletLayer, bulletLayer, true);

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
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        
    }
}
