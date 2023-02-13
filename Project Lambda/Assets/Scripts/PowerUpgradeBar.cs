using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpgradeBar : MonoBehaviour
{

    Slider powerBar;
    float level = 1;
    UpgradeTracker upgradeTracker;
    // Start is called before the first frame update
    void Start()
    {
        powerBar = GetComponent<Slider>();
        powerBar.value = level / 3;
        upgradeTracker = GameObject.FindGameObjectWithTag("Player").GetComponent<UpgradeTracker>();
    }

    // Update is called once per frame
    public void PowerUpgradeBarUpdate()
    {
        level = upgradeTracker.uBitPower + 1;
        powerBar.value = level / 3;
    }
}
