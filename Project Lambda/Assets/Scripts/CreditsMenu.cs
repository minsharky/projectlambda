using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditsMenu : MonoBehaviour
{
    UpgradeTracker upgradeTracker;
    private void Start()
    {
        upgradeTracker = GetComponent<UpgradeTracker>();
    }
    public void RestartGame()
    {
        upgradeTracker.exp = 0f;
        upgradeTracker.uBitPower = 0;
        upgradeTracker.uFiringSpeed = 0;
        upgradeTracker.uHealth = 0;
        upgradeTracker.uArmor = 0;
        upgradeTracker.uRegenSpeed = 0;
        upgradeTracker.uPlayerSpeed = 0;
        SceneManager.LoadScene("Base");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
