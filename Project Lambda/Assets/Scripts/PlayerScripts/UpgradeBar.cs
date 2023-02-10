using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeBar : MonoBehaviour
{
    // Start is called before the first frame update
    Slider BitPower;
    Slider FiringSpeed;
    Slider Armor;
    Slider RegenSpeed;
    Slider PlayerSpeed;

    Player player;

    UpgradeTracker upgrades;

    int maxValue = 5;

    bool showing;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        upgrades = GetComponent<UpgradeTracker>();
        BitPower.value = 1f;
        FiringSpeed.value = 1f;
        Armor.value = 1f;
        RegenSpeed.value = 1f;
        PlayerSpeed.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Toggle();
        if (showing)
        {
            BitPower.maxValue = maxValue;
            BitPower.value = upgrades.uBitPower;
            FiringSpeed.maxValue = maxValue;
            FiringSpeed.value = upgrades.uFiringSpeed;
            Armor.maxValue = maxValue;
            Armor.value = upgrades.uArmor;
            RegenSpeed.maxValue = maxValue;
            RegenSpeed.value = upgrades.uRegenSpeed;
            PlayerSpeed.maxValue = maxValue;
            PlayerSpeed.value = upgrades.uPlayerSpeed;
        }
        if (!showing)
        {
            
        }
        
    }
    void Toggle()
    {
        if (showing && Input.GetKeyDown(KeyCode.U))
        {
            showing = false;
        }

        if (!showing && Input.GetKeyDown(KeyCode.U))
        {
            showing = true;
        }
    }
}
