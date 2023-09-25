using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject car;
    float speed = 10f;

    Quaternion rotation;
    Quaternion rotLeft;
    Quaternion rotRight;

    Vector3 rotationV;
    Vector3 rotLeftV;
    Vector3 rotRightV;

    public float horizontal;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        car = transform.gameObject;
        rb = GetComponent<Rigidbody2D>();
        speed = Time.deltaTime;

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
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.AddForce(Vector2.up * -.08f, ForceMode2D.Force);

        float throttle = vertical;

        car.transform.position = new Vector3(car.transform.position.x + horizontal * speed, car.transform.position.y, 0);
        rb.AddForce(Vector2.up * throttle, ForceMode2D.Force);

        // if(car.transform.rotation != rotation) car.transform.rotation = Quaternion.RotateTowards(car.transform.rotation, rotation, step);

        if (horizontal > 0)
        {
            if (rb.rotation > -10) rb.rotation -= 0.5f;
            // Vector3 newDirection = Vector3.RotateTowards(car.transform.position, rotLeftV, step, 1f);
            // car.transform.rotation = Quaternion.LookRotation(newDirection);
        }
        if (horizontal < 0)
        {
            if (rb.rotation < 10) rb.rotation += 0.5f;
            // Vector3 newDirection = Vector3.RotateTowards(car.transform.position, rotRightV, step, 1f);
            // car.transform.rotation = Quaternion.LookRotation(newDirection);
        }

        if (car.transform.position.x < -10) car.transform.position = new Vector3(-10, car.transform.position.y, 0);
        if (car.transform.position.x > 10) car.transform.position = new Vector3(10, car.transform.position.y, 0);

        if (car.transform.position.y > 4) car.transform.position = new Vector3(car.transform.position.x, 4, 0);
        if (car.transform.position.y < -4) car.transform.position = new Vector3(car.transform.position.x, -4, 0);

    }
}
