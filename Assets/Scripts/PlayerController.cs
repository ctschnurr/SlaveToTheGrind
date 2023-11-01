using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using static Globals;
using Cinemachine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PlayerController : Racer
{
    GameObject car;

    CinemachineVirtualCamera pCam;
    float pCamFloat = 10;

    float horizontal;
    public Transform waypoint;

    protected int speechSkill = 0;
    public int SpeechSkillLevel { get; set; }

    public delegate void PlayerDiedAction();
    public static event PlayerDiedAction OnPlayerDied;
    // Start is called before the first frame update
    public override void SetupRacer()
    {
        base.SetupRacer();

        type = RacerType.player;
        racerName  = "PlayeRat";
        spriteName.text = racerName;

        pCam = transform.Find("playerCam").GetComponent<CinemachineVirtualCamera>();

        car = transform.gameObject;

        maxHealth = 50;
        health = maxHealth;

        totalMoney = 1000;

        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        boostBar.maxValue = boostTimerReset;
        boostBar.value = boostTimerReset;
    }

    public override void UpdateRacer()
    {
        base.UpdateRacer();

        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        boostBar.maxValue = boostTimerReset;
        boostBar.value = boostTimerReset;
    }

    public override void ResetRacer()
    {
        base.ResetRacer();
        UpdateRacer();
        pCam.gameObject.transform.rotation = startRotation;
    }

    public override void Update()
    {
        base.Update();

        animator.SetFloat("Vertical", rb.velocity.magnitude);
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        RaceManager.State raceState = RaceManager.GetState();
        if (raceState == RaceManager.State.racing && RacerState != State.finished && RacerState != State.dead)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && canBoost)
            {
                canBoost = false;
                boostActivated = true;
                boost = boostMax;
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

        healthBar.value = health;
        boostBar.value = boostTimer;
    }

    protected override void TakeHealth(int damage, Collision2D collision)
    {
        base.TakeHealth(damage, collision);
        if (health <= 0) PlayerDied();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaceManager.State raceState = RaceManager.GetState();

        if(raceState == RaceManager.State.racing && RacerState != State.finished && RacerState != State.dead)
        {
            pCam.m_Lens.OrthographicSize = pCamFloat + (rb.velocity.magnitude * 0.1f);

            horizontal = Input.GetAxis("Horizontal");

            float vertical = Input.GetAxis("Vertical");

            if (RacerState != State.dead)
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

    public float[] GetBulletInfo()
    {
        float[] sendMe;
        sendMe = new float[2];
        sendMe[0] = bulletAmmo;
        sendMe[1] = bulletTimer / bulletTimerReset;

        return sendMe;
    }

    public float[] GetMissleInfo()
    {
        float[] sendMe;
        sendMe = new float[2];
        sendMe[0] = missleAmmo;
        sendMe[1] = missleTimer / missleTimerReset;

        return sendMe;
    }

    public float[] GetMineInfo()
    {
        float[] sendMe;
        sendMe = new float[2];
        sendMe[0] = mineAmmo;
        sendMe[1] = mineTimer / mineTimerReset;

        return sendMe;
    }

    public int GetMoney()
    {
        return totalMoney;
    }

    // public int GetEngineLevel()
    // {
    //     return engineUpgradeLevel;
    // }
    // public void SetEngineLevel(int set)
    // {
    //     engineUpgradeLevel = set;
    // }
    // 
    // public int GetArmourLevel()
    // {
    //     return armourUpgradeLevel;
    // }
    // 
    // public void SetArmourLevel(int set)
    // {
    //     armourUpgradeLevel = set;
    // }
    // 
    // public int GetBoostSpeedLevel()
    // {
    //     return boostSpeedLevel;
    // }
    // 
    // public void SetBoostSpeedLevel(int set)
    // {
    //     boostSpeedLevel = set;
    // }
    // 
    // public int GetRepairSkill()
    // {
    //     return repairSkill;
    // }
    // 
    // public int GetSpeechSkill()
    // {
    //     return speechSkill;
    // }

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
