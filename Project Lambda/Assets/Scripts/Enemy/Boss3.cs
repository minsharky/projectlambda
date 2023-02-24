using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class Boss3 : MonoBehaviour
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
    public float maxHitPoints = 100;
    public float expValue;
    // public float DamageFromBullet;
    public float fireRate;
    public float bossP2Speed;

    public float timeBullet;
    public float timeVolley;
    public float constant;

    // Get the AIPath Component
    public AIPath path;

    public Boolean sound_played;

    public AudioSource gotHitSound;
    public AudioSource deathSound;

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
        hitPoints = 100;
        //  DamageFromBullet = 2f;
        fireRate = 3f;
        bossP2Speed = 5f;

        //Boss starts firing bullets after 3 seconds
        timeBullet = Time.time + 3f;
        constant = 1;

        sound_played = false;
    }

    // Update is called once per frame
    void Update()
    {
        // rigidBody.velocity = bossSpeed * (player.position - transform.position).normalized;

        //Boss shoots every 2 seconds
        if (Time.time > timeBullet)
        {
            fiveShoot();
            // bossSpeed = bossP2Speed;
            // Recall that speed is controlled by the AIPath component
            path.maxSpeed = bossP2Speed;

            timeBullet += fireRate;
        }

        //When Boss's HP gets to zero, it dies
        if (hitPoints <= 0)
        {
            if (!sound_played)
            {
                upgradeTracker.IncreaseExp(expValue);
                deathSound.Play();
                sound_played = true;
            }
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this.gameObject, 0.3f);
        }
    }

    //When Boss is hit by the player's bullet, it takes 2 damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBullet>())
        {
            hitPoints -= playerShooting.actualBulletPower;
            twentyShoot();
            gotHitSound.Play();
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
    void twentyShoot()
    {
        for (float i = 2f; i >= 0f; i -= 0.1f)
        {
            Debug.Log(i);
            constant = i;
            Shoot();
        }
    }
}
