using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class HealthUpgradeBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Slider healthUpgradeBar;
    UpgradeTracker upgradeTracker;
    float level = 1;

    // Start is called before the first frame update
    void Start()
    {
        healthUpgradeBar = GetComponent<Slider>();
        healthUpgradeBar.value = (float)level / 3;
        upgradeTracker = GameObject.FindGameObjectWithTag("Player").GetComponent<UpgradeTracker>();
    }

    // Update is called once per frame
    public void HealthUpgradeBarUpdate()
    {
        level = upgradeTracker.uHealth + 1;
        healthUpgradeBar.value = (float)level / 3;
    }

    private void Update()
    {
        HealthUpgradeBarUpdate();
    }
    // For Tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.ShowStatic("Health Upgrade");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideStatic();
    }
}
