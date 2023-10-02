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
        dead,
        finished
    }

    public enum Weapon_State
    {
        bullet,
        missle,
        mine
    }

    public enum RacerType
    {
        player,
        enemy
    }

    public RacerType type;

    public GameObject bullet;
    protected float bulletTimer;
    protected float bulletTimerReset = .5f;
    protected bool canFireBullet = true;
    protected int bulletAmmo = 99;

    public GameObject missle;
    protected float missleTimer;
    protected float missleTimerReset = 1.5f;
    protected bool canFireMissile = true;
    protected int missleAmmo = 10;

    public GameObject mine;
    protected float mineTimer;
    protected float mineTimerReset = 1f;
    protected bool canDropMine = true;
    protected int mineAmmo = 10;

    public GameObject firePos;
    public GameObject dropPos;


    // damage blink
    protected float damageBlinkTimer = 0f;
    protected float damageBlinkTimerReset = 0.15f;

    protected float oilSlickTimer;
    protected float oilSlickTimerReset;

    protected int flashCount = 7;
    protected int maxHealth;
    protected int health;
    protected string racerName;

    protected Racer defeatedBy;

    protected float boost = 0f;
    protected float boostReset = 1000f;
    protected float boostDelay = 1f;
    protected float boostDelayReset = 0.15f;
    protected bool boosted = false;

    public Effect effect = Effect.idle;

    protected SpriteRenderer racer;
    protected Rigidbody2D rb;

    protected float speed;
    protected float turnSpeed;
    protected float speedMax;

    protected bool oilSlicked = false;

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
                boost -= boost * Time.deltaTime;
                if (boost <= 10)
                {
                    boosted = false;
                    boostDelay = boostDelayReset;
                    boost = 0;
                }
            }
            else boostDelay -= Time.deltaTime;
        }

        if (!canFireBullet)
        {
            bulletTimer -= Time.deltaTime;
            if (bulletTimer <= 0)
            {
                bulletTimer = 0;
                canFireBullet = true;
            }
        }

        if (!canFireMissile)
        {
            missleTimer -= Time.deltaTime;
            if (missleTimer <= 0)
            {
                missleTimer = 0;
                canFireMissile = true;
            }
        }

        if (!canDropMine)
        {
            mineTimer -= Time.deltaTime;
            if (mineTimer <= 0)
            {
                mineTimer = 0;
                canDropMine = true;
            }
        }

        if (type == RacerType.player)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                boosted = true;
                boost = boostReset;
            }

            if (Input.GetKeyDown(KeyCode.Space)) Fire(Weapon_State.bullet);
            if (Input.GetKeyDown(KeyCode.F)) Fire(Weapon_State.missle);
            if (Input.GetKeyDown(KeyCode.E)) Fire(Weapon_State.mine);
        }
    }

    protected void Fire(Weapon_State input)
    {
        switch (input)
        {
            case Weapon_State.bullet:
                if (canFireBullet && bulletAmmo > 0)
                {
                    Instantiate(bullet, firePos.transform.position, transform.localRotation, transform);
                    bulletAmmo--;
                    canFireBullet = false;
                    bulletTimer = bulletTimerReset;
                }
                break;

            case Weapon_State.missle:
                if (canFireMissile && missleAmmo > 0)
                {
                    Instantiate(missle, firePos.transform.position, transform.localRotation, transform);
                    missleAmmo--;
                    canFireMissile = false;
                    missleTimer = missleTimerReset;
                }
                break;

            case Weapon_State.mine:
                if (canDropMine && mineAmmo > 0)
                {
                    Instantiate(mine, dropPos.transform.position, transform.localRotation, transform);
                    mineAmmo--;
                    canDropMine = false;
                    mineTimer = mineTimerReset;
                }
                break;
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(effect != Effect.damaged && effect != Effect.finished)
        {
            if (collision.gameObject.tag == "Weapon")
            {
                switch (collision.gameObject.name)
                {
                    case "Bullet":
                        defeatedBy = collision.gameObject.GetComponent<Weapon>().owner;
                        effect = Effect.damaged;
                        TakeHealth(2);
                        break;
                }
            }

            if (collision.gameObject.tag == "Racer")
            {
                defeatedBy = collision.gameObject.GetComponent<Racer>();
                effect = Effect.damaged;
                TakeHealth(10);
            }

            if (collision.gameObject.tag == "Wall")
            {
                effect = Effect.damaged;
                TakeHealth(5);
            }

            if (collision.gameObject.tag == "Explosion")
            {
                if(collision.gameObject.GetComponent<Weapon>().owner != null) defeatedBy = collision.gameObject.GetComponentInParent<Racer>();
                Vector3 direction = transform.position - collision.gameObject.transform.position;
                rb.AddForce(direction * 50, ForceMode2D.Impulse);
                effect = Effect.damaged;
                TakeHealth(15);
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
            if(defeatedBy != null) Debug.Log(name + " was defeated by " + defeatedBy.name);
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
