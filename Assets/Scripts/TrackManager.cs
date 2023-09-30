using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public List<Transform> obstacleSpawnPoints;
    static List<GameObject> racers;
    static List<GameObject> racersCopy;
    static List<GameObject> ranking;
    static GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    static GameObject ranker;

    static GameObject waypoint; // will have to update this as the track grows

    // Start is called before the first frame update
    void Awake()
    {
        obstacleSpawnPoints = new List<Transform>();
        waypoint = GameObject.Find("TrackManager/Waypoints/waypoint");

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
    }

    // Update is called once per frame
    void Update()
    {

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
                float distanceToEnd = Vector2.Distance(racer.transform.position, new Vector2(racer.transform.position.x, waypoint.transform.position.y));
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
}
