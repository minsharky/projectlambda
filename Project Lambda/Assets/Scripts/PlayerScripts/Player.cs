using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float hitPoints;

    // Upgrades Component
    UpgradeTracker upgrades;

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = 100;
        rigidBody = GetComponent<Rigidbody2D>();

        // Upgrades
        upgrades = GetComponent<UpgradeTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hitPoints -= 2;
        }
        if (collision.gameObject.GetComponent<EnemyBullet>())
        {
            hitPoints -= 2;
        }
    }

    public void UpdateHealth()
    {
        hitPoints = 100 + 50 * upgrades.uHealth;
    }
}
