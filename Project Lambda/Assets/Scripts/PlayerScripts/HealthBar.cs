using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Get the HealthBar Slider component
    Slider healthBar; 
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        healthBar.value = 1f;
    }

    // Update Player Health
    // It takes no inputs, and returns no outputs
    // It just fixes the UI health bar
    public void UpdatePlayerHealth()
    {
        healthBar.maxValue = player.getMaxHitPoints();
        healthBar.value = player.getHitPoints();
    }
}
