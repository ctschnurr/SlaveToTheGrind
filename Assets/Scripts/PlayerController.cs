using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

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
    public float boost;
    float boostReset = 25f;
    public float boostDelay = 0.25f;
    float boostDelayReset = 0.25f;

    bool boosted = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float throttle = (vertical * speed) + boost;

        if (boosted)
        {
            if (boostDelay <= 0)
            {
                boost -= 0.1f;
                if (boost <= 0)
                {
                    boosted = false;
                    boostDelay = boostDelayReset;
                }
            }
            else boostDelay -= Time.deltaTime;
        }

        rb.AddRelativeForce(Vector2.up * throttle, ForceMode2D.Force);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            boosted = true;
            boost = boostReset;
        }

        if (horizontal > 0)
        {
            if (rb.rotation > -50)
            {
                rb.rotation -= 0.2f;
            }
        }

        if (horizontal < 0)
        {
            if (rb.rotation < 50) rb.rotation += 0.2f;
        }
    }

}
