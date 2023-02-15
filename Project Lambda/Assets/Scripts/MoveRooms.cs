using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveRooms : MonoBehaviour
{
    public String level;
    public Vector3 new_pos;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            //Here it would use the "level" variable to load the next scene
            SceneManager.LoadScene(level);
            
            DontDestroyOnLoad(coll.gameObject);
            coll.transform.position = new_pos;
        }
    }
}