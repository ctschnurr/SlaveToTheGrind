using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using TMPro;
using static Globals;
using System;

public class Racer : MonoBehaviour
{
    public enum State
    {
        idle,
        dead,
        finished
    }

    public Animator animator;
    protected State _racerState = State.idle;
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
    public int EngineUpgradeLevel { get; set; }
    protected int armourUpgradeLevel = 0;
    public int ArmourUpgradeLevel { get; set; }
    protected int boostSpeedLevel = 0;
    public int BoostSpeedLevel { get; set; }
    protected int boostCooldownLevel = 0;
    public int BoostCooldownLevel { get; set; }
    protected int boostRechargeLevel = 0;
    public int BoostRechargeLevel { get; set; }

    protected int repairSkillLevel = 0;
    public int RepairSkillLevel { get; set; }

    // Racer stats

    protected string racerName;
    public string RacerName { get { return racerName; } set { racerName = value; } }
    protected Color racerColor = Color.green;
    public Color RacerColor { get { return racerColor; } set { racerColor = value; } }

    protected int health;
    protected int maxHealth;
    protected int totalMoney;
    public int TotalMoney { get { return totalMoney; } set { totalMoney = value; } }

    protected Vector3 startPosition;
    protected Quaternion startRotation;
    protected GameObject racer;
    protected SpriteRenderer carColor;
    protected Rigidbody2D rb;
    protected GameObject spriteCanvas;
    protected TextMeshProUGUI spriteName;
    protected Slider healthBar;
    protected Slider boostBar;

    static protected List<Racer> defeated = new();
    protected int moneyThisRound;

    public float finishLine;
    protected float speed;
    protected float turnSpeed;
    protected float speedMax;

    // Weapon and ability related variables:

    public GameObject bulletFirePos;
    public GameObject missleFirePos;

    public GameObject dropPos;

    public GameObject bullet;
    protected float bulletTimer = .5f;
    protected float bulletTimerReset = .5f;
    protected bool canFireBullet = true;
    protected int bulletAmmo = 99;
    protected int bulletAmmoMax = 99;

    public GameObject missle;
    protected float missleTimer = 1.5f;
    protected float missleTimerReset = 1.5f;
    protected bool canFireMissile = true;
    protected int missleAmmo = 10;
    protected int missleAmmoMax = 10;

    public GameObject mine;
    protected float mineTimer = 1f;
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

    protected bool boostActivated = false;
    protected float boost = 0;
    protected float boostMax;
    protected float boostTimer;
    protected float boostTimerReset;
    protected float boostRechargeTimer;
    protected float boostRechargeTimerReset;
    protected bool canBoost = true;
    protected bool boostRecharge = false;

    public delegate void FinishedAction(Racer racer);
    public static event FinishedAction OnFinished;

    protected bool ready = false;

    protected static List<string> enemyNames = new() { "Rattigan", "Ratley", "Ratmore", "Ratty", "Ratso", "Ratsputin", "Rattitude", "Ratical"};
    // Start is called before the first frame update

    public virtual void SetupRacer()
    {
        spriteCanvas = transform.Find("Canvas").gameObject;
        spriteName = transform.Find("Canvas/SpriteName").GetComponent<TextMeshProUGUI>();
        healthBar = transform.Find("Canvas/HealthBar").GetComponent<Slider>();
        boostBar = transform.Find("Canvas/BoostBar").GetComponent<Slider>();
        carColor = transform.Find("RacerSprite/carPaint").GetComponent<SpriteRenderer>();

        startPosition = transform.position;
        startRotation = transform.rotation;

        rb = transform.GetComponent<Rigidbody2D>();
        racer = transform.Find("RacerSprite").gameObject;

        turnSpeed = baseTurnSpeed;

        finishLine = TrackManager.GetFinishline();

        UpdateRacer();
    }

