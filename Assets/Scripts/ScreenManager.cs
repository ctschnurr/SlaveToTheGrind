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
    TextMeshProUGUI boostStats;
    TextMeshProUGUI bulletStats;
    TextMeshProUGUI missleStats;
    TextMeshProUGUI mineStats;
    TextMeshProUGUI moneyText;

    PlayerController playerController;
    int rank = 0;

    string place = " ";

    // Start is called before the first frame update
    void Start()
    {
        HUD = GameObject.Find("ScreenManager/HUD");
        playerHealth = GameObject.Find("ScreenManager/HUD/playerHealth").GetComponent<TextMeshProUGUI>();
        playerRanking = GameObject.Find("ScreenManager/HUD/playerRanking").GetComponent<TextMeshProUGUI>();
        boostStats = GameObject.Find("ScreenManager/HUD/boostStats").GetComponent<TextMeshProUGUI>();
        bulletStats = GameObject.Find("ScreenManager/HUD/bulletStats").GetComponent<TextMeshProUGUI>();
        missleStats = GameObject.Find("ScreenManager/HUD/missleStats").GetComponent<TextMeshProUGUI>();
        mineStats = GameObject.Find("ScreenManager/HUD/mineStats").GetComponent<TextMeshProUGUI>();
        moneyText = GameObject.Find("ScreenManager/HUD/money").GetComponent<TextMeshProUGUI>();


        playerController = GameObject.Find("PlayerRacer").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        int health = playerController.GetHealth();
        playerHealth.text = "Health: " + health;

        float[] boostInfo = playerController.GetBoostInfo();
        string tempString = boostInfo[1].ToString("0.00");
        string tempStringB = boostInfo[0].ToString("0.00");
        if (tempStringB == "0.00") tempStringB = "READY";
        boostStats.text = "Boost: " + tempStringB + "\nCooldown: " + tempString;

        float[] bulletInfo = playerController.GetBulletInfo();
        tempString = bulletInfo[1].ToString("0.00");
        bulletStats.text = "Bullets: " + bulletInfo[0] + "\nCooldown: " + tempString;

        float[] missleInfo = playerController.GetMissleInfo();
        tempString = missleInfo[1].ToString("0.00");
        missleStats.text = "Missles: " + missleInfo[0] + "\nCooldown: " + tempString;

        float[] mineInfo = playerController.GetMineInfo();
        tempString = mineInfo[1].ToString("0.00");
        mineStats.text = "Mines: " + mineInfo[0] + "\nCooldown: " + tempString;

        int money = playerController.GetMoney();
        moneyText.text = "$" + money;

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
