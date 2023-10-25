using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using static Globals;

public class ScreenManager : MonoBehaviour
{
    public enum Screen
    {
        title,
        instructions,
        loadSave,
        HUD,
        startRace,
        finish,
        defeat,
        endRace,
        earnings,
        upgrades,
        pause
    }

    public enum UpgradeScreen
    {
        car,
        racer,
        ammo
    }

    // Upgrade screen elements:
    static GameObject upgradeSelect;

    static GameObject engine1check;

    static GameObject engine2lock;
    static GameObject engine2check;

    static GameObject engine3lock;
    static GameObject engine3check;

    static GameObject armour1check;

    static GameObject armour2lock;
    static GameObject armour2check;

    static GameObject armour3lock;
    static GameObject armour3check;


    static GameObject repair2lock;
    static GameObject repair3lock;
         
    static GameObject speech2lock;
    static GameObject speech3lock;

    static List<GameObject> iconList;

    static TextMeshProUGUI upgradeName;
    static TextMeshProUGUI upgradeDescription;
    static TextMeshProUGUI upgradePrice;
    static TextMeshProUGUI playerFunds;
    static TextMeshProUGUI upgradeStatus;
    static GameObject purchaseButton;

    //

    static Screen lastScreen = Screen.title;
    static Screen currentScreen = Screen.title;
    static Screen nextScreen = Screen.title;

    static List<GameObject> screensList;

    static GameObject titleScreen;
    static GameObject instructionsScreen;
    static GameObject upgradesScreen;
    static GameObject carUpgradesScreen;
    static GameObject racerUpgradesScreen;
    static GameObject ammoShopScreen;

    static GameObject HUD;
    static TextMeshProUGUI playerHealth;
    static TextMeshProUGUI playerRanking;
    static TextMeshProUGUI boostStats;
    static TextMeshProUGUI bulletStats;
    static TextMeshProUGUI missleStats;
    static TextMeshProUGUI mineStats;
    static TextMeshProUGUI moneyText;
    static TextMeshProUGUI countDownText;

    static GameObject finishScreen;
    static GameObject defeatScreen;
    static GameObject raceResultsScreen;
    static GameObject earningsScreen;
    static TextMeshProUGUI earningsText;
    static string earningsReport;

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

    static bool timerOn = false;
    static float timer = 0;

