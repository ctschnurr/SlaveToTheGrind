using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : Obstacle
{
    protected enum State
    {
        idle,
        hit
    }

    protected State state;

    protected float delayA = 2;
    protected float delayB = 0f;
    protected float delayBreset = 0.15f;
    protected int flashCount = 7;

    protected SpriteRenderer cone;

    void Awake()
    {
        gameObject.name = "Cone";
        gameObject.tag = "Obstacle";
        rb = gameObject.GetComponent<Rigidbody2D>();
        cone = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void HitMe(GameObject car)
    {
        Vector3 direction = transform.position - car.transform.position;
        rb.AddForce(direction * 5, ForceMode2D.Impulse);
        state = State.hit;
    }

    private void Update()
    {
        switch (state)
        {
            case State.idle:

                break;

            case State.hit:
                delayA -= Time.deltaTime;
                if(delayA <= 0)
                {
                    delayB -= Time.deltaTime;
                    if (delayB <= 0 && flashCount > 0)
                    {
                        if (cone.enabled) cone.enabled = false;
                        else cone.enabled = true;

                        delayB = delayBreset;
                        flashCount--;
                    }

                    if (flashCount <= 0) Destroy(gameObject);
                }
                break;
        }
    }
}
