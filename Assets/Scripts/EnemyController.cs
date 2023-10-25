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

    private static int levelCounter = 0;

    // Start is called before the first frame update
    public override void SetupRacer()
    {
        base.SetupRacer();

        engineUpgradeLevel = levelCounter;
        levelCounter++;

        int pickName = Random.Range(0, enemyNames.Count);
        racerName = enemyNames[pickName];
        enemyNames.Remove(racerName);
        type = RacerType.enemy;
        spriteName.text = racerName;

        waypoint = GameObject.Find("FirstPoint");

        maxHealth = 50;
        health = maxHealth;

        engineUpgradeLevel = levelCounter;
        levelCounter++;

        speedMax = baseSpeed + (baseSpeed * (engineUpgradeLevel * 0.15f));
        speed = speedMax;
        turnSpeed = baseTurnSpeed;

        racers = RaceManager.GetRacers();

        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    public override void ResetRacer()
    {
        //TrackManager.SendNextWaypoint(null);
        base.ResetRacer();
        waypoint = GameObject.Find("FirstPoint");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaceManager.State raceState = RaceManager.GetState();

        if (raceState == RaceManager.State.racing && RacerState != State.finished && RacerState != State.dead)
        {
            Vector3 targetDirection = waypoint.transform.position - transform.localPosition;
            Quaternion tempQuaternion = Quaternion.LookRotation(Vector3.forward, targetDirection);

            float angle = Vector3.Angle((waypoint.transform.position - transform.position), transform.up);

            rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime, ForceMode2D.Force);
            if (angle > 10f) transform.localRotation = Quaternion.Lerp(transform.localRotation, tempQuaternion, 5f * Time.deltaTime);

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
                        int fireChance = Random.Range(1, 10 - gameLevel);

                        if(fireChance == 1)
                        {
                            if (missleAmmo > 0 && distance > 5) Fire(Weapon_Select.missle);
                            else Fire(Weapon_Select.bullet);
                        }
                    }

                    float lookBack = Vector3.Angle(racer.transform.position - transform.position, transform.up);
                    if (lookBack > 170f && distance < 12)
                    {
                        int fireChance = Random.Range(1, 10 - gameLevel);
                        if (fireChance == 1)
                        {
                            if (mineAmmo > 0 && distance > 3) Fire(Weapon_Select.mine);
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
        base.Update();

        healthBar.value = health;
        spriteCanvas.transform.rotation = startRotation;
    }
}
