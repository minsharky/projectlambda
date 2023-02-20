using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Boss4 : MonoBehaviour
{
    public Transform player;
    // Note: The details of damage from a given bullet are retrieved from the player
    public Shooting playerShooting;
    // UpgradeTracker
    public UpgradeTracker upgradeTracker;
    public Rigidbody2D rigidBody;
    public GameObject BulletPrefab;
    public GameObject BabyPrefab;
    public int babyCounter = 4;

    // Boss Attributes
    public float bossSpeed;
    public float hitPoints;
    public float maxHitPoints = 100;
    public float expValue = 10;
    // public float DamageFromBullet;
    public float fireRate;
    public float bossP2Speed;

    public float timeBullet;
    public float timeVolley;
    public float constant;

    // Get the AIPath Component
    public AIPath path;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        playerShooting = FindObjectOfType<Player>().GetComponent<Shooting>();
        upgradeTracker = FindObjectOfType<Player>().GetComponent<UpgradeTracker>();
        rigidBody = GetComponent<Rigidbody2D>();
        path = GetComponent<AIPath>();

        bossSpeed = 1.5f;
        hitPoints = 100;
        //  DamageFromBullet = 2f;
        fireRate = 3f;
        bossP2Speed = 5f;

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
            twentyShoot();
            // bossSpeed = bossP2Speed;
            // Recall that speed is controlled by the AIPath component
            path.maxSpeed = bossSpeed;

            timeBullet += fireRate;
        }

        if (hitPoints <= 50)
        {
            path.maxSpeed = bossP2Speed;

        }
        //When Boss's HP gets to zero, it dies
        if (hitPoints <= 0)
        {
            upgradeTracker.IncreaseExp(expValue);
            Destroy(this.gameObject);
        }
    }

    //When Boss is hit by the player's bullet, it takes 2 damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBullet>())
        {
            hitPoints -= playerShooting.actualBulletPower;
            twentyShoot();
            spawnBaby();
            babyCounter -= 1;
            if (babyCounter == 0)
            {
                Debug.Log(babyCounter);
                babyCounter = 4;
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

    void twentyShoot()
    {
        for (float i = 2f; i >= 0f; i -= 0.1f)
        {
            Debug.Log(i);
            constant = i;
            Shoot();
        }
    }

    void spawnBaby()
    {
        GameObject newBaby = Instantiate(BabyPrefab, transform.localPosition, Quaternion.identity);
        newBaby.GetComponent<BabyMob>().BulletPrefab = BulletPrefab;
    }
}
