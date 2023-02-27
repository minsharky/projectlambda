using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Boss2HB : MonoBehaviour
{
    // Get the HealthBar Slider component
    Slider healthBar;
    Boss2 boss;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        boss = FindObjectOfType<Boss2>().GetComponent<Boss2>();
        //healthBar.minValue = 0f;
    }

    // Update Player Health
    // It takes no inputs, and returns no outputs
    // It just fixes the UI health bar
    public void UpdatePlayerHealth()
    {
        healthBar.maxValue = boss.getMaxHitPoints();
        //healthBar.minValue = -healthBar.maxValue / 20;
        healthBar.value = boss.getHitPoints();
    }

    private void Update()   
    {
        if (boss == null)
        {
            Destroy(healthBar);
        }
        UpdatePlayerHealth();
        //transform.position = boss.transform.position;
        //transform.SetAsLastSibling();
    }
}