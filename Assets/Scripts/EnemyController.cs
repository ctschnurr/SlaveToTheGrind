using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class EnemyController : Racer
{
    GameObject waypoint;
    public List<GameObject> enemyWaypoints;

    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        waypoint = GameObject.Find("FirstPoint");
        rb = GetComponent<Rigidbody2D>();
        racer = gameObject.GetComponent<SpriteRenderer>();

        maxHealth = 25;
        health = maxHealth;

        speed = baseSpeed;
        speedMax = baseSpeed;

        turnSpeed = baseTurnSpeed;

        type = RacerType.enemy;
        racerName = "Enemy";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (effect != Effect.dead && effect != Effect.finished)
        {
            Vector3 targetDirection = waypoint.transform.position - transform.localPosition;
            Quaternion tempQuaternion = Quaternion.LookRotation(Vector3.forward, targetDirection);

            float angle = Vector3.Angle((waypoint.transform.position - transform.position), transform.up);

            rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime, ForceMode2D.Force);
            if (angle > 10f) transform.localRotation = Quaternion.Lerp(transform.localRotation, tempQuaternion, 5f * Time.deltaTime);

            if (Vector3.Distance(waypoint.transform.position, transform.position) < 10) waypoint = NextWaypoint(waypoint);

            if (waypoint == null) effect = Effect.finished;
        }
    }

    GameObject NextWaypoint(GameObject input)
    {
        GameObject nextWaypoint = TrackManager.SendNextWaypoint(input);

        return nextWaypoint;
    }
}
