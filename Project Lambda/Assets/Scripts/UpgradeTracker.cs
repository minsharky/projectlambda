using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTracker : MonoBehaviour
{
    /// <summary>
    /// UpgradeTracker tracks the points allocated to each player's upgrades as well as controls how each upgrade
    /// is enacted as well as visualized.
    /// </summary>

    /// <summary>
    /// Field that controls whether we have upgrade points or not
    /// </summary>

    public int upgradePoints;

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


    // Health Bar Component
    // HealthBar hb;

    
    // Start is called before the first frame update
    void Start()
    {
        upgradePoints = 0;
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

    }

    // TODO: Check if the player can upgrade every frame (how many upgrade points).
    // If so, set keybinds to allocate upgrade points.
    // Upon upgrade, edit the necessary scripts to actualize upgrades
    // TODO LATER: Display the upgrade values on screen, hopefully using something like a bar.
    void Update()
    {
        // Press p to increase player speed.
        if (Input.GetKeyDown(KeyCode.P))
        {
            uPlayerSpeed++;
            // If uPlayerSpeed == 3, reset to 0
            if (uPlayerSpeed == 3)
            {
                uPlayerSpeed = 0;
            }
            playerMovement.UpdateMoveSpeed();
            speedBar.SpeedBarUpdate();
        }
        // Press f to increase firing speed
        if (Input.GetKeyDown(KeyCode.F))
        {
            uFiringSpeed++;
            // If uFiringSpeed == 3, reset to 0
            if (uFiringSpeed == 3)
            {
                uFiringSpeed = 0;
            }
            shooting.UpdateFiringSpeed();
            cooldownUpgradeBar.CooldownUpgradeBarUpdate();
        }
        // Press b to increase bit power
        if (Input.GetKeyDown(KeyCode.B))
        {
            uBitPower++;
            // If uBitPower == 3, reset to 0
            if (uBitPower == 3)
            {
                uBitPower = 0;
            }
            shooting.UpdateBitPower();
            powerUpgradeBar.PowerUpgradeBarUpdate();
        }
        // Press h to increase health
        if (Input.GetKeyDown(KeyCode.H))
        {
            uHealth++;
            // If uHealth == 3, reset to 0
            if (uHealth == 3)
            {
                uHealth = 0;
            }
            player.UpdateHealth();
            healthUpgradeBar.HealthUpgradeBarUpdate();
        }
    }
}
