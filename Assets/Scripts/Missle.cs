using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class Missle : Weapon
{
    // Start is called before the first frame update
    public GameObject explosion;
    public float speed = missleSpeed;
    Vector3 forward;
    void Awake()
    {
        gameObject.name = "Missle";
        rb = gameObject.GetComponent<Rigidbody2D>();
        forward = transform.forward;
        forward.y = 1;
        owner = transform.parent.GetComponent<Racer>();
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
    }
}
