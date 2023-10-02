using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class EnemyController : Racer
{
    Transform waypoint;
    public List<Transform> enemyWaypoints;

    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        enemyWaypoints = TrackManager.GetWaypoints();
        waypoint = enemyWaypoints[0];
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
        if (!dead)
        {
            Vector3 targetDirection = waypoint.transform.position - transform.localPosition;
            Quaternion tempQuaternion = Quaternion.LookRotation(Vector3.forward, targetDirection);

            float angle = Vector3.Angle((waypoint.transform.position - transform.position), transform.up);

            rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime, ForceMode2D.Force);
            if (angle > 10f) transform.localRotation = Quaternion.Lerp(transform.localRotation, tempQuaternion, 5f * Time.deltaTime);

            if (Vector3.Distance(waypoint.position, transform.position) < 10) waypoint = NextWaypoint(waypoint);
        }
    }

    Transform NextWaypoint(Transform input)
    {
        enemyWaypoints.Remove(input);

        return enemyWaypoints[0];
    }
}
