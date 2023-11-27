using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public enum SpawnChance
    {
        random,
        alwaysOn
    }

    public enum ItemToSpawn
    {
        random,
        money,
        repairKit
    }

    public SpawnChance spawnChance = SpawnChance.random;
    public ItemToSpawn itemToSpawn = ItemToSpawn.random;

    public GameObject money;
    public GameObject repairKit;
    private Transform spawnPoint;
    // Start is called before the first frame update
    public void SpawnPickup()
    {
        GameObject newPickup = null;

        if (spawnChance == SpawnChance.alwaysOn) newPickup = SpawnItem(itemToSpawn);

        if (spawnChance == SpawnChance.random)
        {
            int chanceToSpawn = Random.Range(0, GameManager.GameLevel + 1);

            if (chanceToSpawn == 0) newPickup = SpawnItem(itemToSpawn);
        }

        if(newPickup != null) TrackManager.Pickups.Add(newPickup);
    }

    private GameObject SpawnItem(ItemToSpawn item)
    {
        GameObject newPickup = null;

        switch (item)
        {
            case ItemToSpawn.money:
                newPickup = Instantiate(money, new Vector2(transform.position.x, transform.position.y + 2), transform.localRotation);
                break;

            case ItemToSpawn.repairKit:
                newPickup = Instantiate(repairKit, new Vector2(transform.position.x, transform.position.y + 2), transform.localRotation);
                break;

            case ItemToSpawn.random:
                int pickPickup = Random.Range(0, 3);

                if (pickPickup == 2) newPickup = Instantiate(repairKit, new Vector2(transform.position.x, transform.position.y + 2), transform.localRotation);
                else newPickup = Instantiate(money, new Vector2(transform.position.x, transform.position.y + 2), transform.localRotation);
                break;
        }

        return newPickup;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