    // Start is called before the first frame update
    public static void SetupScreens()
    {
        titleScreen = GameObject.Find("ScreenManager/titleScreen");
        instructionsScreen = GameObject.Find("ScreenManager/instructionsScreen");
        upgradesScreen = GameObject.Find("ScreenManager/UpgradesTitle");
        carUpgradesScreen = GameObject.Find("ScreenManager/CarUpgrades");
        racerUpgradesScreen = GameObject.Find("ScreenManager/RacerUpgrades");
        ammoShopScreen = GameObject.Find("ScreenManager/AmmoShop");

        // Upgrade Screen Elements
        upgradeSelect = GameObject.Find("ScreenManager/UpgradesTitle/Select");

        engine1check = GameObject.Find("ScreenManager/CarUpgrades/ButtonsPanel/EngineUpgrades/Upgrade1/Check");

        engine2lock = GameObject.Find("ScreenManager/CarUpgrades/ButtonsPanel/EngineUpgrades/Upgrade2/Lock");
        engine2check = GameObject.Find("ScreenManager/CarUpgrades/ButtonsPanel/EngineUpgrades/Upgrade2/Check");

        engine3lock = GameObject.Find("ScreenManager/CarUpgrades/ButtonsPanel/EngineUpgrades/Upgrade3/Lock");
        engine3check = GameObject.Find("ScreenManager/CarUpgrades/ButtonsPanel/EngineUpgrades/Upgrade3/Check");

        armour1check = GameObject.Find("ScreenManager/CarUpgrades/ButtonsPanel/ArmourUpgrades/Upgrade1/Check");

        armour2lock = GameObject.Find("ScreenManager/CarUpgrades/ButtonsPanel/ArmourUpgrades/Upgrade2/Lock");
        armour2check = GameObject.Find("ScreenManager/CarUpgrades/ButtonsPanel/ArmourUpgrades/Upgrade2/Check");

        armour3lock = GameObject.Find("ScreenManager/CarUpgrades/ButtonsPanel/ArmourUpgrades/Upgrade3/Lock");
        armour3check = GameObject.Find("ScreenManager/CarUpgrades/ButtonsPanel/ArmourUpgrades/Upgrade3/Check");

        iconList = new List<GameObject> { engine1check, engine2lock, engine2check, engine3lock, engine3check, armour1check, armour2lock, armour2check, armour3lock, armour3check };
        // repair2lock
        // repair3lock
        // 
        // 
        // speech2lock
        // speech3lock

        upgradeName = GameObject.Find("ScreenManager/UpgradesTitle/DescriptionPanel/UpgradeName").GetComponent<TextMeshProUGUI>();
        upgradeDescription = GameObject.Find("ScreenManager/UpgradesTitle/DescriptionPanel/UpgradeDescription").GetComponent<TextMeshProUGUI>();
        upgradePrice = GameObject.Find("ScreenManager/UpgradesTitle/DescriptionPanel/UpgradePrice").GetComponent<TextMeshProUGUI>();
        playerFunds = GameObject.Find("ScreenManager/UpgradesTitle/DescriptionPanel/PlayerFunds").GetComponent<TextMeshProUGUI>();
        upgradeStatus = GameObject.Find("ScreenManager/UpgradesTitle/DescriptionPanel/UpgradeStatus").GetComponent<TextMeshProUGUI>();

        purchaseButton = GameObject.Find("ScreenManager/UpgradesTitle/DescriptionPanel/PurchaseButton");

        // ---

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


        // END Race Sequence

        finishScreen = GameObject.Find("ScreenManager/finishScreen");
        defeatScreen = GameObject.Find("ScreenManager/defeatScreen");

        raceResultsScreen = GameObject.Find("ScreenManager/RaceResults");
        earningsScreen = GameObject.Find("ScreenManager/Earnings");

        earningsText = GameObject.Find("ScreenManager/Earnings/EarningsText").GetComponent<TextMeshProUGUI>();

        rank1 = GameObject.Find("ScreenManager/RaceResults/rank1").GetComponent<TextMeshProUGUI>();
        rank2 = GameObject.Find("ScreenManager/RaceResults/rank2").GetComponent<TextMeshProUGUI>();
        rank3 = GameObject.Find("ScreenManager/RaceResults/rank3").GetComponent<TextMeshProUGUI>();
        rank4 = GameObject.Find("ScreenManager/RaceResults/rank4").GetComponent<TextMeshProUGUI>();

        ranks = new List<TextMeshProUGUI> { rank1, rank2, rank3, rank4 };
        // ---

        pauseScreen = GameObject.Find("ScreenManager/pause");

        screensList = new List<GameObject> { titleScreen, instructionsScreen, upgradesScreen, HUD, finishScreen, defeatScreen, raceResultsScreen, earningsScreen, pauseScreen, carUpgradesScreen, racerUpgradesScreen, ammoShopScreen };

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

            int money = playerController.GetCurrentRaceEarnings();
            moneyText.text = "$" + money;

            rank = RaceManager.GetPlace();
            UpdateRank(rank);
        }

