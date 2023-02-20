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
        enemy = transform.parent.gameObject;
        healthBar.value = 0;
    }
    void Update()
    {
        //transform.position = enemy.transform.position;
        transform.localPosition = Vector3.zero;
        // Puts bar below enemy
        transform.SetAsLastSibling();
    }
    public void UpdateEnemyHealth(float hitPoints, float maxHitPoints)
    {
        healthBar.maxValue = hitPoints;
        healthBar.value = maxHitPoints;
    }
}
