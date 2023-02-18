using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CooldownUpgradeBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Slider cooldownUpgradeBar;
    UpgradeTracker upgradeTracker;
    float level = 1;

    // Start is called before the first frame update
    void Start()
    {
        cooldownUpgradeBar = GetComponent<Slider>();
        cooldownUpgradeBar.value = level / 3;
        upgradeTracker = GameObject.FindGameObjectWithTag("Player").GetComponent<UpgradeTracker>();
    }

    public void CooldownUpgradeBarUpdate()
    {
        level = upgradeTracker.uFiringSpeed + 1;
        cooldownUpgradeBar.value = level / 3;
    }

    private void Update()
    {
        CooldownUpgradeBarUpdate();
    }

    // For Tooltip
    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.ShowStatic("Firing Rate Upgrade");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideStatic();
    }
}
