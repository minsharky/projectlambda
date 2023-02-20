using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMob : MonoBehaviour
{
    public Transform player;
    // Note: We get "DamageFromBullet" values directly from Player Shooting now
    public Shooting playerShooting;
    public UpgradeTracker upgradeTracker;
    public Rigidbody2D rigidBody;
    public GameObject BulletPrefab;

    //Boss Attributes
    public float babySpeed;
    public float hitPoints;
    // How much is this enemy worth in terms of player experience?
    public float expValue = 1;
    // public float DamageFromBullet;
    public float fireRate;
    public float babyP2Speed;

    public float timeBullet;
    public float constant;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        playerShooting = FindObjectOfType<Player>().GetComponent<Shooting>();
        rigidBody = GetComponent<Rigidbody2D>();
        upgradeTracker = FindObjectOfType<Player>().GetComponent<UpgradeTracker>();

        babySpeed = 1.5f;
        hitPoints = 2;
        // DamageFromBullet = 0.5f;
        fireRate = 2f;

        // Baby starts firing bullets after 3 seconds
        timeBullet = Time.time + 3f;
        constant = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // rigidBody.velocity = babySpeed * (player.position - transform.position).normalized;

        //Boss shoots every 2 seconds
        if (Time.time > timeBullet)
        {
            Shoot();
            timeBullet += fireRate;
        }

        //When Boss's HP gets to zero, it dies
        if (hitPoints <= 0)
        {
            // Update Player's exp level
            upgradeTracker.IncreaseExp(expValue);
            // Enemy should die
            Destroy(this.gameObject);
        }
    }

    //When Boss is hit by the player's bullet, it takes 2 damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBullet>())
        {
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
}
