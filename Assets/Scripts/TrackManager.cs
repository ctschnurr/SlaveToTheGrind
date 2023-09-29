using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public List<Transform> obstacleSpawnPoints;
    // Start is called before the first frame update
    public TrackManager()
    {
        obstacleSpawnPoints = new List<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
