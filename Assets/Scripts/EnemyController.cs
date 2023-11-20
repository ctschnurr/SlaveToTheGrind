using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using static GameManager;
using static Globals;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class EnemyController : Racer
{
    GameObject waypoint;
    public List<GameObject> enemyWaypoints;
    public List<GameObject> racers;

    public float angle;

    private PlayerController player;
    private static int enemyCounter = 0;
    public static int EnemyCounter { get { return enemyCounter; } set { enemyCounter = value; } }

    // Start is called before the first frame update
    public override void SetupRacer()
    {
        base.SetupRacer();

        player = GameObject.Find("PlayerRacer").GetComponent<PlayerController>();

        if (GameLoaded)
        {
            RacerData[] enemySaves = DataManager.EnemySaves;

            racerName = DataManager.EnemySaves[enemyCounter].racerName;
            string[] rgba = DataManager.EnemySaves[enemyCounter].racerColor.Split(',');
            carColor.color = new Color(float.Parse(rgba[0]), float.Parse(rgba[1]), float.Parse(rgba[2]), float.Parse(rgba[3]));
            engineUpgradeLevel = DataManager.EnemySaves[enemyCounter].engineUpgradeLevel;
            armourUpgradeLevel = DataManager.EnemySaves[enemyCounter].armourUpgradeLevel;
            boostSpeedLevel = DataManager.EnemySaves[enemyCounter].boostSpeedLevel;
            boostRechargeLevel = DataManager.EnemySaves[enemyCounter].boostRechargeLevel;
            boostCooldownLevel = DataManager.EnemySaves[enemyCounter].boostCooldownLevel;
        }
        else
        {
            int pickName = Random.Range(0, enemyNames.Count);
            racerName = enemyNames[pickName];
            enemyNames.Remove(racerName);
            List<Color> colors = ScreenManager.Colors;
            int pickColor = Random.Range(0, colors.Count);
            racerColor = colors[pickColor];
            colors.Remove(racerColor);
            ScreenManager.Colors = colors;
            carColor.color = racerColor;

            engineUpgradeLevel = enemyCounter + 1;
            armourUpgradeLevel = enemyCounter + 1;
            boostSpeedLevel = enemyCounter + 1;
            boostRechargeLevel = enemyCounter + 1;
            boostCooldownLevel = enemyCounter + 1;
        }

        type = RacerType.enemy;
        spriteName.text = racerName;

        waypoint = GameObject.Find("FirstPoint");

        maxHealth = 50;
        health = maxHealth;

        turnSpeed = baseTurnSpeed;

        racers = RaceManager.GetRacers();

        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        boostBar.maxValue = boostTimerReset;
        boostBar.value = boostTimerReset;

        UpdateRacer();
        ready = true;
    }

    public override void ResetRacer()
    {
        //TrackManager.SendNextWaypoint(null);
        base.ResetRacer();
        waypoint = GameObject.Find("FirstPoint");
    }

    public override void UpdateRacer()
    {
        base.UpdateRacer();

        speedMax = baseSpeed + (baseSpeed * ((engineUpgradeLevel + GameLevel) * 0.1f));
        speed = speedMax;

        armourUpgradeLevel = enemyCounter + 1 + GameLevel;

        boostMax = baseBoostSpeed + (baseBoostSpeed * ((boostSpeedLevel + GameLevel) * 0.15f));

        boostTimerReset = baseBoostCooldown - (baseBoostCooldown * ((boostCooldownLevel + GameLevel) * 0.15f));
        boostTimer = boostTimerReset;

        boostRechargeTimerReset = baseBoostRecharge - (baseBoostRecharge * ((boostRechargeLevel + GameLevel) * 0.15f));
        boostRechargeTimer = boostRechargeTimerReset;

        boostBar.maxValue = boostTimerReset;
        boostBar.value = boostTimerReset;

        RacerData[] enemySaves = DataManager.EnemySaves;

        DataManager.EnemySaves[enemyCounter].racerName = racerName;
        string rgba = carColor.color.r.ToString() + "," + carColor.color.g.ToString() + "," + carColor.color.b.ToString() + "," + carColor.color.a.ToString();
        DataManager.EnemySaves[enemyCounter].racerColor = rgba;

        DataManager.EnemySaves[enemyCounter].engineUpgradeLevel = engineUpgradeLevel;
        DataManager.EnemySaves[enemyCounter].armourUpgradeLevel = armourUpgradeLevel;
        DataManager.EnemySaves[enemyCounter].boostSpeedLevel = boostSpeedLevel;
        DataManager.EnemySaves[enemyCounter].boostRechargeLevel = boostRechargeLevel;
        DataManager.EnemySaves[enemyCounter].boostCooldownLevel = boostCooldownLevel;

        DataManager.EnemySaves = enemySaves;

        enemyCounter++;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaceManager.State raceState = RaceManager.GetState();

        if (raceState != RaceManager.State.prep && raceState != RaceManager.State.countdown && RacerState != State.finished && RacerState != State.dead)
        {
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
                    if (lookForward < 5f && distance < 12)
                    {
                        int fireChance;

                        if(racer.GetComponent<Racer>() == player) fireChance = Random.Range(1, 20 - GameManager.GameLevel + player.CharmSkillLevel);
                        else fireChance = Random.Range(1, 20 - GameManager.GameLevel);

                        if (fireChance == 1)
                        {
                            if (canBoost)
                            {
                                boostFlame.Play();
                                canBoost = false;
                                boostActivated = true;
                                boost = boostMax;
                            }
                            else
                            {
                                if (missleAmmo > 0 && distance > 5) Fire(Weapon_Select.missle);
                                else Fire(Weapon_Select.bullet);
                            }
                        }
                    }

                    float lookBack = Vector3.Angle(racer.transform.position - transform.position, transform.up);
                    if (lookBack > 170f && distance < 12)
                    {
                        int fireChance = Random.Range(1, 30 - (GameLevel * 2));
                        if (fireChance == 1)
                        {
                            int choice = Random.Range(1, 3);
                            switch (choice)
                            {
                                case 1:
                                    if (mineAmmo > 0 && distance > 3) Fire(Weapon_Select.mine);
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
        GameObject nextWaypoint = TrackManager.SendNextWaypoint(input);
        if(nextWaypoint == null) return input;
        else return nextWaypoint;
    }

    public override void Update()
    {
        if(ready)
        {
            base.Update();

            Vector3 targetDirection = waypoint.transform.position - transform.localPosition;
            Quaternion tempQuaternion = Quaternion.LookRotation(Vector3.forward, targetDirection);

            float turn = 0;

            float direction = (transform.localRotation.z - tempQuaternion.z) * 10;
            if (direction > 0.65) turn = 1;
            if (direction < 0.65 && direction > -0.65) turn = 0;
            if (direction < -0.65) turn = -1;

            animator.SetFloat("Horizontal", turn);
            animator.SetFloat("Vertical", rb.velocity.magnitude * 100);

            healthBar.value = health;
            boostBar.value = boostTimer;
        }
    }
}
