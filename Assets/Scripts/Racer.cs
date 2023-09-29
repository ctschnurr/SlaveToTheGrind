using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static Constants;

public class Racer : MonoBehaviour
{
    protected enum Effect
    {
        idle,
        damaged,
        oilSlick
    }

    // damage blink
    protected float delayA = 2;
    protected float delayB = 0f;
    protected float delayBreset = 0.15f;
    protected int flashCount = 7;

    protected Effect effect = Effect.idle;

    protected SpriteRenderer racer;
    protected Rigidbody2D rb;

    protected float speed = 10f;
    protected float speedMax = 10f;

    protected bool oilSlicked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (effect)
        {
            case Effect.idle:

                break;

            case Effect.damaged:
                delayB -= Time.deltaTime;
                if (delayB <= 0 && flashCount > 0)
                {
                    if (racer.enabled) racer.enabled = false;
                    else racer.enabled = true;

                    delayB = delayBreset;
                    flashCount--;
                }
                if (flashCount <= 0)
                {
                    if (!racer.enabled) racer.enabled = true;
                    effect = Effect.idle;
                    flashCount = 7;
                }
                break;

            case Effect.oilSlick:
                delayB -= Time.deltaTime;
                if(delayB <= 0)
                {

                }
                break;
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            switch (collision.gameObject.name)
            {
                case "Cone":
                    effect = Effect.damaged;
                    break;

                case "Burning Barrel":

                    break;
            }

        }

        if (collision.gameObject.tag == "Racer")
        {

        }
    }

    public void OilSlicked()
    {
        if(!oilSlicked)
        {
            speed = speed * oilSlickPenalty;
            effect = Effect.oilSlick;
            delayB = oilSlickDelay;
            oilSlicked = true;
        }
        else
        {
            speed = speedMax;
            effect = Effect.idle;
            oilSlicked = false;
        }
    }
}
