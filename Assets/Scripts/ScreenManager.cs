using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public enum Screen
    {
        title,
        instructions,
        loadSave,
        HUD,
        startRace,
        endRace,
        upgrades,
        pause
    }

    static Screen currentScreen = Screen.title;

    static List<GameObject> screensList;

    static GameObject titleScreen;
    static GameObject instructionsScreen;
    static GameObject upgradesScreen;

    static GameObject HUD;
    static TextMeshProUGUI playerHealth;
    static TextMeshProUGUI playerRanking;
    static TextMeshProUGUI boostStats;
    static TextMeshProUGUI bulletStats;
    static TextMeshProUGUI missleStats;
    static TextMeshProUGUI mineStats;
    static TextMeshProUGUI moneyText;
    static TextMeshProUGUI countDownText;

    static GameObject endRaceScreen;

    static TextMeshProUGUI rank1;
    static TextMeshProUGUI rank2;
    static TextMeshProUGUI rank3;
    static TextMeshProUGUI rank4;
    static List<TextMeshProUGUI> ranks;
    static PlayerController playerController;
    int rank = 0;

    static GameObject pauseScreen;

    string place = " ";

    static bool ready = false;

    // Start is called before the first frame update
    public static void SetupScreens()
    {
        titleScreen = GameObject.Find("ScreenManager/titleScreen");
        instructionsScreen = GameObject.Find("ScreenManager/instructionsScreen");
        upgradesScreen = GameObject.Find("ScreenManager/upgradesScreen");

        // HUD Objects
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
        // ---


        // END Race Screen
        endRaceScreen = GameObject.Find("ScreenManager/endRace");

        rank1 = GameObject.Find("ScreenManager/endRace/rank1").GetComponent<TextMeshProUGUI>();
        rank2 = GameObject.Find("ScreenManager/endRace/rank2").GetComponent<TextMeshProUGUI>();
        rank3 = GameObject.Find("ScreenManager/endRace/rank3").GetComponent<TextMeshProUGUI>();
        rank4 = GameObject.Find("ScreenManager/endRace/rank4").GetComponent<TextMeshProUGUI>();

        ranks = new List<TextMeshProUGUI> { rank1, rank2, rank3, rank4 };
        // ---

        pauseScreen = GameObject.Find("ScreenManager/pause");

        screensList = new List<GameObject> { titleScreen, instructionsScreen, upgradesScreen, HUD, endRaceScreen, pauseScreen };

        ClearScreens();
        
        titleScreen.SetActive(true);

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
            if (tempString == "0.00" && tempStringB == "0.00") tempStringB = "READY";
            else if (tempStringB == "0.00" && tempString != "0.00") tempStringB = "CHARGING";
            boostStats.text = "Boost: " + tempStringB;

            float[] bulletInfo = playerController.GetBulletInfo();
            tempString = bulletInfo[1].ToString("0.00");
            bulletStats.text = "Bullets: " + bulletInfo[0] + " : " + tempString;

            float[] missleInfo = playerController.GetMissleInfo();
            tempString = missleInfo[1].ToString("0.00");
            missleStats.text = "Missles: " + missleInfo[0] + " : " + tempString;

            float[] mineInfo = playerController.GetMineInfo();
            tempString = mineInfo[1].ToString("0.00");
            mineStats.text = "Mines: " + mineInfo[0] + " : " + tempString;

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
            case 0:
                place = " ";
                break;
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


    public static void SetScreen(Screen screen)
    {
        ClearScreens();

        switch (screen)
        {
            case Screen.title:
                if (!titleScreen.activeSelf) titleScreen.SetActive(true);
                break;

            case Screen.instructions:
                if (!instructionsScreen.activeSelf) instructionsScreen.SetActive(true);
                break;

            case Screen.HUD:
                if (!HUD.activeSelf) HUD.SetActive(true);
                break;

            case Screen.endRace:
                if (!endRaceScreen.activeSelf) endRaceScreen.SetActive(true);
                SetupEndRaceScreen();
                break;

            case Screen.pause:
                if (!pauseScreen.activeSelf) pauseScreen.SetActive(true);
                break;
        }
    }

    static void ClearScreens()
    {
        foreach (GameObject screen in screensList) { if(screen.activeSelf) screen.SetActive(false); }
    }

    protected static void SetupEndRaceScreen()
    {
        List<Racer> racers = RaceManager.GetRankings();

        for (int i = 0; i < racers.Count; i++)
        {
            string place = " ";
            switch (i)
            {
                case 0:
                    place = "1ST";
                    break;

                case 1:
                    place = "2ND";
                    break;

                case 2:
                    place = "3RD";
                    break;

                case 3:
                    place = "4TH";
                    break;
            }

            Racer racer = racers[i];
            Racer.State racerState = racer.GetState();
            if (racerState == Racer.State.finished) ranks[i].text = place + " - " + racer.name;
            else if (racerState == Racer.State.dead) ranks[i].text = "DNF - " + racer.name;
        }
    }
}
