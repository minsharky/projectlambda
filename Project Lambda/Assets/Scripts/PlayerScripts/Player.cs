using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Rigid Body variable
    public Rigidbody2D rigidBody;

    // HitPoints variables
    // Current number of hit points
    public float hitPoints = 100f;
    // Maximum number of hit points
    private float maxHitPoints = 100f;
    // The maximum number of hit points assigned at the beginning of the game
    // This is used to compute maxHitPoints after upgrades
    private float baseHitPoints = 100f;


    // Player Damages from Boss
    public float damageFromContact;
    public float damageFromBullet;

    // Upgrades Component
    UpgradeTracker upgrades;

    // HealthBar
    PlayerHealthBar healthBar;

    private static Player _instance;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

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
            rigidBody.AddForce(collision.gameObject.transform.right * 100);
        }
        if (collision.gameObject.GetComponent<EnemyBullet>())
        {
            hitPoints -= damageFromBullet;
        }
        if (collision.gameObject.CompareTag("Bounce"))
        {
            Vector2 difference = transform.position - collision.gameObject.transform.position;
            //makes it looks like teleports :/
            rigidBody.AddForce(difference*5000f, ForceMode2D.Force);
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