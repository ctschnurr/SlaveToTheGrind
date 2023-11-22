using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public enum Level
    {
        Level4,
        Level3,
        Level2,
        Level1
    }

    public GameObject money;
    public GameObject repairKit;
    private Transform spawnPoint;
    // Start is called before the first frame update
    public void SpawnPickup()
    {
        int chanceToSpawn = Random.Range(0, GameManager.GameLevel + 1);

        if (chanceToSpawn == 0)
        {
            int pickPickup = Random.Range(0, 3);

            GameObject newPickup;

            if (pickPickup == 2) newPickup = Instantiate(repairKit, new Vector2(transform.position.x, transform.position.y + 2), transform.localRotation);
            else newPickup = Instantiate(money, new Vector2(transform.position.x, transform.position.y + 2), transform.localRotation);

            TrackManager.Pickups.Add(newPickup);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
