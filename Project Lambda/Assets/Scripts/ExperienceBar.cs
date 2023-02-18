using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExperienceBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float expValue = 0;
    public float expMax;

    // Slider component
    Slider expBar;
    // UpgradeTracker component
    UpgradeTracker upgradeTracker;

    // Start is called before the first frame update
    void Start()
    {
        expBar = GetComponent<Slider>();
        upgradeTracker = FindObjectOfType<Player>().GetComponent<UpgradeTracker>();
        expBar.minValue = -1;
        expBar.value = expValue;
        expBar.maxValue = upgradeTracker.expToUpgrade;
    }

    void Update()
    {
        UpdateExpBar();
    }

    
    // For Tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.ShowStatic("Experience Bar");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideStatic();
    }


    // UpdateExpBar is something for UpgradeTracker to call to update the UI
    void UpdateExpBar()
    {
        expBar.value = upgradeTracker.exp;
        // We are assuming that expMax can't change. If it can, then uncomment the following line
        // expBar.max = expMax;
    }
}
