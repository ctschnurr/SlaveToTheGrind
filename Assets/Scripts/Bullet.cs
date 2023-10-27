using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class Bullet : Weapon
{
    // Start is called before the first frame update
    protected float speed = bulletSpeed;
    Vector3 forward;
    void Start()
    {
        gameObject.name = "Bullet";
        rb = gameObject.GetComponent<Rigidbody2D>();
        //forward = transform.forward;
        //forward.y = 1;
        owner = transform.parent.GetComponent<Racer>();
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>());
        transform.parent = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * speed * Time.deltaTime, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
