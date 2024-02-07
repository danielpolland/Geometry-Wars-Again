using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementspeed = 10;
    public Bullet BulletPrefab;

    float horizontal, vertical;
    public Rigidbody2D body;
    Vector3 mouseposition;
   public ObjectHealth playerhealth;

    void Start()
    {
        GetComponent<Rigidbody2D>();
        GetComponent<ObjectHealth>();
    }

   //ensures player is able to aim in different directions
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseposition.z = 0;
        transform.up = (mouseposition - transform.position).normalized;
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal,vertical)*movementspeed;
    }

    void shoot()
    {
        Bullet BulletInstance = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        BulletInstance.SetDirection(transform.up);
    }
    //ensures enemies are removed upon contact with player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           Enemy e = collision.gameObject.GetComponent<Enemy>();
            playerhealth.health -= e.enemydamage;
            Destroy(e.gameObject);

        }
    }
}
