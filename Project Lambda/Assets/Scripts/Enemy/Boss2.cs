using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Boss2 : MonoBehaviour
{
    public Transform player;
    public Shooting playerShooting;
    public UpgradeTracker upgradeTracker;
    public Rigidbody2D rigidBody;
    public GameObject BulletPrefab;
    public AIPath path; 

    //Boss Attributes
    public float bossSpeed;
    public float maxHitPoints;
    public float hitPoints;
    public float expValue = 10;
    // public float DamageFromBullet;
    public float fireRate;
    public float bossP2Speed;
    
    public float timeBullet;
    public float constant;

    EnemyHealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        playerShooting = FindObjectOfType<Player>().GetComponent<Shooting>();
        upgradeTracker = FindObjectOfType<Player>().GetComponent<UpgradeTracker>();
        rigidBody = GetComponent<Rigidbody2D>();
        path = GetComponent<AIPath>();

        bossSpeed = 1.5f;
        maxHitPoints = 50f;
        hitPoints = 50f;
        // DamageFromBullet = 2f;
        fireRate = 2f;
        bossP2Speed = 2.5f;

        // Boss starts firing bullets after 3 seconds
        timeBullet = Time.time + 3f;
        constant = 1;

        // Health Bar
        healthBar = GetComponent<EnemyHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = bossSpeed * (player.position - transform.position).normalized;

        //Boss shoots 5 bullet spray every 2 seconds
        if (Time.time > timeBullet)
        {
            Shoot();
            constant = 1.2f;
            Shoot();
            constant = 1.1f;
            Shoot();
            constant = 0.9f;
            Shoot();
            constant = 0.8f;
            Shoot();
            // bossSpeed = bossP2Speed;
            // Recall that speed is controlled by the AIPath component
            path.maxSpeed = bossP2Speed;

            timeBullet += fireRate;
        }

        //When Boss's HP gets to zero, it dies
        if (hitPoints <= 0) {
            upgradeTracker.IncreaseExp(expValue);
            Destroy(this.gameObject);
        }

        //healthBar.UpdateEnemyHealth(hitPoints / maxHitPoints);
    }

    //When Boss is hit by the player's bullet, it takes 2 damage
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<PlayerBullet>()) {
            hitPoints -= playerShooting.actualBulletPower;
            if (hitPoints <= 25)
            {
                bossSpeed = 5.0f;
                fiveShoot();
            }
        }
    }

    //shoots a bullet in the direction of the player
    void Shoot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, transform.localPosition, Quaternion.identity);
        Rigidbody2D bulletRigidBody = newBullet.GetComponent<Rigidbody2D>();
        bulletRigidBody.velocity = 10f * (FindObjectOfType<Player>().transform.position * constant - transform.position).normalized;
    }
    void fiveShoot()
    {
        for (float i = 1.2f; i >= 0.8f; i -= 0.1f)
        {
            Debug.Log(i);
            constant = i;
            Shoot();
        }
    }
    public float getHitPoints()
    {
        return hitPoints;
    }

    public float getMaxHitPoints()
    {
        return maxHitPoints;
    }
}
