using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static PickupSpawner;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    protected Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HitMe(collision.gameObject);
    }

    public virtual void HitMe(GameObject car)
    {

    }
}
