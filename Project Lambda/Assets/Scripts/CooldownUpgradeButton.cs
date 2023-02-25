using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUpgradeButton : MonoBehaviour
{
    public Button button;
    public UpgradeTracker upgradeTracker;
    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        img = GetComponent<Image>();
        upgradeTracker = FindObjectOfType<Player>().GetComponent<UpgradeTracker>();
        button.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {
        if (upgradeTracker.exp >= upgradeTracker.expToUpgrade)
        {
            img.enabled = true;
        }
        else
        {
            img.enabled = false;
        }
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        upgradeTracker.TryToUpgradeFiringSpeed();
    }
}
