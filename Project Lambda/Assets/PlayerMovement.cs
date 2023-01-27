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

    // Update is called once per frame
    void Update()
    {
        // Left Arrow
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Move the Player to the left
            transform.Translate(Vector3.left * moveConstant);
        }

        // Right Arrow
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Move the Player to the right
            transform.Translate(Vector3.right * moveConstant);
        }

        // Up Arrow
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Move the Player to the up
            transform.Translate(Vector3.up * moveConstant);
        }

        // Down Arrow
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Move the Player to the down
            transform.Translate(Vector3.down * moveConstant);
        }
    }
}
