using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    protected int spawnX;
    protected int spawnY;
    protected Rigidbody2D rb;
    public Obstacle()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Racer")
        {
            HitMe(collision.gameObject, collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude);
        }
    }

    public virtual void HitMe(GameObject car, float force)
    {

    }
}
