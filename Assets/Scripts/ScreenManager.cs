using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    enum Screen
    {
        HUD
    }

    GameObject HUD;
    TextMeshProUGUI playerHealth;
    TextMeshProUGUI playerRanking;
    PlayerController playerController;
    int rank = 0;

    string place = " ";

    // Start is called before the first frame update
    void Start()
    {
        HUD = GameObject.Find("ScreenManager/HUD");
        playerHealth = GameObject.Find("ScreenManager/HUD/playerHealth").GetComponent<TextMeshProUGUI>();
        playerRanking = GameObject.Find("ScreenManager/HUD/playerRanking").GetComponent<TextMeshProUGUI>();

        playerController = GameObject.Find("PlayerRacer").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        int health = playerController.GetHealth();
        playerHealth.text = "Health: " + health;
        rank = TrackManager.GetPlace();
        UpdateRank(rank);
    }

    void UpdateRank(int input)
    {
        switch (input)
        {
            case 1:
                place = "1ST";
                break;

            case 2:
                place = "2ND";
                break;

            case 3:
                place = "3RD";
                break;

            case 4:
                place = "4TH";
                break;
        }

        playerRanking.text = place;
    }
}
