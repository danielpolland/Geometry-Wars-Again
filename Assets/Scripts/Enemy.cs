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


    // Update is called once per frame
    void Update()
    {
        if (shouldavoidatcloserange)
        {
            if (Vector2.Distance(player.transform.position, transform.position) <= avoidanceDistance)
            { direction *= -1; }
        }

        transform.up = (transform.position - player.transform.position).normalized;
    }

    private void FixedUpdate()
    {
        body.velocity = transform.forward * movementspeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            
          Bullet b = collision.gameObject.GetComponent<Bullet>();
            enemyhealth.health -= b.bulletdamage;
            Destroy(b);
        }

       
    }
}
