using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUpgradeBar : MonoBehaviour
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

    // Update is called once per frame
    public void CooldownUpgradeBarUpdate()
    {
        level = upgradeTracker.uFiringSpeed + 1;
        cooldownUpgradeBar.value = level / 3;
    }
}
