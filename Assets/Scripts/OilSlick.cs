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

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Racer")
        {
            Debug.Log(other.gameObject.name + " was slicked!");
            Racer racer = other.gameObject.GetComponent<Racer>();
            racer.OilSlicked();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Racer")
        {
            Racer racer = other.gameObject.GetComponent<Racer>();
            racer.OilSlicked();
            Debug.Log(other.gameObject.name + " was unslicked!");
        }
    }
}
