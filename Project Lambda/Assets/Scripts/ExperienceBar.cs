using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public float expValue = 0;
    public float expMax = 20;

    // Slider component
    Slider expBar;
    // UpgradeTracker component
    UpgradeTracker upgradeTracker;

    // Start is called before the first frame update
    void Start()
    {
        expBar = GetComponent<Slider>();
        upgradeTracker = FindObjectOfType<Player>().GetComponent<UpgradeTracker>();
        expBar.value = expValue;
        expBar.maxValue = expMax;
    }

    void Update()
    {
        UpdateExpBar();
    }

    // UpdateExpBar is something for UpgradeTracker to call to update the UI
    public void UpdateExpBar()
    {
        expBar.value = upgradeTracker.exp;
        // We are assuming that expMax can't change. If it can, then uncomment the following line
        // expBar.max = expMax;
    }
}
