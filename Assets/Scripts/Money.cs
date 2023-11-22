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
        pickupSound = transform.GetComponent<AudioSource>();
        value = 25;

        gameObject.name = "Money";
        gameObject.tag = "PickUp";
    }

    public override void PickMeUp(GameObject car)
    {
        base.PickMeUp(car);
        Racer racer = car.GetComponent<Racer>();
        racer.AddMoney(value);
    }
}
