using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayerHealthBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Get the HealthBar Slider component
    Slider healthBar;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        healthBar.minValue = -5f;
    }

    // Update Player Health
    // It takes no inputs, and returns no outputs
    // It just fixes the UI health bar
    public void UpdatePlayerHealth()
    {
        healthBar.maxValue = player.getMaxHitPoints();
        healthBar.minValue = - healthBar.maxValue / 20;
        healthBar.value = player.getHitPoints();
    }

    // For Tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.ShowStatic("Health Bar");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideStatic();
    }


    private void Update()
    {
        UpdatePlayerHealth();
    }
}