using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using static Globals;
using Cinemachine;

public class PlayerController : Racer
{
    GameObject car;

    CinemachineVirtualCamera pCam;
    float pCamFloat = 10;

    float horizontal;
    public Transform waypoint;

    private int speechSkill;

    public delegate void PlayerDiedAction();
    public static event PlayerDiedAction OnPlayerDied;
    // Start is called before the first frame update
    public override void SetupRacer()
    {
        type = RacerType.player;
        racerName = GameManager.GetPlayerName();

        rb = GetComponent<Rigidbody2D>();
        pCam = transform.Find("playerCam").GetComponent<CinemachineVirtualCamera>();

        car = transform.gameObject;

        startPosition = transform.position;
        startRotation = transform.rotation;

        racer = gameObject.GetComponent<SpriteRenderer>();

        maxHealth = 50;
        health = maxHealth;

        speedMax = baseSpeed;
        speed = speedMax;
        turnSpeed = baseTurnSpeed;

        finishLine = TrackManager.GetFinishline();
    }

    public void UpdateRacer()
    {
        speedMax = baseSpeed + (baseSpeed * (engineUpgradeLevel * 0.15f));
        speed = speedMax;
    }

    public override void ResetRacer()
    {
        base.ResetRacer();
        pCam.gameObject.transform.rotation = startRotation;
        defeatedBy = null;
    }

    public override void Update()
    {
        base.Update();

        RaceManager.State raceState = RaceManager.GetState();
        if (raceState == RaceManager.State.racing && state != State.finished && state != State.dead)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && canBoost)
            {
                canBoost = false;
                boostTimer = boostTimerReset;
                boosted = true;
                boost = boostReset;
            }

            if (Input.GetKeyDown(KeyCode.Space)) Fire(Weapon_Select.bullet);
            if (Input.GetKeyDown(KeyCode.F)) Fire(Weapon_Select.missle);
            if (Input.GetKeyDown(KeyCode.E)) Fire(Weapon_Select.mine);

        }

        if (raceState == RaceManager.State.racing)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.Pause();
            }
        }
    }

    protected override void TakeHealth(int damage)
    {
        base.TakeHealth(damage);
        if (health <= 0) PlayerDied();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaceManager.State raceState = RaceManager.GetState();

        if(raceState == RaceManager.State.racing && state != State.finished && state != State.dead)
        {
            pCam.m_Lens.OrthographicSize = pCamFloat + (rb.velocity.magnitude * 0.1f);

            horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (state != State.dead)
            {
                rb.AddRelativeForce(Vector2.up * vertical * (speed + boost) * Time.deltaTime, ForceMode2D.Force);

                if (horizontal > 0)
                {
                    if (rb.rotation > -65) rb.rotation -= turnSpeed * Time.deltaTime;
                }

                if (horizontal < 0)
                {
                    if (rb.rotation < 65) rb.rotation += turnSpeed * Time.deltaTime;
                }
            }
        }
    }

    public int GetHealth()
    {
        return health;
    }
    public float[] GetBoostInfo()
    {
        float[] sendMe;
        sendMe = new float[2];
        sendMe[0] = boost;
        sendMe[1] = boostTimer;

        return sendMe;
    }

    public float[] GetBulletInfo()
    {
        float[] sendMe;
        sendMe = new float[2];
        sendMe[0] = bulletAmmo;
        sendMe[1] = bulletTimer;

        return sendMe;
    }

    public float[] GetMissleInfo()
    {
        float[] sendMe;
        sendMe = new float[2];
        sendMe[0] = missleAmmo;
        sendMe[1] = missleTimer;

        return sendMe;
    }

    public float[] GetMineInfo()
    {
        float[] sendMe;
        sendMe = new float[2];
        sendMe[0] = mineAmmo;
        sendMe[1] = mineTimer;

        return sendMe;
    }

    public int GetMoney()
    {
        return totalMoney;
    }

    public int GetEngineLevel()
    {
        return engineUpgradeLevel;
    }
    public void SetEngineLevel(int set)
    {
        engineUpgradeLevel = set;
    }

    public int GetArmourLevel()
    {
        return armourUpgradeLevel;
    }

    public void SetArmourLevel(int set)
    {
        armourUpgradeLevel = set;
    }

    public int GetRepairSkill()
    {
        return repairSkill;
    }

    public int GetSpeechSkill()
    {
        return speechSkill;
    }

    public void SpendMoney(int spent)
    {
        totalMoney -= spent;
    }

    public void PlayerDied()
    {
        if (OnPlayerDied != null)
        {
            OnPlayerDied();
        }
    }

}
