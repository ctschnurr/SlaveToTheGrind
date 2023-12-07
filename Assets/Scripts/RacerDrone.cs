using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEngine.Rendering;
using static Globals;
using static Racer;

public class RacerDrone : Racer
{
    GameObject waypoint;
    public List<GameObject> enemyWaypoints;
    public List<GameObject> racers;

    public float angle;

    private PlayerController player;
    private static int enemyCounter = 0;
    public static int EnemyCounter { get { return enemyCounter; } set { enemyCounter = value; } }

    // Start is called before the first frame update
    void Awake()
    {
        finishLine = 100;

        engineAudio = transform.Find("RacerAudio").GetComponent<AudioSource>();
        boostAudio = transform.Find("BoostAudio").GetComponent<AudioSource>();
        bulletAudio = bulletFirePos.GetComponent<AudioSource>();
        mineAudio = dropPos.GetComponent<AudioSource>();
        damageAudio = transform.Find("DamageAudio").GetComponent<AudioSource>();
        carColor = transform.Find("RacerSprite/carPaint").GetComponent<SpriteRenderer>();
        dirtSpray = transform.Find("Dirt").GetComponent<ParticleSystem>();
        boostFlame = transform.Find("Boost").GetComponent<ParticleSystem>();

        rb = transform.GetComponent<Rigidbody2D>();
        racer = transform.Find("RacerSprite").gameObject;

        engineUpgradeLevel = enemyCounter;
        boostSpeedLevel = enemyCounter;

        waypoint = GameObject.Find("FirstPoint");

        turnSpeed = baseTurnSpeed;

        racers = RacerDroneController.drones;

        UpdateRacer();
        ready = true;
    }

    public override void UpdateRacer()
    {
        base.UpdateRacer();

        speedMax = baseSpeed + (baseSpeed * (engineUpgradeLevel * 0.1f));
        speed = speedMax;

        boostMax = baseBoostSpeed + (baseBoostSpeed * ((boostSpeedLevel) * 0.15f));

        boostTimerReset = baseBoostCooldown - (baseBoostCooldown * (boostCooldownLevel * 0.15f));
        boostTimer = boostTimerReset;

        boostRechargeTimerReset = baseBoostRecharge - (baseBoostRecharge * ((boostRechargeLevel) * 0.15f));
        boostRechargeTimer = boostRechargeTimerReset;

        bulletAmmo = bulletAmmoMax;
        missleAmmo = missleAmmoMax;
        mineAmmo = MineAmmoMax;

        if (enemyCounter < 4) enemyCounter++;
        else enemyCounter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y > 30)
        {
            RacerDroneController.drones.Remove(gameObject);
            Destroy(gameObject);
        }

        float pitch = Mathf.Clamp(rb.velocity.magnitude, 2, 50);
        engineAudio.pitch = pitch / 2;

        if (RacerDroneController.activated)
        {
            if (!engineAudio.isPlaying)
            {
                engineAudio.enabled = true;
                engineAudio.Play();
            }

            float angle = Vector3.Angle((waypoint.transform.position - transform.position), transform.up);

            rb.AddRelativeForce(Vector2.up * (speed + boost) * Time.deltaTime, ForceMode2D.Force);

            Vector3 targetDirection = waypoint.transform.position - transform.localPosition;
            Quaternion tempQuaternion = Quaternion.LookRotation(Vector3.forward, targetDirection);

            float turn = 0;

            float direction = (transform.localRotation.z - tempQuaternion.z) * 10;
            if (direction > 0.65) turn = 1;
            if (direction < 0.65 && direction > -0.65) turn = 0;
            if (direction < -0.65) turn = -1;

            animator.SetFloat("Horizontal", turn);
            animator.SetFloat("Vertical", rb.velocity.magnitude * 100);

            if (angle > 10f)
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, tempQuaternion, 3f * Time.deltaTime);
            }

            if (Vector3.Distance(waypoint.transform.position, transform.position) < 10) waypoint = NextWaypoint(waypoint);


            // if (waypoint == null) effect = Effect.finished;

            foreach (GameObject racer in racers)
            {
                if (racer != gameObject)
                {
                    float distance = Vector3.Distance(racer.transform.position, transform.position);

                    float dontCrash = Vector3.Angle(racer.transform.position - transform.position, transform.up);
                    if (dontCrash < 60 && distance < 3) rb.AddRelativeForce(-(transform.position - racer.transform.position) * 5 * Time.deltaTime, ForceMode2D.Force);

                    float lookForward = Vector3.Angle(racer.transform.position - transform.position, transform.up);
                    if (lookForward < 10f && distance < 15)
                    {
                        int fireChance;

                        fireChance = Random.Range(1, 10);

                        if (fireChance == 1)
                        {
                            int choice;
                            choice = Random.Range(1, 4);
                            switch(choice)
                            {
                                case 1:
                                    if (canBoost)
                                    {
                                        boostAudio.Play();
                                        boostFlame.Play();
                                        canBoost = false;
                                        boostActivated = true;
                                        boost = boostMax;
                                    }
                                    break;

                                case 2:
                                    Fire(Weapon_Select.missle);
                                    break;

                                case 3:
                                    Fire(Weapon_Select.bullet);
                                    break;
                            }
                        }
                    }

                    float lookBack = Vector3.Angle(racer.transform.position - transform.position, transform.up);
                    if (lookBack > 170f && distance < 12)
                    {
                        int fireChance = Random.Range(1, 20);
                        if (fireChance == 1)
                        {
                            int choice = Random.Range(1, 3);
                            switch (choice)
                            {
                                case 1:
                                    if (mineAmmo > 0 && distance > 3) ; // Fire(Weapon_Select.mine);
                                    else if (canBoost)
                                    {
                                        canBoost = false;
                                        boostActivated = true;
                                        boost = boostMax;
                                    }
                                    break;

                                case 2:
                                    if (canBoost)
                                    {
                                        canBoost = false;
                                        boostActivated = true;
                                        boost = boostMax;
                                    }
                                    break;
                            }
                        }
                    }

                }

            }
        }
    }

    GameObject NextWaypoint(GameObject input)
    {
        GameObject nextWaypoint = RacerDroneController.SendNextWaypoint(input);
        if (nextWaypoint == null) return input;
        else return nextWaypoint;
    }
    public override void Update()
    {
        Vector3 targetDirection = waypoint.transform.position - transform.localPosition;
        Quaternion tempQuaternion = Quaternion.LookRotation(Vector3.forward, targetDirection);

        float turn = 0;

        float direction = (transform.localRotation.z - tempQuaternion.z) * 10;
        if (direction > 0.65) turn = 1;
        if (direction < 0.65 && direction > -0.65) turn = 0;
        if (direction < -0.65) turn = -1;

        animator.SetFloat("Horizontal", turn);
        animator.SetFloat("Vertical", rb.velocity.magnitude * 100);

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

        var em = dirtSpray.emission;
        em.rateOverTime = rb.velocity.magnitude;
    }

    protected override void TakeHealth(int damage, Collision2D collision)
    {

    }
}
