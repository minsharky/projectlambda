using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

/*Player movement
Space Bar: Shoot bullet
AWSD/UpDown : Move
Mouse: Aim*/

public class PlayerMovement : MonoBehaviour
{
    UpgradeTracker upgrades;
    Rigidbody2D rb;

    // Move constant
    float moveSpeed = 8f;
    float baseVal = 8f;

    public float RotateSpeed = 1f;

    // Start
    void Start()
    {
        upgrades = GetComponent<UpgradeTracker>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        float divisor = 1;
        if (xMove != 0 && yMove != 0)
        {
            divisor = (float) Sqrt(2);
        }
        rb.velocity = new Vector3(xMove, yMove) * moveSpeed / divisor;

        //aims player to mouse position
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void UpdateMoveSpeed()
    {
        moveSpeed = baseVal + (1.5f * upgrades.uPlayerSpeed);
    }
}



