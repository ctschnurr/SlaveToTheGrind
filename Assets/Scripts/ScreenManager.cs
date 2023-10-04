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

    static GameObject HUD;
    static TextMeshProUGUI playerHealth;
    static TextMeshProUGUI playerRanking;
    static TextMeshProUGUI boostStats;
    static TextMeshProUGUI bulletStats;
    static TextMeshProUGUI missleStats;
    static TextMeshProUGUI mineStats;
    static TextMeshProUGUI moneyText;
    static TextMeshProUGUI countDownText;

    static PlayerController playerController;
    int rank = 0;

    string place = " ";

    static bool ready = false;

    // Start is called before the first frame update
    public static void SetupScreens()
    {
        HUD = GameObject.Find("ScreenManager/HUD");
        playerHealth = GameObject.Find("ScreenManager/HUD/playerHealth").GetComponent<TextMeshProUGUI>();
        playerRanking = GameObject.Find("ScreenManager/HUD/playerRanking").GetComponent<TextMeshProUGUI>();
        boostStats = GameObject.Find("ScreenManager/HUD/boostStats").GetComponent<TextMeshProUGUI>();
        bulletStats = GameObject.Find("ScreenManager/HUD/bulletStats").GetComponent<TextMeshProUGUI>();
        missleStats = GameObject.Find("ScreenManager/HUD/missleStats").GetComponent<TextMeshProUGUI>();
        mineStats = GameObject.Find("ScreenManager/HUD/mineStats").GetComponent<TextMeshProUGUI>();
        moneyText = GameObject.Find("ScreenManager/HUD/money").GetComponent<TextMeshProUGUI>();
        countDownText = GameObject.Find("ScreenManager/HUD/countDown").GetComponent<TextMeshProUGUI>();
        countDownText.text = " ";

        playerController = GameObject.Find("PlayerRacer").GetComponent<PlayerController>();

        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(ready)
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

            rank = RaceManager.GetPlace();
            UpdateRank(rank);
        }
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

    public static void CountDown(string countDown)
    {
        countDownText.text = countDown;
    }
}
