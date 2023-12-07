using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerDroneController : MonoBehaviour
{
    public static List<GameObject> waypoints;
    static GameObject waypointFolder;

    protected bool timerActive = false;
    protected float timer = 1;

    public static bool activated = false;

    public static List<GameObject> drones;

    public GameObject droneRacer;

    static List<Color> colors = new() { Color.red, Color.blue, Color.green, Color.yellow };
    static List<Color> colorsList = new() { Color.red, Color.blue, Color.green, Color.yellow };
    // Start is called before the first frame update
    void Start()
    {
        drones = new List<GameObject>();

        waypointFolder = GameObject.Find("Waypoints");

        int numberOfWaypoints = waypointFolder.transform.childCount;
        waypoints = new List<GameObject>();

        for (int i = 0; i < numberOfWaypoints; i++)
        {
            Transform tempTransform = waypointFolder.transform.GetChild(i);
            waypoints.Add(tempTransform.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (drones.Count == 0 && timerActive == false) timerActive = true;

        if(timerActive)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                SpawnDrones();
                timerActive = false;
                timer = 1;
            }
        }
    }

    void SpawnDrones()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject newDrone = Instantiate(droneRacer, new Vector3(-6f + (i * 3), -30, 0), transform.localRotation);

            int pickColor = Random.Range(0, colorsList.Count);

            newDrone.GetComponent<RacerDrone>().CarColor.color = colorsList[pickColor];
            colorsList.Remove(colorsList[pickColor]);

            drones.Add(newDrone);
        }

        colorsList = new List<Color>(colors);
    }

    public static GameObject SendNextWaypoint(GameObject last)
    {
        // if (last == null) return waypoints[0];
        if (last != waypoints[waypoints.Count - 1])
        {
            Waypoint tempWaypoint = last.GetComponent<Waypoint>();
            GameObject tempObject = tempWaypoint.nextWaypoint;
            int choices = last.transform.childCount;

            if (choices > 0)
            {
                Transform tempTransform = last.transform.GetChild(Random.Range(0, choices));
                return tempTransform.gameObject;
            }
            else return tempObject;
        }
        else return null;
    }
}
