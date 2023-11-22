using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrackManager : MonoBehaviour
{

    public static List<GameObject> enemyWaypoints;
    static GameObject waypointFolder;

    static GameObject finishLine;

    private static List<GameObject> pickups;
    public static List<GameObject> Pickups { get { return pickups; } set { pickups = value; } }
    private static GameObject[] spawners;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // if(finishers.Count == racers.Count)
    }

    public static void SetupTrack()
    {
        spawners = GameObject.FindGameObjectsWithTag("PickupSpawner");
        pickups = new List<GameObject>();

        waypointFolder = GameObject.Find("Waypoints");

        int numberOfWaypoints = waypointFolder.transform.childCount;
        enemyWaypoints = new List<GameObject>();

        for (int i = 0; i < numberOfWaypoints; i++)
        {
            Transform tempTransform = waypointFolder.transform.GetChild(i);
            enemyWaypoints.Add(tempTransform.gameObject);
        }

        finishLine = enemyWaypoints[numberOfWaypoints - 1];

        foreach (GameObject waypoint in enemyWaypoints)
        {
            int point = enemyWaypoints.IndexOf(waypoint);
            if(point != enemyWaypoints.Count - 1)
            {
                Waypoint tempWaypoint = waypoint.GetComponent<Waypoint>();
                GameObject nextWaypoint = enemyWaypoints[point + 1];

                int choices = waypoint.transform.childCount;
                if (choices == 0)
                {
                    tempWaypoint.nextWaypoint = nextWaypoint;
                }
                else
                {
                    tempWaypoint.nextWaypoint = null;
                    for (int j = 0; j < choices; j++)
                    {
                        Transform tempChild = waypoint.transform.GetChild(j);
                        Waypoint childWaypoint = tempChild.transform.GetComponent<Waypoint>();
                        childWaypoint.nextWaypoint = nextWaypoint;
                    }
                }
            }
        }

        SpawnPickups();
    }

    public static GameObject SendNextWaypoint(GameObject last)
    {
        if (last == null) return enemyWaypoints[0];
        if (last != enemyWaypoints[enemyWaypoints.Count - 1])
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

    public static float GetFinishline()
    {
        return finishLine.transform.position.y;
    }

    public static void SpawnPickups()
    {
        foreach(GameObject spawner in spawners)
        {
            spawner.GetComponent<PickupSpawner>().SpawnPickup();
        }
    }

    public static void ResetTrack()
    {
        foreach(GameObject pickup in pickups)
        {
            Destroy(pickup);
        }
    }
}
