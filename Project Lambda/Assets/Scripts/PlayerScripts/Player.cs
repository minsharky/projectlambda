using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float hitPoints;

    // Player Damages from Boss
    public float damageFromContact;
    public float damageFromBullet;

    // Upgrades Component
    UpgradeTracker upgrades;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        hitPoints = 100;

        damageFromContact = 5f;
        damageFromBullet = 2f;

        // Upgrades
        upgrades = GetComponent<UpgradeTracker>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hitPoints -= damageFromContact;
        }
        if (collision.gameObject.GetComponent<EnemyBullet>())
        {
            hitPoints -= damageFromBullet;
        }
    }

    public void UpdateHealth()
    {
        hitPoints = 100 + 50 * upgrades.uHealth;
    }
}
