using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MoveRooms : MonoBehaviour
{
    public String level;
    public Vector3 new_pos;
    public BoxCollider2D col;
    public SpriteRenderer m_SpriteRenderer;
    public Player player;
    Scene scene;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
        col.isTrigger = false;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = Color.red;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        scene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        //comment this in when we want to guide players to certain routes in the base scene
        /*if (scene.name == "Base")
        {
            int which_level = 0;
            if (level != "Boss4Room")
            {
                which_level = int.Parse(level.Substring(level.Length - 6, 1));
            }
            else
            {
                which_level = int.Parse(level.Substring(level.Length - 5, 1));
            }

            if (which_level <= player.Current_level)
            {
                col.isTrigger = true;
                m_SpriteRenderer.color = Color.green;
            }
        }
        else
        {*/
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                //turn it back on when all the enemies in the room are dead --> green hue
                if (level != "Base")
                {
                    //gives access to the boss rooms after killing all enemies in the route scene
                    col.isTrigger = true;
                    m_SpriteRenderer.color = Color.green;
                }

                if ((player.Boss_one_complete && scene.name == "Boss1Route") ||
                    (player.Boss_two_complete && scene.name == "Boss2Route") ||
                    (player.Boss_three_complete && scene.name == "Boss3Route") ||
                    (player.Boss_four_complete))
                {
                    col.isTrigger = true;
                    m_SpriteRenderer.color = Color.green;
                }
                if (scene.name != "Base")
                {
                    Boolean if_boss_room = scene.name.Substring(scene.name.Length - 4) == "Room";
                    if (if_boss_room)
                    {
                        int which_boss = int.Parse(scene.name.Substring(scene.name.Length - 5, 1));
                        if (which_boss == 1)
                        {
                            player.Boss_one_complete = true;
                        }
                        else if (which_boss == 2)
                        {
                            player.Boss_two_complete = true;
                        }
                        else if (which_boss == 3)
                        {
                            player.Boss_three_complete = true;
                        }
                        else
                        {
                            player.Boss_four_complete = true;
                        }
                        player.Current_level++;
                    }
                }
            }
       // }

        
    }

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