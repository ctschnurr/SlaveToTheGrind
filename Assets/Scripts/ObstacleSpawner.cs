using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public enum SpawnChance
    {
        random,
        alwaysOn
    }

    public enum ObstacleToSpawn
    {
        random,
        cone,
        barrel,
        oilSlick
    }

    public SpawnChance spawnChance = SpawnChance.alwaysOn;
    public ObstacleToSpawn obsToSpawn = ObstacleToSpawn.random;

    public GameObject cone;
    public GameObject barrel;
    public GameObject oilSlick;

    // Start is called before the first frame update
    public void SpawnObs()
    {
        GameObject newObstacle = null;

        if (spawnChance == SpawnChance.alwaysOn) newObstacle = SpawnItem(obsToSpawn);

        if (spawnChance == SpawnChance.random)
        {
            int chanceToSpawn = Random.Range(0, GameManager.GameLevel + 1);

            if (chanceToSpawn > 0) newObstacle = SpawnItem(obsToSpawn);
        }

        if (newObstacle != null) TrackManager.Obstacles.Add(newObstacle);
    }

    private GameObject SpawnItem(ObstacleToSpawn item)
    {
        GameObject newPickup = null;

        switch (item)
        {
            case ObstacleToSpawn.cone:
                newPickup = Instantiate(cone, transform.position, transform.localRotation);
                break;

            case ObstacleToSpawn.barrel:
                newPickup = Instantiate(barrel, transform.position, transform.localRotation);
                break;

            case ObstacleToSpawn.oilSlick:
                newPickup = Instantiate(oilSlick, transform.position, transform.localRotation);
                break;

            case ObstacleToSpawn.random:
                int pickPickup = Random.Range(0, 3);

                if (pickPickup == 1) newPickup = Instantiate(cone, transform.position, transform.localRotation);
                if (pickPickup == 2) newPickup = Instantiate(barrel, transform.position, transform.localRotation);
                if (pickPickup == 3) newPickup = Instantiate(oilSlick, transform.position, transform.localRotation);
                break;
        }

        return newPickup;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
