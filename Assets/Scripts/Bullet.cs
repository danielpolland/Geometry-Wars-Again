using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public float bulletdamage = 50;
    public Rigidbody2D body;


    public void SetDirection(Vector2 direction)
    {
         
        body.velocity = direction.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }

}
