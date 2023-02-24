using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTracker : MonoBehaviour
{
    /// <summary>
    /// UpgradeTracker tracks the points allocated to each player's upgrades as well as controls how each upgrade
    /// is enacted as well as visualized.
    /// </summary>

    /// Experience tracker (Foundation of Upgrade Economy)
    public float exp;
    public float expToUpgrade; 

    /// <summary>
    /// Fields that store the potency of each upgrade
    /// </summary>

    public int uBitPower;
    public int uFiringSpeed;
    public int uHealth;
    public int uArmor;
    public int uRegenSpeed;
    public int uPlayerSpeed;

    // Player Movement Component
    PlayerMovement playerMovement;

    // Shooting Component
    Shooting shooting;

    // Player Component
    Player player;

    // Speed Bar Component
    SpeedUpgradeBar speedBar;

    // Health Upgrade Bar Component
    HealthUpgradeBar healthUpgradeBar;

    // Cooldown Upgrade Bar Component
    CooldownUpgradeBar cooldownUpgradeBar;

    // Power Upgrade Bar
    PowerUpgradeBar powerUpgradeBar;

    // Experience Bar
    ExperienceBar expBar;

    public AudioSource upgradeSound;
    public AudioSource experienceSound;
    public Boolean sound_played;
    

    
    // Start is called before the first frame update
    void Start()
    {
        exp = 0;
        expToUpgrade = 15;

        uBitPower = 0;
        uFiringSpeed = 0;
        uHealth = 0;
        uArmor = 0;
        uRegenSpeed = 0;
        uPlayerSpeed = 0;

        // Components
        playerMovement = GetComponent<PlayerMovement>();
        shooting = GetComponent<Shooting>();
        player = GetComponent<Player>();
        // hb = GetComponent<HealthBar>();
        speedBar = GameObject.FindGameObjectWithTag("Speed Bar").GetComponent<SpeedUpgradeBar>();
        healthUpgradeBar = GameObject.FindGameObjectWithTag("Health Upgrade Bar").GetComponent<HealthUpgradeBar>();
        cooldownUpgradeBar = GameObject.FindGameObjectWithTag("Cooldown Bar").GetComponent<CooldownUpgradeBar>();
        powerUpgradeBar = GameObject.FindGameObjectWithTag("Power Bar").GetComponent<PowerUpgradeBar>();
        expBar = GameObject.FindGameObjectWithTag("Experience Bar").GetComponent<ExperienceBar>();
        sound_played = false;

    }

    // TODO: Check if the player can upgrade every frame (how many upgrade points).
    // If so, set keybinds to allocate upgrade points.
    // Upon upgrade, edit the necessary scripts to actualize upgrades
    // TODO LATER: Display the upgrade values on screen, hopefully using something like a bar.
    void Update()
    {
        if (exp >= expToUpgrade)
        {
            if (!sound_played)
            {
                experienceSound.Play();
                sound_played = true;
            }
        }
        else {
            sound_played = false;
        }
    }

    public void TryToUpgradeSpeed()
    {
        // Press p to increase player speed.
        if (exp >= expToUpgrade)
        {
            uPlayerSpeed++;
            // If uPlayerSpeed == 3, reset to 0
            if (uPlayerSpeed == 3)
            {
                uPlayerSpeed = 3;
            }
            else
            {
                exp -= 20;
            }
            playerMovement.UpdateMoveSpeed();
            speedBar.SpeedBarUpdate();
            upgradeSound.Play();
        }
    }

    public void TryToUpgradeHealth()
    {
        if (exp >= expToUpgrade)
        {
            uHealth++;
            // If uHealth == 3, reset to 0
            if (uHealth == 3)
            {
                uHealth = 3;
            }
            else
            {
                exp -= 20;
            }
            player.UpdateHealthUpgrade();
            healthUpgradeBar.HealthUpgradeBarUpdate();
            upgradeSound.Play();
        }
    }

    public void TryToUpgradeFiringSpeed()
    {
        if (exp >= expToUpgrade)
        {
            uFiringSpeed++;
            // If uFiringSpeed == 3, reset to 0
            if (uFiringSpeed == 3)
            {
                uFiringSpeed = 3;
            }
            else
            {
                exp -= 20;
            }
            shooting.UpdateFiringSpeed();
            cooldownUpgradeBar.CooldownUpgradeBarUpdate();
            upgradeSound.Play();
        }
    }

    public void TryToUpgradePower()
    {
        if (exp >= expToUpgrade)
        {
            uBitPower++;
            // If uBitPower == 3, reset to 0
            if (uBitPower == 3)
            {
                uBitPower = 3;
            }
            else
            {
                exp -= 20;
            }
            shooting.UpdateBitPower();
            powerUpgradeBar.PowerUpgradeBarUpdate();
            upgradeSound.Play();
        }
    }

    // Update exp
    public void IncreaseExp(float delta)
    {
        exp += delta;
    }
}
