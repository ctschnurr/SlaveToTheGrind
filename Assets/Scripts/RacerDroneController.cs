using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerDroneController : MonoBehaviour
{

    public static bool activated = true;

    public static List<GameObject> drones;

    public GameObject droneRacer;

    static List<Color> colors = new() { Color.red, Color.blue, Color.green, Color.yellow };
    static List<Color> colorsList = new() { Color.red, Color.blue, Color.green, Color.yellow };
    // Start is called before the first frame update
    void Start()
    {
        drones = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(drones.Count == 0)
        {
            for(int i = 0; i < 4; i++)
            {
                GameObject newDrone = Instantiate(droneRacer, new Vector3(-5 + (i * 5), 0, 0), transform.localRotation);

                //int pickColor = Random.Range(0, colorsList.Count);

                //newDrone.GetComponent<RacerDrone>().CarColor.color = colorsList[pickColor];
                //colorsList.Remove(colorsList[pickColor]);

                drones.Add(newDrone);
            }
            colorsList = colors;
        }
    }
}
