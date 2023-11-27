using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using static Globals;
using Cinemachine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using System;

public class PlayerController : Racer
{
    GameObject car;

    CinemachineVirtualCamera pCam;
    float pCamFloat = 12;

    float horizontal;
    public Transform waypoint;

    public delegate void PlayerDiedAction();
    public static event PlayerDiedAction OnPlayerDied;
    // Start is called before the first frame update
    public override void SetupRacer()
    {
        base.SetupRacer();

        type = RacerType.player;
        racerName = DataManager.PlayerSave.racerName;

        string[] rgba = DataManager.PlayerSave.racerColor.Split(',');
        carColor.color = new Color(float.Parse(rgba[0]), float.Parse(rgba[1]), float.Parse(rgba[2]), float.Parse(rgba[3]));

        if (GameManager.GameLoaded)
        {
            TotalMoney = DataManager.PlayerSave.money;

            engineUpgradeLevel = DataManager.PlayerSave.engineUpgradeLevel;
            armourUpgradeLevel = DataManager.PlayerSave.armourUpgradeLevel;
            boostSpeedLevel = DataManager.PlayerSave.boostSpeedLevel;
            boostCooldownLevel = DataManager.PlayerSave.boostCooldownLevel;
            boostRechargeLevel = DataManager.PlayerSave.boostRechargeLevel;
            repairSkillLevel = DataManager.PlayerSave.repairSkill;
            speechSkillLevel = DataManager.PlayerSave.speechSkill;
            charmSkillLevel = DataManager.PlayerSave.charmSkill;
            bulletClipLevel = DataManager.PlayerSave.bulletClipLevel;
            missleClipLevel = DataManager.PlayerSave.missleClipLevel;
            mineClipLevel = DataManager.PlayerSave.mineClipLevel;
            bulletCooldownLevel = DataManager.PlayerSave.bulletCooldownLevel;
            missleCooldownLevel = DataManager.PlayerSave.missleCooldownLevel;
            mineCooldownLevel = DataManager.PlayerSave.mineCooldownLevel;

            bulletAmmo = DataManager.PlayerSave.bulletAmmo;
            missleAmmo = DataManager.PlayerSave.missleAmmo;
            mineAmmo = DataManager.PlayerSave.mineAmmo;
        }

        spriteName.text = racerName;

        pCam = transform.Find("playerCam").GetComponent<CinemachineVirtualCamera>();

        car = transform.gameObject;

        maxHealth = 50;
        health = maxHealth;

        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        boostBar.maxValue = boostTimerReset;
        boostBar.value = boostTimerReset;

        UpdateRacer();
        ready = true;
    }

