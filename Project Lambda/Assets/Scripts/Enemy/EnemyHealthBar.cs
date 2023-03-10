using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class EnemyHealthBar : MonoBehaviour
{
    Slider healthBar;
    GameObject enemy;
    private void Start()
    {
        healthBar = GetComponent<Slider>();
        healthBar.value = 0;
    }
    void Update()
    {
        transform.position = enemy.transform.position;
        
        // Puts bar below enemy
        transform.SetAsLastSibling();
    }
    public void UpdateEnemyHealth(float hitPoints, float maxHitPoints)
    {
        //healthBar.maxValue = enemy.getMaxHitPoints();
        //healthBar.value = enemy.getHitPoints();
    }
}
