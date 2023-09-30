using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

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
        if(collision.gameObject.tag == "Racer" || collision.gameObject.name == "Bullet" || collision.gameObject.tag == "Explosion")
        {
            HitMe(collision.gameObject);
        }
    }

    public virtual void HitMe(GameObject car)
    {

    }
}
