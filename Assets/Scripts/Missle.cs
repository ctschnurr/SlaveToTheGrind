using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class Missle : Weapon
{
    // Start is called before the first frame update
    public GameObject explosion;
    public float speed = missleSpeed;
    void Awake()
    {
        gameObject.name = "Missle";
        rb = gameObject.GetComponent<Rigidbody2D>();
        owner = transform.parent.GetComponent<Racer>();
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>());
        transform.parent = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform != owner.transform)
        {
            Instantiate(explosion, transform.position, transform.rotation, owner.transform);
            Destroy(gameObject);
        }

        if (transform.position.y > 600) Destroy(gameObject);
    }
}
