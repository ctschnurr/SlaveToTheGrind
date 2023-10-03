using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public List<Transform> obstacleSpawnPoints;
    public static List<GameObject> enemyWaypoints;
    static GameObject waypointFolder;
    static List<GameObject> racers;
    static List<GameObject> racersCopy;
    static List<GameObject> ranking;
    static GameObject player1;
    static GameObject player2;
    static GameObject player3;
    static GameObject player4;

    static GameObject ranker;

    static GameObject finishLine; // will have to update this as the track grows

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SetupTrack()
    {
        // obstacleSpawnPoints = new List<Transform>();

        // will likely substantiate racers in the future
        player1 = GameObject.Find("PlayerRacer");
        player2 = GameObject.Find("EnemyRacer1");
        player3 = GameObject.Find("EnemyRacer2");
        player4 = GameObject.Find("EnemyRacer3");

        racers = new List<GameObject>();
        racersCopy = new List<GameObject>();

        racers.Add(player1);
        racers.Add(player2);
        racers.Add(player3);
        racers.Add(player4);

        ranking = new List<GameObject>(racers);

        waypointFolder = GameObject.Find("Waypoints");

        int numberOfWaypoints = waypointFolder.transform.childCount;
        enemyWaypoints = new List<GameObject>();

        for (int i = 0; i < numberOfWaypoints; i++)
        {
            Transform tempTransform = waypointFolder.transform.GetChild(i);
            enemyWaypoints.Add(tempTransform.gameObject);
        }

        finishLine = enemyWaypoints[numberOfWaypoints - 1];
        enemyWaypoints[0].name = "FirstPoint";

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
                        //GameObject childObject = tempChild.GetComponent<GameObject>();
                        Waypoint childWaypoint = tempChild.transform.GetComponent<Waypoint>();
                        childWaypoint.nextWaypoint = nextWaypoint;
                    }
                }
            }
        }

        foreach (GameObject racer in racers)
        {
            Racer temp = racer.GetComponent<Racer>();
            temp.SetupRacer();
        }
    }
    public static int GetPlace()
    {
        racersCopy = new List<GameObject>(racers);

        ranking = new List<GameObject>();

        while (racersCopy.Count > 0)
        {
            float closest = Mathf.Infinity;
            foreach (GameObject racer in racersCopy)
            {
                float distanceToEnd = Vector2.Distance(racer.transform.position, new Vector2(racer.transform.position.x, finishLine.transform.position.y));
                if (distanceToEnd < closest)
                {
                    ranker = racer;
                    closest = distanceToEnd;
                }

            }
            racersCopy.Remove(ranker);
            ranking.Add(ranker);
        }

        int place;
        place = ranking.IndexOf(player1);
        place++;
        return place;
    }

    public static List<GameObject> GetRacers()
    {
        return racers;
    }

    public static GameObject SendNextWaypoint(GameObject last)
    {
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
}
