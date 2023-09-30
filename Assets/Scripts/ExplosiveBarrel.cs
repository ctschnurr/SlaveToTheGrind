using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ExplosiveBarrel : Obstacle
{
    // Start is called before the first frame update
    public GameObject explosion;
    Vector3 startPos;
    protected SpriteRenderer barrel;

    CircleCollider2D circleCollider;

    void Start()
    {
        
    }

    void Awake()
    {
        gameObject.name = "ExplosiveBarrel";
        gameObject.tag = "Obstacle";
        rb = gameObject.GetComponent<Rigidbody2D>();
        barrel = gameObject.GetComponent<SpriteRenderer>();

        startPos = gameObject.transform.position;
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void HitMe(GameObject car, float force)
    {
        Vector3 direction = transform.position - car.transform.position;
        rb.AddForce(direction * (force * 6), ForceMode2D.Impulse);
        //car.GetComponent<Rigidbody2D>().AddForce(-direction * (force * 10), ForceMode2D.Impulse);

        barrel.enabled = false;
        circleCollider.enabled = false;
        Instantiate(explosion, startPos, transform.rotation);
        Destroy(gameObject);
    }
}
