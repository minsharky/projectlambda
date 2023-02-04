using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rigidBody;
    public float bossSpeed;
    public float hitPoints;
    public GameObject BulletPrefab;
    public float timeBullet;
    public float constant;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        rigidBody = GetComponent<Rigidbody2D>();
        bossSpeed = 1;
        hitPoints = 100;
        timeBullet = Time.time + 3f;
        constant = 1;
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = bossSpeed * (player.position - transform.position).normalized;

        //Boss shoots bullets every 2 seconds
        if (Time.time > timeBullet)
        {
            shoot();
            timeBullet += 2f;
            if (hitPoints <= 90)
            {
                //Phase 2
                //TODO: Make triple bullets actually come out in a triple shot
                constant = -1.001f;
                shoot();
                constant = 1.001f;
                shoot();
                bossSpeed = 2.5f;
            }
        }

        //When Boss's hp gets to zero, it dies
        if (hitPoints <= 0) {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<PlayerBullet>()) {
            hitPoints -= 2;
        }
    }

    //shoots as bullet in the direction of the player
    void shoot()
    {
        Vector3 newPos;

        //how far the enemy is to the right of the player
        float xVal = FindObjectOfType<Player>().transform.position.x - transform.position.x;
        //how far the enemy is above the player
        float yVal = FindObjectOfType<Player>().transform.position.y - transform.position.y;

        //if xVal >= 0, enemy is to the right of the player
        //if yVal >= 0, enemy is above of the player
        if (xVal >= 0 && yVal >= 0){
            if (xVal > yVal){
                newPos = Vector3.right;
            }
            else {
                newPos = Vector3.up;
            }
        }
        //enemy is to the left of the player
        //enemy is below the player
        else
        {
            if (xVal < yVal){
                newPos = Vector3.left;
            }
            else{
                newPos = Vector3.down;
            }
        }

        GameObject newBullet = Instantiate(BulletPrefab, transform.localPosition + newPos * 2f * constant, Quaternion.identity);
        Rigidbody2D bulletRigidBody = newBullet.GetComponent<Rigidbody2D>();
        bulletRigidBody.velocity = 10f * (FindObjectOfType<Player>().transform.position - transform.position).normalized;
    }
}