    public override void UpdateRacer()
    {
        base.UpdateRacer();

        speedMax = baseSpeed + (baseSpeed * (engineUpgradeLevel * 0.1f));
        speed = speedMax;

        boostMax = baseBoostSpeed + (baseBoostSpeed * (boostSpeedLevel * 0.15f));

        boostTimerReset = baseBoostCooldown - (baseBoostCooldown * (boostCooldownLevel * 0.15f));
        boostTimer = boostTimerReset;

        boostRechargeTimerReset = baseBoostRecharge - (baseBoostRecharge * (boostRechargeLevel * 0.15f));
        boostRechargeTimer = boostRechargeTimerReset;

        boostBar.maxValue = boostTimerReset;
        boostBar.value = boostTimerReset;

        bulletAmmoMax = bulletAmmoBase + (20 * bulletClipLevel);
        missleAmmoMax = missleAmmoBase + (5 * missleClipLevel);
        mineAmmoMax = mineAmmoBase + (5 * mineClipLevel);

        bulletTimerReset = bulletTimerBase - (bulletTimerBase * (bulletCooldownLevel * 0.05f));
        missleTimerReset = missleTimerBase - (missleTimerBase * (missleCooldownLevel * 0.05f));
        mineTimerReset = mineTimerBase - (mineTimerBase * (mineCooldownLevel * 0.05f));

        DataManager.PlayerSave.money = TotalMoney;
        DataManager.PlayerSave.gameLevel = GameManager.GameLevel;

        DataManager.PlayerSave.engineUpgradeLevel = engineUpgradeLevel;
        DataManager.PlayerSave.armourUpgradeLevel = armourUpgradeLevel;
        DataManager.PlayerSave.boostSpeedLevel = boostSpeedLevel;
        DataManager.PlayerSave.boostRechargeLevel = boostRechargeLevel;
        DataManager.PlayerSave.boostCooldownLevel = boostCooldownLevel;

        DataManager.PlayerSave.bulletClipLevel = bulletClipLevel;
        DataManager.PlayerSave.missleClipLevel = missleClipLevel;
        DataManager.PlayerSave.mineClipLevel = mineClipLevel;

        DataManager.PlayerSave.bulletCooldownLevel = bulletCooldownLevel;
        DataManager.PlayerSave.missleCooldownLevel = missleCooldownLevel;
        DataManager.PlayerSave.mineCooldownLevel = mineCooldownLevel;

        DataManager.PlayerSave.repairSkill = repairSkillLevel;
        DataManager.PlayerSave.speechSkill = speechSkillLevel;
        DataManager.PlayerSave.charmSkill = charmSkillLevel;

        DataManager.PlayerSave.bulletAmmo = bulletAmmo;
        DataManager.PlayerSave.missleAmmo = missleAmmo;
        DataManager.PlayerSave.mineAmmo = mineAmmo;
    }

    public override void ResetRacer()
    {
        base.ResetRacer();
        UpdateRacer();
        pCam.gameObject.transform.rotation = startRotation;
    }

    public override void Update()
    {
        if(ready)
        {
            base.Update();

            animator.SetFloat("Vertical", rb.velocity.magnitude);
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

            RaceManager.State raceState = RaceManager.GetState();
            if (raceState == RaceManager.State.racing && RacerState != State.finished && RacerState != State.dead)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) && canBoost)
                {
                    boostAudio.Play();
                    canBoost = false;
                    boostActivated = true;
                    boost = boostMax;
                    boostFlame.Play();
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
        pCam.m_Lens.OrthographicSize = pCamFloat + (rb.velocity.magnitude * 0.2f);

        if (RacerState == State.finished || RacerState == State.dead) engineAudio.Stop();
        float pitch = Mathf.Clamp(rb.velocity.magnitude, 2, 50);
        engineAudio.pitch = pitch / 2;

        if (raceState == RaceManager.State.racing && RacerState != State.finished && RacerState != State.dead)
        {
            if (!engineAudio.isPlaying) engineAudio.Play();

            horizontal = Input.GetAxis("Horizontal");

            float vertical = Input.GetAxis("Vertical");

            if (RacerState != State.dead)
            {
                rb.AddRelativeForce(Vector2.up * vertical * (speed + boost) * Time.deltaTime, ForceMode2D.Force);

                if (horizontal > 0)
                {
                    if (rb.rotation > -80) rb.rotation -= turnSpeed * Time.deltaTime;
                }

                if (horizontal < 0)
                {
                    if (rb.rotation < 80) rb.rotation += turnSpeed * Time.deltaTime;
                }
            }
        }
    }

    public float[] GetBulletInfo()
    {
        float[] sendMe;
        sendMe = new float[2];
        sendMe[0] = bulletTimer;
        sendMe[1] = bulletTimerReset;

        return sendMe;
    }

    public float[] GetMissleInfo()
    {
        float[] sendMe;
        sendMe = new float[2];
        sendMe[0] = missleTimer;
        sendMe[1] = missleTimerReset;

        return sendMe;
    }

    public float[] GetMineInfo()
    {
        float[] sendMe;
        sendMe = new float[2];
        sendMe[0] = mineTimer;
        sendMe[1] = mineTimerReset;

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
