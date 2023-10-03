using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
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

    public virtual void PickMeUp(GameObject car)
    {

    }
}
