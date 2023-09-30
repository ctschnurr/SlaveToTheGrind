using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    protected int spawnX;
    protected int spawnY;
    protected Rigidbody2D rb;

    protected enum Behavior
    {
        bullet,
        rocket,
        mine
    }
    public Weapon()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void HitYou(GameObject car)
    {

    }
}
