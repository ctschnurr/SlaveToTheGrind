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

    private static int levelCounter = 1;

    // Start is called before the first frame update
    public override void SetupRacer()
    {
        base.SetupRacer();

        int pickName = Random.Range(0, enemyNames.Count);
        racerName = enemyNames[pickName];
        enemyNames.Remove(racerName);
        List<Color> colors = ScreenManager.Colors;
        int pickColor = Random.Range(0, colors.Count);
        racerColor = colors[pickColor];
        colors.Remove(racerColor);
        ScreenManager.Colors = colors;
        carColor.color = racerColor;
        type = RacerType.enemy;
        spriteName.text = racerName;

        waypoint = GameObject.Find("FirstPoint");

        maxHealth = 50;
        health = maxHealth;

        boostMax = 1000f;
        boost = 0;

        engineUpgradeLevel = levelCounter;

        speedMax = baseSpeed + (baseSpeed * (engineUpgradeLevel * 0.1f));
        speed = speedMax;
        turnSpeed = baseTurnSpeed;

        levelCounter++;

        racers = RaceManager.GetRacers();

        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        boostBar.maxValue = boostTimerReset;
        boostBar.value = boostTimerReset;

        ready = true;
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
                        int fireChance = Random.Range(1, 30 - gameLevel);

                        if(fireChance == 1)
                        {
                            if (canBoost)
                            {
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
                        int fireChance = Random.Range(1, 30 - (gameLevel * 2));
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
