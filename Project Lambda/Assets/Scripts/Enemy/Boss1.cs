using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Boss1 : MonoBehaviour
{
    public Transform player;
    // Note: The details of damage from a given bullet are retrieved from the player
    public Shooting playerShooting;
    // UpgradeTracker
    public UpgradeTracker upgradeTracker;
    public Rigidbody2D rigidBody;
    public GameObject BulletPrefab;

    // Boss Attributes
    public float bossSpeed;
    public float hitPoints;
    public float maxHitPoints;
    public float expValue;
    // public float DamageFromBullet;
    public float fireRate;
    public float bossP2Speed;
    
    public float timeBullet;
    public float constant;

    // Get the AIPath Component
    public AIPath path;

    // Start is called before the first frame update
    void Start()
    {
        expValue = 12;

        player = FindObjectOfType<Player>().transform;
        playerShooting = FindObjectOfType<Player>().GetComponent<Shooting>();
        upgradeTracker = FindObjectOfType<Player>().GetComponent<UpgradeTracker>();
        rigidBody = GetComponent<Rigidbody2D>();
        path = GetComponent<AIPath>();

        bossSpeed = 1.5f;
        hitPoints = 25;
        maxHitPoints = 25;
        //  DamageFromBullet = 2f;
        fireRate = 2f;
        bossP2Speed = 2.5f;

        //Boss starts firing bullets after 3 seconds
        timeBullet = Time.time + 3f;
        constant = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // rigidBody.velocity = bossSpeed * (player.position - transform.position).normalized;

        //Boss shoots every 2 seconds
        if (Time.time > timeBullet)
        {
            Shoot();
            timeBullet += fireRate;

            //Phase 2
            //After Boss takes 50% damage, Boss now triple shoots and moves 2.5x
        if (hitPoints <= 12.5)
            {
                threeShoot();
                // bossSpeed = bossP2Speed;
                path.maxSpeed = bossP2Speed;

            }
        }

        //When Boss's HP gets to zero, it dies
        if (hitPoints <= 0) {
            upgradeTracker.IncreaseExp(expValue);
            Destroy(this.gameObject);
        }
    }

    //When Boss is hit by the player's bullet, it takes 2 damage
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<PlayerBullet>()) {
            hitPoints -= playerShooting.actualBulletPower;
        }
    }

    //shoots a bullet in the direction of the player
    void Shoot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, transform.localPosition, Quaternion.identity);
        Rigidbody2D bulletRigidBody = newBullet.GetComponent<Rigidbody2D>();
        bulletRigidBody.velocity = 10f * (FindObjectOfType<Player>().transform.position * constant - transform.position).normalized;
    }
    void threeShoot()
    {
    for (float i = 1.2f; i >= 0.8f; i -= 0.2f)
    {
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
