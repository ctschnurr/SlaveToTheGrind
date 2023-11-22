using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    protected AudioSource pickupSound;
    protected bool pickedUp = false;
    public SpriteRenderer sprite;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Racer")
        {
            Racer racer = other.gameObject.GetComponent<Racer>();
            PickMeUp(other.gameObject);
        }
    }

    void Update()
    {
        if (pickedUp) if (!pickupSound.isPlaying) Destroy(gameObject);
    }

    public virtual void PickMeUp(GameObject car)
    {
        transform.GetComponent<CircleCollider2D>().enabled = false;
        sprite.enabled = false;
        pickupSound.Play();
        pickedUp = true;
    }
}
