using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ExplosiveBarrel : Obstacle
{
    // Start is called before the first frame update
    public GameObject explosion;

    protected SpriteRenderer barrel;

    CircleCollider2D circleCollider;

    private Vector3 startPos;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void HitMe(GameObject car)
    {
        Vector3 direction = transform.position - car.transform.position;
        rb.AddForce(direction * 5, ForceMode2D.Impulse);

        Instantiate(explosion, startPos, transform.rotation);
        Destroy(gameObject);
    }
}
