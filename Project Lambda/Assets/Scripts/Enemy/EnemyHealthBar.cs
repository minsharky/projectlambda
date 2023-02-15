using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform enemy;
    public Image background;
    public Image bar;
    void Update()
    {
        transform.position = enemy.position;
        
        // Puts bar below enemy
        transform.SetAsLastSibling();
    }
    public void UpdatePlayerHealth(float healthPercent)
    {
        // Fills bar
        bar.fillAmount = healthPercent;
    }
}
