using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour

    //Space bar: shoot bullet
    //Mouse: gun aim
{

    public GameObject BulletPrefab;

    /// <summary>
    /// How powerful our bullets are at the beginning of game. Used to calculate actualBulletPower with upgrades.
    /// </summary>
    public float baseBulletPower = 0.5f;

    /// <summary>
    /// How powerful our bullets are at a given moment
    /// </summary>
    public float actualBulletPower = 0.5f;

    /// <summary>
    /// How fast we should shoot our bullets
    /// </summary>
    public float BulletVelocity = 30;

    //How long before a player can shoot again
    public float fireRate = 0.5f;

    //cooldown countdown
    public float shootCoolDown = -1f;

    // UpgradeTracker
    UpgradeTracker upgrades;

    // Start
    void Start()
    {
        upgrades = GetComponent<UpgradeTracker>();
    }


    // Update is called once per frame
    void Update()
    { 
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && Time.time > shootCoolDown) {
            shootCoolDown = Time.time + fireRate;
            shootBullet();
        }
    }

    void shootBullet() {
        GameObject newBullet = Instantiate(BulletPrefab, transform.right * 1.1f + transform.localPosition, Quaternion.identity);
        Rigidbody2D bulletRigidBody = newBullet.GetComponent<Rigidbody2D>();
        bulletRigidBody.velocity = BulletVelocity * transform.right;
    }

    public void UpdateBitPower()
    {
        actualBulletPower = baseBulletPower + 0.25f * (upgrades.uBitPower);
    }

    public void UpdateFiringSpeed()
    {
        fireRate = 0.5f * (1 / (1 + 0.5f*upgrades.uFiringSpeed));
    }
}
