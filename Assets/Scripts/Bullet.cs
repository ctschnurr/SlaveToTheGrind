using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class Bullet : Weapon
{
    // Start is called before the first frame update
    Behavior behavior = Behavior.bullet;
    protected float speed = baseSpeed * 25;
    Vector3 forward;
    void Start()
    {
        gameObject.name = "Bullet";
        speed *= Time.deltaTime;
        rb = gameObject.GetComponent<Rigidbody2D>();
        forward = transform.forward;
        forward.y = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.up * speed, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
