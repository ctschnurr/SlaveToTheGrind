using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Money : PickUp
{

    protected int value;
    // Start is called before the first frame update
    void Awake()
    {
        value = 25;

        gameObject.name = "Money";
        gameObject.tag = "PickUp";
        //rb = gameObject.GetComponent<Rigidbody2D>();
        //cone = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void PickMeUp(GameObject car)
    {
        Racer racer = car.GetComponent<Racer>();
        racer.AddMoney(value);
        Destroy(gameObject);
    }
}
