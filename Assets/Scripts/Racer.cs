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
    public RacerType Type { get { return type; } }

    public enum Weapon_Select
    {
        bullet,
        missle,
        mine
    }
    // Upgradables

    protected int engineUpgradeLevel = 0;
    public int EngineUpgradeLevel { get { return engineUpgradeLevel; } set { engineUpgradeLevel = value; } }
    protected int armourUpgradeLevel = 0;
    public int ArmourUpgradeLevel { get { return armourUpgradeLevel; } set { armourUpgradeLevel = value; } }
    protected int boostSpeedLevel = 0;
    public int BoostSpeedLevel { get { return boostSpeedLevel; } set { boostSpeedLevel = value; } }
    protected int boostCooldownLevel = 0;
    public int BoostCooldownLevel { get { return boostCooldownLevel; } set { boostCooldownLevel = value; } }

    protected int boostRechargeLevel = 0;
    public int BoostRechargeLevel { get { return boostRechargeLevel; } set { boostRechargeLevel = value; } }


    protected int repairSkillLevel = 0;
    public int RepairSkillLevel { get { return repairSkillLevel; } set { repairSkillLevel = value; } }
    protected int speechSkillLevel = 0;
    public int SpeechSkillLevel { get { return speechSkillLevel; } set { speechSkillLevel = value; } }
    protected int charmSkillLevel = 0;
    public int CharmSkillLevel { get { return charmSkillLevel; } set { charmSkillLevel = value; } }
    protected int bulletClipLevel = 0;
    public int BulletClipLevel { get { return bulletClipLevel; } set { bulletClipLevel = value; } }

    protected int bulletCooldownLevel = 0;
    public int BulletCooldownLevel { get { return bulletCooldownLevel; } set { bulletCooldownLevel = value; } }

    protected int missleClipLevel = 0;
    public int MissleClipLevel { get { return missleClipLevel; } set { missleClipLevel = value; } }

    protected int missleCooldownLevel = 0;
    public int MissleCooldownLevel { get { return missleCooldownLevel; } set { missleCooldownLevel = value; } }

    protected int mineClipLevel = 0;
    public int MineClipLevel { get { return mineClipLevel; } set { mineClipLevel = value; } }

    protected int mineCooldownLevel = 0;
    public int MineCooldownLevel { get { return mineCooldownLevel; } set { mineCooldownLevel = value; } }

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
    protected ParticleSystem dirtSpray;
    protected ParticleSystem boostFlame;
    protected ParticleSystem wreckedSmoke;

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
    protected int bulletAmmo = 20;

    public int BulletAmmo { get { return bulletAmmo; } set { bulletAmmo = value; } }
    protected int bulletAmmoMax = 20;
    public int BulletAmmoMax { get { return bulletAmmoMax; } set { bulletAmmoMax = value; } }

    public GameObject missle;
    protected float missleTimer = 1.5f;
    protected float missleTimerReset = 1.5f;
    protected bool canFireMissile = true;
    protected int missleAmmo = 5;
    public int MissleAmmo { get { return missleAmmo; } set { missleAmmo = value; } }

    protected int missleAmmoMax = 3;
    public int MissleAmmoMax { get { return missleAmmoMax; } set { missleAmmoMax = value; } }

    public GameObject mine;
    protected float mineTimer = 1f;
    protected float mineTimerReset = 1f;
    protected bool canDropMine = true;
    protected int mineAmmo = 5;
    public int MineAmmo { get { return mineAmmo; } set { mineAmmo = value; } }

    protected int mineAmmoMax = 5;
    public int MineAmmoMax { get { return mineAmmoMax; } set { mineAmmoMax = value; } }

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
        dirtSpray = transform.Find("Dirt").GetComponent<ParticleSystem>();
        boostFlame = transform.Find("Boost").GetComponent<ParticleSystem>();
        wreckedSmoke = transform.Find("Smoke").GetComponent<ParticleSystem>();

        startPosition = transform.position;
        startRotation = transform.rotation;

        rb = transform.GetComponent<Rigidbody2D>();
        racer = transform.Find("RacerSprite").gameObject;

        turnSpeed = baseTurnSpeed;

        finishLine = TrackManager.GetFinishline();

        // dirtSpray.transform.localPosition = new Vector2(0, -2);
        // boostFlame.transform.localPosition = new Vector2(0, -2.1f);
        // wreckedSmoke.transform.localPosition = new Vector2(0, -0.25f);
    }

    public virtual void UpdateRacer()
    {

    }
    public virtual void ResetRacer()
    {
        rb.velocity = Vector3.zero;
        if (!racer.activeSelf) racer.SetActive(true);
        transform.SetPositionAndRotation(startPosition, startRotation);
        RacerState = State.idle;
        health = maxHealth;

        moneyThisRound = 0;
        if(defeated != null) defeated.Clear();

        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        boostBar.maxValue = boostTimerReset;
        boostBar.value = boostTimerReset;

        transform.position = startPosition;
        if (wreckedSmoke.isPlaying) wreckedSmoke.Stop();

        // dirtSpray.transform.localPosition = new Vector2(racer.transform.position.x, -2);
        // boostFlame.transform.localPosition = new Vector2(racer.transform.position.x, -2.1f);
        // wreckedSmoke.transform.localPosition = new Vector2(racer.transform.position.x, -0.25f);
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
                    // damageBlinkTimer -= Time.deltaTime;
                    // if (damageBlinkTimer <= 0)
                    // {
                    //     if (racer.activeSelf) racer.SetActive(false);
                    //     else racer.SetActive(true);
                    // 
                    //     damageBlinkTimer = damageBlinkTimerReset;
                    // }
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
                    boostFlame.Stop();
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

            if (!canFireBullet && bulletAmmo > 0)
            {
                bulletTimer += Time.deltaTime;
                if (bulletTimer >= bulletTimerReset)
                {
                    bulletTimer = bulletTimerReset;
                    canFireBullet = true;
                }
            }

            if (!canFireMissile && missleAmmo > 0)
            {
                missleTimer += Time.deltaTime;
                if (missleTimer >= missleTimerReset)
                {
                    missleTimer = missleTimerReset;
                    canFireMissile = true;
                }
            }

            if (!canDropMine && mineAmmo > 0)
            {
                mineTimer += Time.deltaTime;
                if (mineTimer >= mineTimerReset)
                {
                    mineTimer = mineTimerReset;
                    canDropMine = true;
                }
            }

            spriteCanvas.transform.SetPositionAndRotation(new Vector2(racer.transform.position.x, racer.transform.position.y - 1), startRotation);
            var em = dirtSpray.emission;
            em.rateOverTime = rb.velocity.magnitude;
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
            wreckedSmoke.Play();
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
        TotalMoney += earnings;
    }
}
