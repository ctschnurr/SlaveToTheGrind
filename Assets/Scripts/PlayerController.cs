using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using static Globals;

public class PlayerController : Racer
{
    GameObject car;

    Quaternion rotation;
    Quaternion rotLeft;
    Quaternion rotRight;

    Vector3 rotationV;
    Vector3 rotLeftV;
    Vector3 rotRightV;

    float horizontal;

    float throttle;
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        car = transform.gameObject;
        rb = GetComponent<Rigidbody2D>();

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

        maxHealth = 25;
        health = maxHealth;

        speed = baseSpeed * Time.deltaTime;
        speedMax = baseSpeed * Time.deltaTime;
        turnSpeed = baseTurnSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = rb.velocity.magnitude;

        horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        throttle = (vertical * speed) + boost;

        if(!dead)
        {
            rb.AddRelativeForce(Vector2.up * throttle, ForceMode2D.Force);

            if (horizontal > 0)
            {
                if (rb.rotation > -50) rb.rotation -= turnSpeed;
            }

            if (horizontal < 0)
            {
                if (rb.rotation < 50) rb.rotation += turnSpeed;
            }
        }
    }

    public int GetHealth()
    {
        return health;
    }

}
