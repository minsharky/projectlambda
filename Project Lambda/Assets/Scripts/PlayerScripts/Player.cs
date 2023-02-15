using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    private float hitPoints = 100f;
    private float maxHitPoints = 100f;
    private float baseHitPoints = 100f;

    // Player Damages from Boss
    public float damageFromContact;
    public float damageFromBullet;

    // Upgrades Component
    UpgradeTracker upgrades;

    // HealthBar
    PlayerHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        damageFromContact = 5f;
        damageFromBullet = 2f;

        // Components
        upgrades = GetComponent<UpgradeTracker>();
        healthBar = GameObject.FindGameObjectWithTag("Player Health Bar").GetComponent<PlayerHealthBar>();
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
        healthBar.UpdatePlayerHealth();
        checkGameOver();
    }

    public void UpdateHealth()
    {
        maxHitPoints = baseHitPoints + (50 * upgrades.uHealth);
        healthBar.UpdatePlayerHealth();
    }

    public float getHitPoints()
    {
        return hitPoints;
    }

    public float getMaxHitPoints()
    {
        return maxHitPoints;
    }
    private void checkGameOver()
    {
        if (hitPoints <= 0)
        {

            Time.timeScale = 0;
        }
    }
}