    public virtual void UpdateRacer()
    {
        speedMax = baseSpeed + (baseSpeed * (engineUpgradeLevel * 0.1f));
        speed = speedMax;

        boostMax = baseBoostSpeed + (baseBoostSpeed * (boostSpeedLevel * 0.15f));

        boostTimerReset = baseBoostCooldown - (baseBoostCooldown * (boostCooldownLevel * 0.15f));
        boostTimer = boostTimerReset;

        boostRechargeTimerReset = baseBoostRecharge - (baseBoostRecharge * (boostRechargeLevel * 0.15f));
        boostRechargeTimer = boostRechargeTimerReset;
}
    public virtual void ResetRacer()
    {
        rb.velocity = Vector3.zero;
        if (!racer.activeSelf) racer.SetActive(true);
        transform.SetPositionAndRotation(startPosition, startRotation);
        RacerState = State.idle;
        health = maxHealth;
        boost = boostMax;
        moneyThisRound = 0;
        if(defeated != null) defeated.Clear();

        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        boostBar.maxValue = boostTimerReset;
        boostBar.value = boostTimerReset;

        racer.transform.position = startPosition;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(ready)
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
                        if (racer.activeSelf) racer.SetActive(false);
                        else racer.SetActive(true);

                        damageBlinkTimer = damageBlinkTimerReset;
                    }
                    break;
            }

            if (damaged)
            {
                damageBlinkTimer -= Time.deltaTime;
                if (damageBlinkTimer <= 0 && flashCount > 0)
                {
                    if (racer.activeSelf) racer.SetActive(false);
                    else racer.SetActive(true);

                    damageBlinkTimer = damageBlinkTimerReset;
                    flashCount--;
                }
                if (flashCount <= 0)
                {
                    if (!racer.activeSelf) racer.SetActive(true);
                    damaged = false;
                    flashCount = 7;
                }
            }

            if (oilSlicked)
            {
                oilSlickTimer -= Time.deltaTime;
                if (oilSlickTimer <= 0)
                {
                    OilSlicked();
                    oilSlickTimer = 0;
                }
            }

            if (boostActivated)
            {
                if (boostTimer <= 0)
                {
                    boostActivated = false;
                    boost = 0;
                    boostRecharge = true;
                }
                else boostTimer -= Time.deltaTime;
            }

            if (boostRecharge)
            {
                boostRechargeTimer -= Time.deltaTime;
                if (boostRechargeTimer <= 0)
                {
                    boostTimer += Time.deltaTime;
                    if (boostTimer >= boostTimerReset)
                    {
                        boostRecharge = false;
                        boostRechargeTimer = boostRechargeTimerReset;
                        boostTimer = boostTimerReset;
                        canBoost = true;
                    }
                }
            }

            if (!canFireBullet)
            {
                bulletTimer += Time.deltaTime;
                if (bulletTimer >= bulletTimerReset)
                {
                    bulletTimer = bulletTimerReset;
                    canFireBullet = true;
                }
            }

            if (!canFireMissile)
            {
                missleTimer += Time.deltaTime;
                if (missleTimer >= missleTimerReset)
                {
                    missleTimer = missleTimerReset;
                    canFireMissile = true;
                }
            }

            if (!canDropMine)
            {
                mineTimer += Time.deltaTime;
                if (mineTimer >= mineTimerReset)
                {
                    mineTimer = mineTimerReset;
                    canDropMine = true;
                }
            }

            spriteCanvas.transform.SetPositionAndRotation(new Vector2(racer.transform.position.x, racer.transform.position.y - 1), startRotation);
        }
    }

    protected void Fire(Weapon_Select input)
    {
        switch (input)
        {
            case Weapon_Select.bullet:
                if (canFireBullet && bulletAmmo > 0)
                {
                    Instantiate(bullet, bulletFirePos.transform.position, transform.localRotation, transform);
                    bulletAmmo--;
                    canFireBullet = false;
                    bulletTimer = 0;
                }
                break;

            case Weapon_Select.missle:
                if (canFireMissile && missleAmmo > 0)
                {
                    Instantiate(missle, missleFirePos.transform.position, transform.localRotation, transform);
                    missleAmmo--;
                    canFireMissile = false;
                    missleTimer = 0;
                }
                break;

            case Weapon_Select.mine:
                if (canDropMine && mineAmmo > 0)
                {
                    Instantiate(mine, dropPos.transform.position, transform.localRotation, transform);
                    mineAmmo--;
                    canDropMine = false;
                    mineTimer = 0;
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
                            TakeHealth(8, collision);
                            break;
                    }
                }
            }

            if (collision.gameObject.tag == "Racer")
            {
                Vector3 direction = transform.position - collision.gameObject.transform.position;
                rb.AddForce(direction * 10, ForceMode2D.Impulse);

                damaged = true;
                TakeHealth(2, collision);
            }

            if (collision.gameObject.tag == "Wall")
            {
                damaged = true;
                TakeHealth(6, collision);
            }

            if (collision.gameObject.tag == "Explosion")
            {
                Vector3 direction = transform.position - collision.gameObject.transform.position;
                rb.AddForce(direction * 20, ForceMode2D.Impulse);
                damaged = true;
                TakeHealth(25, collision);
            }
        }
    }

    protected virtual void TakeHealth(int damage, Collision2D collision)
    {
        health -= damage - armourUpgradeLevel;
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
        health += value;
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

    // public State GetState()
    // {
    //     return state;
    // }

    public RacerType GetRacerType()
    {
        return type;
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
