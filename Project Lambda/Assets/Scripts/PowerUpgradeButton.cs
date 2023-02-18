using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpgradeButton : MonoBehaviour
{
    public Button button;
    public UpgradeTracker upgradeTracker;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        upgradeTracker = FindObjectOfType<Player>().GetComponent<UpgradeTracker>();
        button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        upgradeTracker.TryToUpgradePower();
    }
}
