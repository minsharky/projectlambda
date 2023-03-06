using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Rigid Body variable
    public Rigidbody2D rigidBody;

    // HitPoints variables
    // Current number of hit points
    public float hitPoints = 25f;
    // Maximum number of hit points
    private float maxHitPoints = 25f;
    // The maximum number of hit points assigned at the beginning of the game
    // This is used to compute maxHitPoints after upgrades
    private float baseHitPoints = 25f;
    // Regen Rate
    public float regenRate = 1f / 120f;

    // Player Damages from Boss
    public float damageFromContact;
    public float damageFromBullet;

    // Upgrades Component
    UpgradeTracker upgrades;

    // HealthBar
    PlayerHealthBar healthBar;

    Shooting shooting;
    PlayerMovement playerMovement;


    //Audios
    public AudioSource wallCrashSound;
    public AudioSource redDoorSound;
    public AudioSource enemyClearedSound;
    public AudioSource enemyContactSound;
    public AudioSource enemyBulletSound;

    public AudioSource babyDeath;
    public AudioSource bossDeath;

    private int current_level;
    public int Current_level
    {
        get { return current_level; }
        set { current_level = value; }
    }

    private Boolean sound_played;
    public Boolean Sound_played
    {
        set { sound_played = value; }
    }

    Scene scene;

    private Boolean boss_one_complete;
    public Boolean Boss_one_complete
    {
        get { return boss_one_complete; }
        set { boss_one_complete = value; }
    }
    private Boolean boss_two_complete;
    public Boolean Boss_two_complete
    {
        get { return boss_two_complete; }
        set { boss_two_complete = value; }
    }
    private Boolean boss_three_complete;
    public Boolean Boss_three_complete
    {
        get { return boss_three_complete; }
        set { boss_three_complete = value; }
    }
    private Boolean boss_four_complete;
    public Boolean Boss_four_complete
    {
        get { return boss_four_complete; }
        set { boss_four_complete = value; }
    }

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
        damageFromContact = 1f;
        damageFromBullet = 2f;
        // Components
        upgrades = GetComponent<UpgradeTracker>();
        healthBar = GameObject.FindGameObjectWithTag("Player Health Bar").GetComponent<PlayerHealthBar>();
        shooting = GetComponent<Shooting>();
        playerMovement= GetComponent<PlayerMovement>();

        boss_one_complete = false;
        boss_two_complete = false;
        boss_three_complete = false;
        boss_four_complete = false;
        scene = SceneManager.GetActiveScene();
        current_level = 1;

        sound_played = false;
    }

    private void Update()
    {
        scene = SceneManager.GetActiveScene();
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            if ((!Boss_one_complete && scene.name == "Boss1Route") ||
            (!Boss_two_complete && scene.name == "Boss2Route") ||
            (!Boss_three_complete && scene.name == "Boss3Route"))
            {
                if (!sound_played)
                {
                    enemyClearedSound.Play();
                    sound_played = true;
                }
            }
        }
        else

        if ((Boss_one_complete && (scene.name == "Boss1Route" || scene.name == "Boss1Room")) ||
            (Boss_two_complete && (scene.name == "Boss2Route" || scene.name == "Boss2Room")) ||
            (Boss_three_complete && (scene.name == "Boss3Route" || scene.name == "Boss3Room")) ||
            (Boss_four_complete && scene.name == "Boss4Room"))
        {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(enemy);
            }
        }

        else if (GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
        {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (enemy.GetComponent<BabyMob>() != null && enemy.GetComponent<BabyMob>().Hit_Points <= 0) {
                    babyDeath.Play();
                }
                if (enemy.GetComponent<Boss1>() != null && enemy.GetComponent<Boss1>().Hit_Points <= 0)
                {
                    bossDeath.Play();
                }
                if (enemy.GetComponent<Boss2>() != null && enemy.GetComponent<Boss2>().Hit_Points <= 0)
                {
                    bossDeath.Play();
                }
                if (enemy.GetComponent<Boss3>() != null && enemy.GetComponent<Boss3>().Hit_Points <= 0)
                {
                    bossDeath.Play();
                }
                if (enemy.GetComponent<Boss4>() != null && enemy.GetComponent<Boss4>().Hit_Points <= 0)
                {
                    bossDeath.Play();
                    ResetGame();
                    SceneManager.LoadScene("Credits Menu");
                    DontDestroyOnLoad(gameObject);
                }

            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hitPoints -= damageFromContact;
            rigidBody.AddForce(collision.gameObject.transform.right * 100);
            enemyContactSound.Play();
        }
        if (collision.gameObject.GetComponent<EnemyBullet>())
        {
            hitPoints -= damageFromBullet;
            enemyBulletSound.Play();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            wallCrashSound.Play();
        }

        if (collision.gameObject.CompareTag("Tunnel") && !collision.gameObject.GetComponent<BoxCollider2D>().isTrigger)
        {
            redDoorSound.Play();
        }

        /*if (collision.gameObject.CompareTag("Bounce"))
        {
            Vector2 difference = transform.position - collision.gameObject.transform.position;
            //makes it looks like teleports :/
            rigidBody.AddForce(difference*5000f, ForceMode2D.Force);
        }*/
        healthBar.UpdatePlayerHealth();
        checkGameOver();
    }

    public void UpdateHealthUpgrade()
    {
        maxHitPoints = baseHitPoints + (10 * upgrades.uHealth);
        healthBar.UpdatePlayerHealth();
    }

    public void HealthRegen()
    {
        if (hitPoints + regenRate <= maxHitPoints)
        {
            hitPoints += regenRate;
        }
        else
        {
            hitPoints = maxHitPoints;
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
    private void checkGameOver()
    {
        if (hitPoints <= 0)
        {
            ResetGame();
            SceneManager.LoadScene("Death Menu");
            DontDestroyOnLoad(gameObject);
            //Time.timeScale = 0;
        }
    }
    
    private void ResetGame()
    {
        upgrades.exp = 0;
        upgrades.uBitPower = 0;
        upgrades.uFiringSpeed = 0;
        upgrades.uHealth = 0;
        upgrades.uArmor = 0;
        upgrades.uRegenSpeed = 0;
        upgrades.uPlayerSpeed = 0;
        UpdateHealthUpgrade();
        playerMovement.UpdateMoveSpeed();
        shooting.UpdateFiringSpeed();
        shooting.UpdateBitPower();
        boss_one_complete = false;
        boss_two_complete = false;
        boss_three_complete = false;
        boss_four_complete = false;
        current_level = 1;
    }
}