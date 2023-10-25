using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using TMPro;
using static Globals;

public class Racer : MonoBehaviour
{
    public enum State
    {
        idle,
        dead,
        finished
    }

    private State _racerState = State.idle;
    public State RacerState { get; set; }

    public enum RacerType
    {
        player,
        enemy
    }
    
    protected RacerType type;

    public enum Weapon_Select
    {
        bullet,
        missle,
        mine
    }
    // Upgradables

    protected int engineUpgradeLevel = 0;
    protected int armourUpgradeLevel = 0;

    protected int repairSkill = 1;
    // Racer stats

    protected string racerName;
    protected int health;
    protected int maxHealth;
    protected int totalMoney;

    protected Vector3 startPosition;
    protected Quaternion startRotation;
    protected SpriteRenderer racer;
    protected Rigidbody2D rb;
    protected GameObject spriteCanvas;
    protected Slider healthBar;
    protected TextMeshProUGUI spriteName;

    static protected List<Racer> defeated = new List<Racer>();
    protected int moneyThisRound;

    public float finishLine;
    protected float speed;
    protected float turnSpeed;
    protected float speedMax;

    // Weapon and ability related variables:

    public GameObject firePos;
    public GameObject dropPos;

    public GameObject bullet;
    protected float bulletTimer;
    protected float bulletTimerReset = .5f;
    protected bool canFireBullet = true;
    protected int bulletAmmo = 99;
    protected int bulletAmmoMax = 99;

    public GameObject missle;
    protected float missleTimer;
    protected float missleTimerReset = 1.5f;
    protected bool canFireMissile = true;
    protected int missleAmmo = 10;
    protected int missleAmmoMax = 10;

    public GameObject mine;
    protected float mineTimer;
    protected float mineTimerReset = 1f;
    protected bool canDropMine = true;
    protected int mineAmmo = 10;
    protected int mineAmmoMax = 10;

    protected bool damaged = false;
    protected float damageBlinkTimer = 0f;
    protected float damageBlinkTimerReset = 0.15f;
    protected int flashCount = 7;

    protected bool oilSlicked = false;
    protected float oilSlickTimer;
    protected float oilSlickTimerReset;

    protected bool boosted = false;
    protected float boost = 0f;
    protected float boostReset = 1000f;
    protected float boostDelay = 0.15f;
    protected float boostDelayReset = 0.15f;
    protected float boostTimer;
    protected float boostTimerReset = 5f;
    protected bool canBoost = true;
    protected bool boostRecharge = false;

    public delegate void FinishedAction(Racer racer);
    public static event FinishedAction OnFinished;



    protected List<string> enemyNames = new List<string> {"Rattigan", "Ratley", "Ratmore", "Ratty", "Ratman", "RatWoman", "Ratsputin"};
    // Start is called before the first frame update

    public void Start()
    {

    }
    public virtual void ResetRacer()
    {
        rb.velocity = Vector3.zero;
        if (!racer.enabled) racer.enabled = true;
        transform.position = startPosition;
        transform.rotation = startRotation;
        RacerState = State.idle;
        health = maxHealth;
        moneyThisRound = 0;
        if(defeated != null) defeated.Clear();

        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (transform.position.y >= finishLine && RacerState != State.finished)
        {
            RacerState = State.finished;
            Finished();
        }

        switch (RacerState)
        {
            case State.idle:

                break;

            case State.dead:
                damageBlinkTimer -= Time.deltaTime;
                if (damageBlinkTimer <= 0)
                {
                    if (racer.enabled) racer.enabled = false;
                    else racer.enabled = true;

                    damageBlinkTimer = damageBlinkTimerReset;
                }
                break;
        }

        if (damaged)
        {
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
                damaged = false;
                flashCount = 7;
            }
        }

