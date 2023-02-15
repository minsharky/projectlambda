using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeedUpgradeBar : MonoBehaviour
{
    // Slider
    Slider speedBar;
    UpgradeTracker upgradeTracker;
    float level = 1;

    // Start is called before the first frame update
    void Start()
    {
        speedBar = GetComponent<Slider>();
        speedBar.value = (float) level / 3;
        upgradeTracker = GameObject.FindGameObjectWithTag("Player").GetComponent<UpgradeTracker>();
    }

    // Update is called once per frame
    public void SpeedBarUpdate()
    {
        level = upgradeTracker.uPlayerSpeed+1;
        speedBar.value = (float) level / 3;
    }

    private void Update()
    {
        SpeedBarUpdate();
    }
}
