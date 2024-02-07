using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementspeed = 10;
    public int enemydamage = 1;
    public bool shouldavoidatcloserange = false;
    public float avoidanceDistance = 5;

    public Rigidbody2D body;
    Vector2 direction;
    public GameObject player;
    
    public ObjectHealth enemyhealth;

    //start method used to ensure enemies follow player
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    //update ensures enemies constantly follow player
    void Update()
    {
        transform.up = (player.transform.position - transform.position).normalized;

        direction = transform.up;

        if (shouldavoidatcloserange)
        {
            if (Vector2.Distance(player.transform.position, transform.position) <= avoidanceDistance)
            { direction *= -1; }
        }

       
    }

    private void FixedUpdate()
    {
        body.velocity = direction*movementspeed;
    }

    //ensures enemies are removed once they run out of health
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            
          Bullet b = collision.gameObject.GetComponent<Bullet>();
            enemyhealth.health -= b.bulletdamage;
            Destroy(b.gameObject);
            if (enemyhealth.health <= 0) {Destroy(gameObject); }
        }


       
    }
}