        if(oilSlicked)
        {
            oilSlickTimer -= Time.deltaTime;
            if (oilSlickTimer <= 0)
            {
                OilSlicked();
                oilSlickTimer = 0;
            }
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
                    boostTimer = boostTimerReset;
                    boostRecharge = true;
                }
            }
            else boostDelay -= Time.deltaTime;
        }

        if (boostRecharge)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer <= 0)
            {
                boostTimer = 0;
                canBoost = true;
                boostRecharge = false;
            }
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
    }

    protected void Fire(Weapon_Select input)
    {
        switch (input)
        {
            case Weapon_Select.bullet:
                if (canFireBullet && bulletAmmo > 0)
                {
                    Instantiate(bullet, firePos.transform.position, transform.localRotation, transform);
                    bulletAmmo--;
                    canFireBullet = false;
                    bulletTimer = bulletTimerReset;
                }
                break;

            case Weapon_Select.missle:
                if (canFireMissile && missleAmmo > 0)
                {
                    Instantiate(missle, firePos.transform.position, transform.localRotation, transform);
                    missleAmmo--;
                    canFireMissile = false;
                    missleTimer = missleTimerReset;
                }
                break;

            case Weapon_Select.mine:
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
        Weapon weapon = collision.gameObject.GetComponent<Weapon>();
        if(!damaged && RacerState != State.finished)
        {
            if (weapon != null && weapon.owner != null && weapon.owner != this)
            {
                if (collision.gameObject.tag == "Weapon")
                {
                    switch (collision.gameObject.name)
                    {
                        case "Bullet":
                            damaged = true;
                            TakeHealth(5, collision);
                            break;
                    }
                }
            }

            if (collision.gameObject.tag == "Racer")
            {
                Vector3 direction = transform.position - collision.gameObject.transform.position;
                rb.AddForce(direction * 5, ForceMode2D.Impulse);

                damaged = true;
                TakeHealth(2, collision);
            }

            if (collision.gameObject.tag == "Wall")
            {
                damaged = true;
                TakeHealth(2, collision);
            }

            if (collision.gameObject.tag == "Explosion")
            {
                Vector3 direction = transform.position - collision.gameObject.transform.position;
                rb.AddForce(direction * 20, ForceMode2D.Impulse);
                damaged = true;
                TakeHealth(15, collision);
            }
        }
    }

    protected virtual void TakeHealth(int damage, Collision2D collision)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            RacerState = State.dead;
            Racer defeatedBy = null;
            if (collision.gameObject.tag == "Weapon") defeatedBy = collision.gameObject.GetComponent<Weapon>().owner;
            if(defeatedBy != null)
            {
                if (defeatedBy.type == RacerType.player && defeatedBy != this)
                {
                    defeated.Add(this);
                }
            }
        }
    }

    public void AddHealth(int value)
    {
        float tempConvert = (float)value;
        tempConvert *= repairSkill;
        int amountToRepair = (int)tempConvert;
        health += amountToRepair;
        if (health > maxHealth) health = maxHealth;
    }

    public void AddMoney(int value)
    {
        moneyThisRound += value;
    }

    public int GetEarnings()
    {
        return moneyThisRound;
    }

    public void OilSlicked()
    {
        if(!oilSlicked)
        {
            speed = speed * oilSlickPenalty;
            oilSlicked = true;
            oilSlickTimer = oilSlickDelay;
            oilSlicked = true;
        }
        else
        {
            speed = speedMax;
            oilSlicked = false;
        }
    }

    public string GetName()
    {
        return racerName;
    }

    // public State GetState()
    // {
    //     return state;
    // }

    public RacerType GetRacerType()
    {
        return type;
    }
    public virtual void SetupRacer()
    {
        spriteCanvas = transform.Find("Canvas").gameObject;
        healthBar = transform.Find("Canvas/HealthBar").GetComponent<Slider>();
        spriteName = transform.Find("Canvas/SpriteName").GetComponent<TextMeshProUGUI>();

        startPosition = transform.position;
        startRotation = transform.rotation;

        rb = transform.GetComponent<Rigidbody2D>();
        racer = transform.Find("RacerSprite").GetComponent<SpriteRenderer>();

        speedMax = baseSpeed + (baseSpeed * (engineUpgradeLevel * 0.15f));
        speed = speedMax;
        turnSpeed = baseTurnSpeed;

        finishLine = TrackManager.GetFinishline();
    }

    public void Finished()
    {
        if (OnFinished != null)
        {
            OnFinished(this);
        }
    }
    public int GetCurrentRaceEarnings()
    {
        return moneyThisRound;
    }

    public List<Racer> GetDefeated()
    {
        return defeated;
    }

    public void PayRacer(int earnings)
    {
        totalMoney += earnings;
    }
}
