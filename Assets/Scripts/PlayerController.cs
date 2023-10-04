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

    Quaternion rotation;
    Quaternion rotLeft;
    Quaternion rotRight;

    Vector3 rotationV;
    Vector3 rotLeftV;
    Vector3 rotRightV;

    CinemachineVirtualCamera pCam;
    float pCamFloat = 10;

    float horizontal;
    public Transform waypoint;

    // Start is called before the first frame update
    public override void SetupRacer()
    {
        car = transform.gameObject;
        rb = GetComponent<Rigidbody2D>();
        pCam = transform.Find("playerCam").GetComponent<CinemachineVirtualCamera>();

        rotation = car.transform.localRotation;
        rotLeft = rotation;
        rotLeft.z -= .1f;
        rotRight = rotation;
        rotRight.z += .1f;

        rotationV = car.transform.position;
        rotLeftV = rotationV;
        rotLeftV.y -= 5;
        rotRightV = rotationV;
        rotRightV.y += 5;

        racer = gameObject.GetComponent<SpriteRenderer>();

        maxHealth = 50;
        health = maxHealth;

        speed = baseSpeed;
        speedMax = baseSpeed;
        turnSpeed = baseTurnSpeed;

        type = RacerType.player;
        racerName = "Player";

        finishLine = TrackManager.GetFinishline();
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

    // Update is called once per frame
    void FixedUpdate()
    {
        RaceManager.State raceState = RaceManager.GetState();

        if(raceState == RaceManager.State.racing && state != State.finished && state != State.dead)
        {
            pCam.m_Lens.OrthographicSize = pCamFloat + (rb.velocity.magnitude * 0.75f);

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
        return moneyThisRound;
    }

}
