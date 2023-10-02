using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Mine : Weapon
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        gameObject.name = "Mine";
        gameObject.tag = "Weapon";
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform != transform.parent)
        {
            Instantiate(explosion, transform.position, transform.rotation, transform.parent);
            Destroy(gameObject);
        }
    }
}
