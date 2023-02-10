using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Player movement
Space Bar: Shoot bullet
AWSD/UpDown : Move
Mouse: Aim*/

public class PlayerMovement : MonoBehaviour
{
    UpgradeTracker upgrades;

    // Move constant
    float moveSpeed = 0.01f;
    float baseVal = 0.01f;

    public float RotateSpeed = 1f;

    // Start
    void Start()
    {
        upgrades = GetComponent<UpgradeTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        // Left Arrow or "A"
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // Move the Player to the left
            transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y);
        }

        // Right Arrow or "D"
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // Move the Player to the right
            transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y);
        }

        // Up Arrow or "W"
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            // Move the Player to the up
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed);
        }

        // Down Arrow or "S"
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            // Move the Player to the down
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed);
        }

        //aims player to mouse position
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void UpdateMoveSpeed()
    {
        moveSpeed = baseVal * (upgrades.uPlayerSpeed + 1);
    }
}
