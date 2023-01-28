using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Player movement
Space Bar: Shoot bullet
AWSD/UpDown : Move
Mouse: Aim*/


public class PlayerMovement : MonoBehaviour
{
    // Move constant
    float moveConstant = 0.025f;

    public float RotateSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        // Left Arrow or "A"
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // Move the Player to the left
            //transform.Translate(Vector3.left * moveConstant);
            transform.position = new Vector3(transform.position.x - moveConstant, transform.position.y);
        }

        // Right Arrow
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // Move the Player to the right
            //transform.Translate(Vector3.right * moveConstant);
            transform.position = new Vector3(transform.position.x + moveConstant, transform.position.y);
        }

        // Up Arrow
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            // Move the Player to the up
            //transform.Translate(Vector3.up * moveConstant);
            transform.position = new Vector3(transform.position.x, transform.position.y + moveConstant);
        }

        // Down Arrow
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            // Move the Player to the down
            //transform.Translate(Vector3.down * moveConstant);
            transform.position = new Vector3(transform.position.x, transform.position.y - moveConstant);
        }

        //aims player to mouse position
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
