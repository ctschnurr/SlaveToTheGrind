using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class EnemyController : Racer
{
    GameObject waypoint;

    // Start is called before the first frame update
    void Start()
    {
        waypoint = GameObject.Find("TrackManager/Waypoints/waypoint");
        rb = GetComponent<Rigidbody2D>();
        racer = gameObject.GetComponent<SpriteRenderer>();

        maxHealth = 25;
        health = maxHealth;

        speed = baseSpeed;
        speedMax = baseSpeed;

        type = RacerType.enemy;
        racerName = "Enemy";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dead)
        {
            rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime, ForceMode2D.Force);

            Vector3 targetDirection = waypoint.transform.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 3, 1f);

            transform.rotation = Quaternion.LookRotation(Vector3.forward, newDirection);
        }
    }
}
