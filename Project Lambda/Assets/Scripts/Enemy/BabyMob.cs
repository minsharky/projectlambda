using System;
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
    SpriteRenderer spriteRenderer;

    //Boss Attributes
    public float babySpeed;
    private float hitPoints;// How much is this enemy worth in terms of player experience?
    public float Hit_Points
    {
        get { return hitPoints; }
    }
    // How much is this enemy worth in terms of player experience?
    public float expValue;
    // public float DamageFromBullet;
    public float fireRate;
    public float babyP2Speed;

    Color originalColor;
    Color redColor;
    float redDuration;

    public float timeBullet;
    public float constant;

    public Boolean sound_played;

    public AudioSource gotHitSound;
    public AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        expValue = 1;
        player = FindObjectOfType<Player>().transform;
        playerShooting = FindObjectOfType<Player>().GetComponent<Shooting>();
        rigidBody = GetComponent<Rigidbody2D>();
        upgradeTracker = FindObjectOfType<Player>().GetComponent<UpgradeTracker>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        redColor = new Color(1f, 0f, 0f, 1f);
        redDuration = 0.1f;

        babySpeed = 1.5f;
        hitPoints = 2;
        // DamageFromBullet = 0.5f;
        fireRate = 2f;

        // Baby starts firing bullets after 3 seconds
        timeBullet = Time.time + 3f;
        constant = 1;

        sound_played = false;
    }

    // Update is called once per frame
    void Update()
    {
        // rigidBody.velocity = babySpeed * (player.position - transform.position).normalized;

        //Boss shoots every 2 seconds
        if (Time.time > timeBullet)
        {
            if (! sound_played)
            {
                Shoot(); 
            }
            
            timeBullet += fireRate;
        }

        //When Boss's HP gets to zero, it dies
        if (hitPoints <= 0)
        {
            
            // Enemy should die
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
            gotHitSound.Play();
            spriteRenderer.color = redColor;
            StartCoroutine(returnWhite());
        }
    }

    //Hit indicator coroutine
    IEnumerator returnWhite()
    {
        yield return new WaitForSeconds(redDuration);
        spriteRenderer.color = originalColor;
    }

    //shoots a bullet in the direction of the player
    void Shoot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, transform.localPosition, Quaternion.identity);
        Rigidbody2D bulletRigidBody = newBullet.GetComponent<Rigidbody2D>();
        bulletRigidBody.velocity = 10f * (FindObjectOfType<Player>().transform.position * constant - transform.position).normalized;
    }
}
