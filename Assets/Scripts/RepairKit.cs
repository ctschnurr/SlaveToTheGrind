using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RepairKit : PickUp
{

    protected int value;
    PlayerController player;
    // Start is called before the first frame update
    void Awake()
    {
        pickupSound = transform.GetComponent<AudioSource>();
        player = GameObject.Find("PlayerRacer").GetComponent<PlayerController>();

        value = 5;
        value += 1 * player.RepairSkillLevel;

        gameObject.name = "RepairKit";
        gameObject.tag = "PickUp";
        //rb = gameObject.GetComponent<Rigidbody2D>();
        //cone = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void PickMeUp(GameObject car)
    {
        particles.Play();
        base.PickMeUp(car);
        Racer racer = car.GetComponent<Racer>();
        racer.AddHealth(value);
    }
}
