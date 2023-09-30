using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static Globals;

public class Racer : MonoBehaviour
{
    public enum Effect
    {
        idle,
        damaged,
        oilSlick,
        dead
    }

    // damage blink
    protected float damageBlinkTimer = 0f;
    protected float damageBlinkTimerReset = 0.15f;

    protected float oilSlickTimer;
    protected float oilSlickTimerReset;

    protected int flashCount = 7;
    protected int maxHealth;
    protected int health;

    protected float boost = 0f;
    float boostReset = 50f;
    float boostDelay = 0.15f;
    float boostDelayReset = 0.15f;
    bool boosted = false;

    public Effect effect = Effect.idle;

    protected SpriteRenderer racer;
    protected Rigidbody2D rb;

    public float speed;
    protected float turnSpeed;
    public float speedMax;

    public bool oilSlicked = false;
    protected bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (effect)
        {
            case Effect.idle:

                break;

            case Effect.damaged:
                damageBlinkTimer -= Time.deltaTime;
                if (damageBlinkTimer <= 0 && flashCount > 0)
                {
                    if (racer.enabled) racer.enabled = false;
                    else racer.enabled = true;

                    damageBlinkTimer = damageBlinkTimerReset;
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
                oilSlickTimer -= Time.deltaTime;
                if (oilSlickTimer <= 0)
                {
                    OilSlicked();
                    oilSlickTimer = 0;
                }
                break;

            case Effect.dead:
                damageBlinkTimer -= Time.deltaTime;
                if (damageBlinkTimer <= 0)
                {
                    if (racer.enabled) racer.enabled = false;
                    else racer.enabled = true;

                    damageBlinkTimer = damageBlinkTimerReset;
                }
                break;
        }

        if (boosted)
        {
            if (boostDelay <= 0)
            {
                boost -= 0.1f;
                if (boost <= 0)
                {
                    boosted = false;
                    boostDelay = boostDelayReset;
                    boost = 0;
                }
            }
            else boostDelay -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            boosted = true;
            boost = boostReset;
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(effect != Effect.damaged)
        {
            if (collision.gameObject.tag == "Obstacle")
            {
                switch (collision.gameObject.name)
                {
                    case "Cone":

                        break;

                    case "Burning Barrel":

                        break;
                }

            }

            if (collision.gameObject.tag == "Racer")
            {
                effect = Effect.damaged;
                TakeHealth(5);
            }

            if (collision.gameObject.tag == "Wall")
            {
                effect = Effect.damaged;
                TakeHealth(2);
            }

            if (collision.gameObject.tag == "Explosion")
            {
                Vector3 direction = transform.position - collision.gameObject.transform.position;
                rb.AddForce(direction * 50, ForceMode2D.Impulse);
                effect = Effect.damaged;
                TakeHealth(10);
            }
        }
    }

    protected void TakeHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            effect = Effect.dead;
            dead = true;
        }
    }

    public void OilSlicked()
    {
        if(!oilSlicked)
        {
            speed = speed * oilSlickPenalty;
            effect = Effect.oilSlick;
            oilSlickTimer = oilSlickDelay;
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
