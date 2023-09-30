using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSlick : Obstacle
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Racer")
        {
            Racer racer = other.gameObject.GetComponent<Racer>();
            racer.OilSlicked();
        }
    }
}