        if(timerOn)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                SetScreen(nextScreen);
                timerOn = false;
            }
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

            case Screen.upgrades:
                if (!upgradesScreen.activeSelf) upgradesScreen.SetActive(true);
                UpdateUpgradeIcons();
                Upgrade temp = UpgradeManager.GetCurrentUpgrade();
                UpdateUpgradeClicked(temp);
                break;

            case Screen.HUD:
                if (!HUD.activeSelf) HUD.SetActive(true);
                break;

            case Screen.finish:
                if (!finishScreen.activeSelf) finishScreen.SetActive(true);
                nextScreen = Screen.endRace;
                timer = 3;
                timerOn = true;
                break;

            case Screen.defeat:
                if (!defeatScreen.activeSelf) defeatScreen.SetActive(true);
                nextScreen = Screen.endRace;
                timer = 3;
                timerOn = true;
                break;

            case Screen.endRace:
                if (!raceResultsScreen.activeSelf) raceResultsScreen.SetActive(true);
                SetupEndRaceScreen();
                SetupEarningsScreen();
                break;

            case Screen.earnings:
                if (!earningsScreen.activeSelf) earningsScreen.SetActive(true);
                break;

            case Screen.pause:
                if (!pauseScreen.activeSelf) pauseScreen.SetActive(true);
                break;
        }

        lastScreen = currentScreen;
        currentScreen = screen;
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
            Racer.State racerState = racer.RacerState;
            string racerName = racer.GetName();
            if (racerState == Racer.State.finished) ranks[i].text = place + " - " + racerName;
            else if (racerState == Racer.State.dead) ranks[i].text = "DNF - " + racerName;
        }
    }

    protected static void SetupEarningsScreen()
    {
        Racer.State racerState = playerController.RacerState;
        int raceEarnings = 0;

        int place = -1;
        if (racerState != Racer.State.dead)
        {
            List<Racer> finishers = RaceManager.GetRankings();
            place = finishers.IndexOf(playerController);
        }

        switch (place)
        {
            case 0:
                earningsReport = "First Place! +$" + firstPlaceReward + "\n";
                raceEarnings += firstPlaceReward;
                break;

            case 1:
                earningsReport = "Second Place! +$" + secondPlaceReward + "\n";
                raceEarnings += secondPlaceReward;
                break;

            case 2:
                earningsReport = "Third Place! +$" + thirdPlaceReward + "\n";
                raceEarnings += thirdPlaceReward;
                break;

            case 3:
                earningsReport = "Fourth Place! +$" + fourthPlaceReward + "\n";
                raceEarnings += fourthPlaceReward;
                break;

            default:
                earningsReport = "Participation Reward! +$" + participationReward + "\n";
                raceEarnings += participationReward;
                break;
        }

        int moneyThisRace = playerController.GetEarnings();

        if(moneyThisRace > 0)
        {
            earningsReport += "Money Collected! +$" + moneyThisRace + "\n";
            raceEarnings += moneyThisRace;
        }

        List<Racer> defeated = playerController.GetDefeated();

        if(defeated != null)
        {
            if (defeated.Count > 0)
            {
                foreach (Racer racer in defeated)
                {
                    earningsReport += "Defeated " + racer.GetName() + "! +$" + eliminationReward + "\n";
                    raceEarnings += eliminationReward;
                }
            }
        }

        earningsReport += "\nTotal Earnings: $" + raceEarnings;

        earningsText.text = earningsReport;
        playerController.PayRacer(raceEarnings);
    }

    public static void UpdateUpgradeIcons()
    {
        carUpgradesScreen.SetActive(true);
        racerUpgradesScreen.SetActive(true);
        ammoShopScreen.SetActive(true);

        int engineLevel = playerController.GetEngineLevel();
        int armourLevel = playerController.GetArmourLevel();

        foreach (GameObject icon in iconList)
        {
            icon.SetActive(false);
        }

        switch(engineLevel)
        {
            case 0:
                engine2lock.SetActive(true);
                engine3lock.SetActive(true);
                break;
            case 1:
                engine1check.SetActive(true);
                engine3lock.SetActive(true);
                break;
            case 2:
                engine1check.SetActive(true);
                engine2check.SetActive(true);
                break;
            case 3:
                engine1check.SetActive(true);
                engine2check.SetActive(true);
                engine3check.SetActive(true);
                break;
        }

        switch (armourLevel)
        {
            case 0:
                armour2lock.SetActive(true);
                armour3lock.SetActive(true);
                break;
            case 1:
                armour1check.SetActive(true);
                armour3lock.SetActive(true);
                break;
            case 2:
                armour1check.SetActive(true);
                armour2check.SetActive(true);
                break;
            case 3:
                armour1check.SetActive(true);
                armour2check.SetActive(true);
                armour3check.SetActive(true);
                break;
        }

        racerUpgradesScreen.SetActive(false);
        ammoShopScreen.SetActive(false);
    }

    public static void UpdateUpgradeClicked(Upgrade input)
    {
        UpdateSelectedIcon(input);

        upgradeName.text = input.name;
        upgradeDescription.text = input.description;
        upgradePrice.text = "Upgrade Price: $" + input.price.ToString();
        playerFunds.text = "Your Funds: $" + playerController.GetMoney();


        switch (input.state)
        {
            case Upgrade.State.available:
                if(playerController.GetMoney() >= input.price)
                {
                    if (!purchaseButton.activeSelf) purchaseButton.SetActive(true);
                    if (upgradeStatus.gameObject.activeSelf) upgradeStatus.gameObject.SetActive(false);
                }
                else
                {
                    if (purchaseButton.activeSelf) purchaseButton.SetActive(false);
                    if (!upgradeStatus.gameObject.activeSelf) upgradeStatus.gameObject.SetActive(true);
                    upgradeStatus.text = "Insufficient Funds";
                }
                break;

            case Upgrade.State.owned:
                if (purchaseButton.activeSelf) purchaseButton.SetActive(false);
                if (!upgradeStatus.gameObject.activeSelf) upgradeStatus.gameObject.SetActive(true);
                upgradeStatus.text = "Owned";
                break;

            case Upgrade.State.equipped:
                if (purchaseButton.activeSelf) purchaseButton.SetActive(false);
                if (!upgradeStatus.gameObject.activeSelf) upgradeStatus.gameObject.SetActive(true);
                upgradeStatus.text = "Equipped";
                break;
            case Upgrade.State.locked:
                if (purchaseButton.activeSelf) purchaseButton.SetActive(false);
                if (!upgradeStatus.gameObject.activeSelf) upgradeStatus.gameObject.SetActive(true);
                upgradeStatus.text = "Locked";
                break;
        }
    }

    static void UpdateSelectedIcon(Upgrade input)
    {
        if (!upgradeSelect.activeSelf) upgradeSelect.SetActive(true);

        switch(input.category)
        {
            case Upgrade.Category.engine:
                if (input.upgradeNumber == 1) upgradeSelect.transform.position = engine1check.transform.position;
                if (input.upgradeNumber == 2) upgradeSelect.transform.position = engine2lock.transform.position;
                if (input.upgradeNumber == 3) upgradeSelect.transform.position = engine3lock.transform.position;
                break;
        }
    }

    // Button Functions
    public void GoToInstructions()
    {
        SetScreen(Screen.instructions);
    }
    public void GoToEarnings()
    {
        SetScreen(Screen.earnings);
    }

    public void GoToUpgrades()
    {
        SetScreen(Screen.upgrades);
    }
    public void ShowCarUpgradesScreen()
    {
        if (racerUpgradesScreen.activeSelf) racerUpgradesScreen.SetActive(false);
        if (ammoShopScreen.activeSelf) ammoShopScreen.SetActive(false);
        if (!carUpgradesScreen.activeSelf) carUpgradesScreen.SetActive(true);
    }

    public void ShowRacerUpgradesScreen()
    {
        if (carUpgradesScreen.activeSelf) carUpgradesScreen.SetActive(false);
        if (ammoShopScreen.activeSelf) ammoShopScreen.SetActive(false);
        if (!racerUpgradesScreen.activeSelf) racerUpgradesScreen.SetActive(true);
    }

    public void ShowAmmoShopScreen()
    {
        if (carUpgradesScreen.activeSelf) carUpgradesScreen.SetActive(false);
        if (racerUpgradesScreen.activeSelf) racerUpgradesScreen.SetActive(false);
        if (!ammoShopScreen.activeSelf) ammoShopScreen.SetActive(true);
    }
}
