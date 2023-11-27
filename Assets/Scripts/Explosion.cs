using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Weapon
{
    float expandSpeed = 80f;
    ParticleSystem particles;
    Vector3 scaleChange;
    public AudioSource explosionSound;
    // Start is called before the first frame update
    void Awake()
    {
        scaleChange = new Vector3(expandSpeed, expandSpeed, expandSpeed);
        owner = null;
        if (transform.parent != null) owner = transform.parent.GetComponent<Racer>();
        transform.parent = null;
        particles = transform.Find("Particles").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 10) transform.localScale += scaleChange * Time.deltaTime;
        if (!explosionSound.isPlaying) Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Racer")
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            Vector3 direction = transform.position - collision.gameObject.transform.position;
            Rigidbody2D colRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (collision.gameObject.tag != "Wall") colRb.AddForce(direction, ForceMode2D.Impulse);
        }
    }
}
