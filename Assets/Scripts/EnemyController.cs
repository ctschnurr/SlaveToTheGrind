using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Racer
{
    GameObject waypoint;

    // Start is called before the first frame update
    void Start()
    {
        waypoint = GameObject.Find("waypoint");
        rb = GetComponent<Rigidbody2D>();
        racer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(Vector3.up * speed, ForceMode2D.Force);

        Vector3 targetDirection = waypoint.transform.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 3, 1f);

        transform.rotation = Quaternion.LookRotation(Vector3.forward, newDirection);
    }
}
