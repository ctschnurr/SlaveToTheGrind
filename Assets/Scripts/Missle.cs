using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class Missle : Weapon
{
    // Start is called before the first frame update
    public GameObject explosion;
    Behavior behavior = Behavior.missle;
    protected float speed = baseSpeed * 15;
    Vector3 forward;
    void Start()
    {
        gameObject.name = "Missle";
        speed *= Time.deltaTime;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.up * speed, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
