using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Boss1HB : MonoBehaviour
{
    // Get the HealthBar Slider component
    Slider healthBar;
    Boss1 boss;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        boss = GameObject.FindObjectOfType<Boss1>().GetComponent<Boss1>();
        healthBar.minValue = -5f;
    }

    // Update Player Health
    // It takes no inputs, and returns no outputs
    // It just fixes the UI health bar
    public void UpdatePlayerHealth()
    {
        healthBar.maxValue = boss.getMaxHitPoints();
        healthBar.minValue = -healthBar.maxValue / 20;
        healthBar.value = boss.getHitPoints();
    }

    private void Update()   
    {
        UpdatePlayerHealth();
        //transform.position = boss.transform.position;
        //transform.SetAsLastSibling();
    }
}