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
        customizePlayer,
        HUD,
        raceStart,
        finish,
        defeat,
        endRace,
        earnings,
        upgrades,
        saveSlot,
        confirmDelete,
        story,
        controls,
        pause
    }

    public enum UpgradeScreen
    {
        car,
        racer,
        ammo
    }

    static GameObject titleScreen;
    static GameObject instructionsScreen;
    static GameObject upgradesScreen;
    static GameObject storyScreen;
    static GameObject controlsScreen;
    static GameObject raceStartScreen;

    // Save slot screen elements:
    static GameObject saveSlotScreen;

    static GameObject slot1NewPanel;
    static GameObject slot2NewPanel;
    static GameObject slot3NewPanel;

    static GameObject slot1ContinuePanel;
    static TextMeshProUGUI slot1RacerMoney;
    static TextMeshProUGUI slot1RacerName;
    static Image slot1RacerColor;
    static GameObject slot1bronze;
    static GameObject slot1silver;
    static GameObject slot1gold;

    static GameObject slot2ContinuePanel;
    static TextMeshProUGUI slot2RacerMoney;
    static TextMeshProUGUI slot2RacerName;
    static Image slot2RacerColor;
    static GameObject slot2bronze;
    static GameObject slot2silver;
    static GameObject slot2gold;

    static GameObject slot3ContinuePanel;
    static TextMeshProUGUI slot3RacerMoney;
    static TextMeshProUGUI slot3RacerName;
    static Image slot3RacerColor;
    static GameObject slot3bronze;
    static GameObject slot3silver;
    static GameObject slot3gold;

    static List<GameObject> slotPanels;
    static List<GameObject> trophiesForSaveScreen;

    static GameObject confirmDelete;
    public static GameObject ConfirmDelete { get { return confirmDelete; } }
    // ---

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

    static GameObject boostSpeed1check;

    static GameObject boostCooldown1check;

    static GameObject boostRecharge1check;

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
    public static Screen LastScreen { get { return lastScreen; } }
    static Screen currentScreen = Screen.title;
    static Screen nextScreen = Screen.title;

    static List<GameObject> screensList;

    static GameObject customizePlayer;
    static TMP_InputField playerNameInput;
    public static TMP_InputField PlayerNameInput { get { return playerNameInput; } }
    static TextMeshProUGUI playerExampleName;
    public static TextMeshProUGUI PlayerExampleName { get { return playerExampleName; } }
    static Image playerExampleColor;
    public static Image PlayerExampleColor { get { return playerExampleColor; } }

    static Color red;
    static Color blue;
    static Color green;
    static Color yellow;

    protected static List<Color> colors = new() { Color.red, Color.blue, Color.green, Color.yellow};
    public static List<Color> Colors { get { return colors; } set { colors = value; } }

    static GameObject HUD;
    static TextMeshProUGUI playerRanking;
    static TextMeshProUGUI moneyText;
    static TextMeshProUGUI countDownText;
    static Image bulletCooldown;
    static Image missleCooldown;
    static Image mineCooldown;

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
    void Update()
    {
        if (ready && GameManager.state == GameManager.GameState.active)
        {
            if(playerController == null) playerController = GameObject.Find("PlayerRacer").GetComponent<PlayerController>();

            float[] bulletInfo = playerController.GetBulletInfo();
            bulletCooldown.fillAmount = bulletInfo[1];
            //bulletStats.text = "Bullets: " + bulletInfo[0] + " : " + tempString;

            float[] missleInfo = playerController.GetMissleInfo();
            missleCooldown.fillAmount = missleInfo[1];
            //missleStats.text = "Missles: " + missleInfo[0] + " : " + tempString;

            float[] mineInfo = playerController.GetMineInfo();
            mineCooldown.fillAmount = mineInfo[1];
            //mineStats.text = "Mines: " + mineInfo[0] + " : " + tempString;

            int money = playerController.GetCurrentRaceEarnings();
            moneyText.text = "$" + money;

            rank = RaceManager.GetPlace();
            UpdateRank(rank);
        }

        if (timerOn)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SetScreen(nextScreen);
                timerOn = false;
            }
        }
    }
    public void SetupScreens()
    {
        titleScreen = GameObject.Find("ScreenManager/titleScreen");
        instructionsScreen = GameObject.Find("ScreenManager/instructionsScreen");
        upgradesScreen = GameObject.Find("ScreenManager/TheShop");
        storyScreen = GameObject.Find("ScreenManager/storyScreen");
        controlsScreen = GameObject.Find("ScreenManager/controlsScreen");
        raceStartScreen = GameObject.Find("ScreenManager/RaceStart");

        // Save Screen Elements
        saveSlotScreen = GameObject.Find("ScreenManager/SaveSlotScreen");
        
        slot1NewPanel = GameObject.Find("ScreenManager/SaveSlotScreen/slot1New");
        slot2NewPanel = GameObject.Find("ScreenManager/SaveSlotScreen/slot2New");
        slot3NewPanel = GameObject.Find("ScreenManager/SaveSlotScreen/slot3New");

        slot1ContinuePanel = GameObject.Find("ScreenManager/SaveSlotScreen/slot1Continue");
        slot2ContinuePanel = GameObject.Find("ScreenManager/SaveSlotScreen/slot2Continue");
        slot3ContinuePanel = GameObject.Find("ScreenManager/SaveSlotScreen/slot3Continue");

        confirmDelete = GameObject.Find("ScreenManager/SaveSlotScreen/confirmDelete");
        confirmDelete.SetActive(false);

        slotPanels = new() { slot1NewPanel, slot2NewPanel, slot3NewPanel, slot1ContinuePanel, slot2ContinuePanel, slot3ContinuePanel };

        slot1RacerMoney = GameObject.Find("ScreenManager/SaveSlotScreen/slot1Continue/saveMoney").GetComponent<TextMeshProUGUI>();
        slot1RacerName = GameObject.Find("ScreenManager/SaveSlotScreen/slot1Continue/icon/Canvas/saveName").GetComponent<TextMeshProUGUI>();
        slot1RacerColor = GameObject.Find("ScreenManager/SaveSlotScreen/slot1Continue/icon/image/saveColor").GetComponent<Image>();

        slot1bronze = GameObject.Find("ScreenManager/SaveSlotScreen/slot1Continue/bronzeCup");
        slot1silver = GameObject.Find("ScreenManager/SaveSlotScreen/slot1Continue/silverCup");
        slot1gold = GameObject.Find("ScreenManager/SaveSlotScreen/slot1Continue/goldCup");

        slot2RacerMoney = GameObject.Find("ScreenManager/SaveSlotScreen/slot2Continue/saveMoney").GetComponent<TextMeshProUGUI>();
        slot2RacerName = GameObject.Find("ScreenManager/SaveSlotScreen/slot2Continue/icon/Canvas/saveName").GetComponent<TextMeshProUGUI>();
        slot2RacerColor = GameObject.Find("ScreenManager/SaveSlotScreen/slot2Continue/icon/image/saveColor").GetComponent<Image>();

        slot2bronze = GameObject.Find("ScreenManager/SaveSlotScreen/slot2Continue/bronzeCup");
        slot2silver = GameObject.Find("ScreenManager/SaveSlotScreen/slot2Continue/silverCup");
        slot2gold = GameObject.Find("ScreenManager/SaveSlotScreen/slot2Continue/goldCup");

        slot3RacerMoney = GameObject.Find("ScreenManager/SaveSlotScreen/slot3Continue/saveMoney").GetComponent<TextMeshProUGUI>();
        slot3RacerName = GameObject.Find("ScreenManager/SaveSlotScreen/slot3Continue/icon/Canvas/saveName").GetComponent<TextMeshProUGUI>();
        slot3RacerColor = GameObject.Find("ScreenManager/SaveSlotScreen/slot3Continue/icon/image/saveColor").GetComponent<Image>();

        slot3bronze = GameObject.Find("ScreenManager/SaveSlotScreen/slot3Continue/bronzeCup");
        slot3silver = GameObject.Find("ScreenManager/SaveSlotScreen/slot3Continue/silverCup");
        slot3gold = GameObject.Find("ScreenManager/SaveSlotScreen/slot3Continue/goldCup");

        trophiesForSaveScreen = new() { slot1bronze, slot1silver, slot1gold, slot2bronze, slot2silver, slot2gold, slot3bronze, slot3silver, slot3gold };

        // ---

        // Upgrade Screen Elements
        upgradeSelect = GameObject.Find("ScreenManager/TheShop/Select");

        engine1check = GameObject.Find("ScreenManager/TheShop/EngineUpgrades/Upgrade1/Check");

        engine2lock = GameObject.Find("ScreenManager/TheShop/EngineUpgrades/Upgrade2/Lock");
        engine2check = GameObject.Find("ScreenManagerTheShop/EngineUpgrades/Upgrade2/Check");

        engine3lock = GameObject.Find("ScreenManager/TheShop/EngineUpgrades/Upgrade3/Lock");
        engine3check = GameObject.Find("ScreenManager/TheShop/EngineUpgrades/Upgrade3/Check");

        armour1check = GameObject.Find("ScreenManager/TheShop/ArmourUpgrades/Upgrade1/Check");

        armour2lock = GameObject.Find("ScreenManager/TheShop/ArmourUpgrades/Upgrade2/Lock");
        armour2check = GameObject.Find("ScreenManager/TheShop/ArmourUpgrades/Upgrade2/Check");

        armour3lock = GameObject.Find("ScreenManager/TheShop/ArmourUpgrades/Upgrade3/Lock");
        armour3check = GameObject.Find("ScreenManager/TheShop/ArmourUpgrades/Upgrade3/Check");

        boostSpeed1check = GameObject.Find("ScreenManager/TheShop/BoostUpgrades/Upgrade1/Check");

        boostCooldown1check = GameObject.Find("ScreenManager/TheShop/BoostUpgrades/Upgrade2/Check");

        boostRecharge1check = GameObject.Find("ScreenManager/TheShop/BoostUpgrades/Upgrade3/Check");

        iconList = new List<GameObject> { engine1check, engine2lock, engine2check, engine3lock, engine3check, armour1check, armour2lock, armour2check, armour3lock, armour3check, boostSpeed1check, boostCooldown1check, boostRecharge1check, };
        // repair2lock
        // repair3lock
        // 
        // 
        // speech2lock
        // speech3lock

        upgradeName = GameObject.Find("ScreenManager/TheShop/DescriptionPanel/UpgradeName").GetComponent<TextMeshProUGUI>();
        upgradeDescription = GameObject.Find("ScreenManager/TheShop/DescriptionPanel/UpgradeDescription").GetComponent<TextMeshProUGUI>();
        upgradePrice = GameObject.Find("ScreenManager/TheShop/DescriptionPanel/UpgradePrice").GetComponent<TextMeshProUGUI>();
        playerFunds = GameObject.Find("ScreenManager/TheShop/DescriptionPanel/PlayerFunds").GetComponent<TextMeshProUGUI>();
        upgradeStatus = GameObject.Find("ScreenManager/TheShop/DescriptionPanel/UpgradeStatus").GetComponent<TextMeshProUGUI>();

        purchaseButton = GameObject.Find("ScreenManager/TheShop/DescriptionPanel/PurchaseButton");

        // ---

        // Customize Player Objects
        customizePlayer = GameObject.Find("ScreenManager/CustomizePlayer");

        playerNameInput = GameObject.Find("ScreenManager/CustomizePlayer/PlayerNameInput").GetComponent<TMP_InputField>();
        playerExampleName = GameObject.Find("ScreenManager/CustomizePlayer/Racer/Canvas/SpriteName").GetComponent<TextMeshProUGUI>();
        playerExampleColor = GameObject.Find("ScreenManager/CustomizePlayer/Racer/RacerImage/CarColor").GetComponent<Image>();

        red = Color.red;
        blue = Color.blue;
        green = Color.green;
        yellow = Color.yellow;

        playerExampleColor.color = green;
        // ---

        // HUD Objects
        HUD = GameObject.Find("ScreenManager/HUD");
        
        playerRanking = GameObject.Find("ScreenManager/HUD/playerRanking").GetComponent<TextMeshProUGUI>();
        moneyText = GameObject.Find("ScreenManager/HUD/money").GetComponent<TextMeshProUGUI>();
        countDownText = GameObject.Find("ScreenManager/HUD/countDown").GetComponent<TextMeshProUGUI>();
        countDownText.text = " ";
        bulletCooldown = GameObject.Find("ScreenManager/HUD/BulletCooldown").GetComponent<Image>();
        missleCooldown = GameObject.Find("ScreenManager/HUD/MissleCooldown").GetComponent<Image>();
        mineCooldown = GameObject.Find("ScreenManager/HUD/MineCooldown").GetComponent<Image>();
        // ---


        // END Race Sequence

        finishScreen = GameObject.Find("ScreenManager/finishScreen");
        defeatScreen = GameObject.Find("ScreenManager/defeatScreen");

        raceResultsScreen = GameObject.Find("ScreenManager/RaceResults");
        earningsScreen = GameObject.Find("ScreenManager/Earnings");

        earningsText = GameObject.Find("ScreenManager/Earnings/earningsText").GetComponent<TextMeshProUGUI>();

        rank1 = GameObject.Find("ScreenManager/RaceResults/rank1").GetComponent<TextMeshProUGUI>();
        rank2 = GameObject.Find("ScreenManager/RaceResults/rank2").GetComponent<TextMeshProUGUI>();
        rank3 = GameObject.Find("ScreenManager/RaceResults/rank3").GetComponent<TextMeshProUGUI>();
        rank4 = GameObject.Find("ScreenManager/RaceResults/rank4").GetComponent<TextMeshProUGUI>();

        ranks = new List<TextMeshProUGUI> { rank1, rank2, rank3, rank4 };
        // ---

        pauseScreen = GameObject.Find("ScreenManager/pause");

        screensList = new List<GameObject> { titleScreen, instructionsScreen, customizePlayer, upgradesScreen, HUD, finishScreen, defeatScreen, raceResultsScreen, earningsScreen, pauseScreen, saveSlotScreen, storyScreen, controlsScreen, raceStartScreen };

        ClearScreens();

        titleScreen.SetActive(true);

        ready = true;
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

            case Screen.saveSlot:
                if (!saveSlotScreen.activeSelf) saveSlotScreen.SetActive(true);
                UpdateSaveSlots();
                break;

            case Screen.customizePlayer:
                if (!customizePlayer.activeSelf) customizePlayer.SetActive(true);
                break;

            case Screen.story:
                if (!storyScreen.activeSelf) storyScreen.SetActive(true);
                break;

            case Screen.controls:
                if (!controlsScreen.activeSelf) controlsScreen.SetActive(true);
                break;

            case Screen.raceStart:
                if (!raceStartScreen.activeSelf) raceStartScreen.SetActive(true);
                break;
        }

        lastScreen = currentScreen;
        currentScreen = screen;
    }

    public static void ClearScreens()
    {
        foreach (GameObject screen in screensList) { if(screen.activeSelf) screen.SetActive(false); }
    }

    public static void CountDown(string countDown)
    {
        countDownText.text = countDown;
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
            string racerName = racer.RacerName;
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
                    earningsReport += "Defeated " + racer.RacerName + "! +$" + eliminationReward + "\n";
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
        int engineLevel = playerController.EngineUpgradeLevel;
        int armourLevel = playerController.ArmourUpgradeLevel;
        int boostSpeedLevel = playerController.BoostSpeedLevel;
        int boostCooldownLevel = playerController.BoostCooldownLevel;
        int boostRechargeLevel = playerController.BoostRechargeLevel;


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

        switch (boostSpeedLevel)
        {
            case 1:
                boostSpeed1check.SetActive(true);
                break;
            case 2:
                boostSpeed1check.SetActive(true);
                //boostSpeed2check.SetActive(true);
                break;
            case 3:
                boostSpeed1check.SetActive(true);
                // boostSpeed2check.SetActive(true);
                // boostSpeed3check.SetActive(true);
                break;
        }

        switch (boostCooldownLevel)
        {
            case 1:
                boostCooldown1check.SetActive(true);
                break;
            case 2:
                boostCooldown1check.SetActive(true);
                //boostSpeed2check.SetActive(true);
                break;
            case 3:
                boostCooldown1check.SetActive(true);
                // boostSpeed2check.SetActive(true);
                // boostSpeed3check.SetActive(true);
                break;
        }

        switch (boostRechargeLevel)
        {
            case 1:
                boostRecharge1check.SetActive(true);
                break;
            case 2:
                boostRecharge1check.SetActive(true);
                //boostSpeed2check.SetActive(true);
                break;
            case 3:
                boostCooldown1check.SetActive(true);
                // boostSpeed2check.SetActive(true);
                // boostSpeed3check.SetActive(true);
                break;
        }
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

            case Upgrade.Category.armour:
                if (input.upgradeNumber == 1) upgradeSelect.transform.position = armour1check.transform.position;
                if (input.upgradeNumber == 2) upgradeSelect.transform.position = armour2lock.transform.position;
                if (input.upgradeNumber == 3) upgradeSelect.transform.position = armour3lock.transform.position;
                break;

            case Upgrade.Category.boostSpeed:
                if (input.upgradeNumber == 1) upgradeSelect.transform.position = boostSpeed1check.transform.position;
                //if (input.upgradeNumber == 2) upgradeSelect.transform.position = boost2lock.transform.position;
                //if (input.upgradeNumber == 3) upgradeSelect.transform.position = boost3lock.transform.position;
                break;

            case Upgrade.Category.boostCooldown:
                if (input.upgradeNumber == 1) upgradeSelect.transform.position = boostCooldown1check.transform.position;
                //if (input.upgradeNumber == 2) upgradeSelect.transform.position = boost2lock.transform.position;
                //if (input.upgradeNumber == 3) upgradeSelect.transform.position = boost3lock.transform.position;
                break;

            case Upgrade.Category.boostRecharge:
                if (input.upgradeNumber == 1) upgradeSelect.transform.position = boostRecharge1check.transform.position;
                //if (input.upgradeNumber == 2) upgradeSelect.transform.position = boost2lock.transform.position;
                //if (input.upgradeNumber == 3) upgradeSelect.transform.position = boost3lock.transform.position;
                break;
        }
    }

    public static void UpdateSaveSlots()
    {
        foreach (GameObject panel in slotPanels) if (!panel.activeSelf) panel.SetActive(true);
        foreach (GameObject trophy in trophiesForSaveScreen) if (!trophy.activeSelf) trophy.SetActive(true);

        string[] saveData = DataManager.CheckSaveData(1);
 
        if (saveData == null) slot1ContinuePanel.SetActive(false);
        else
        {
            slot1NewPanel.SetActive(false);
            slot1RacerMoney.text = "$" + saveData[0];
            string[] rgba = saveData[1].Split(',');
            slot1RacerColor.color = new Color(float.Parse(rgba[0]), float.Parse(rgba[1]), float.Parse(rgba[2]), float.Parse(rgba[3]));
            slot1RacerName.text = saveData[2];
            switch(int.Parse(saveData[3]))
            {
                case 0:
                    slot1bronze.SetActive(false);
                    slot1silver.SetActive(false);
                    slot1gold.SetActive(false);
                    break;

                case 1:
                    slot1silver.SetActive(false);
                    slot1gold.SetActive(false);
                    break;

                case 2:
                    slot1gold.SetActive(false);
                    break;
            }
        }

        saveData = DataManager.CheckSaveData(2);
        if (saveData == null) slot2ContinuePanel.SetActive(false);
        else
        {
            slot2NewPanel.SetActive(false);
            slot2RacerMoney.text = "$" + saveData[0];
            string[] rgba = saveData[1].Split(',');
            slot2RacerColor.color = new Color(float.Parse(rgba[0]), float.Parse(rgba[1]), float.Parse(rgba[2]), float.Parse(rgba[3]));
            switch (int.Parse(saveData[3]))
            {
                case 0:
                    slot2bronze.SetActive(false);
                    slot2silver.SetActive(false);
                    slot2gold.SetActive(false);
                    break;

                case 1:
                    slot2silver.SetActive(false);
                    slot2gold.SetActive(false);
                    break;

                case 2:
                    slot2gold.SetActive(false);
                    break;
            }
        }

        saveData = DataManager.CheckSaveData(3);
        if (saveData == null) slot3ContinuePanel.SetActive(false);
        else
        {
            slot3NewPanel.SetActive(false);
            slot3RacerMoney.text = "$" + saveData[0];
            string[] rgba = saveData[1].Split(',');
            slot3RacerColor.color = new Color(float.Parse(rgba[0]), float.Parse(rgba[1]), float.Parse(rgba[2]), float.Parse(rgba[3]));
            switch (int.Parse(saveData[3]))
            {
                case 0:
                    slot3bronze.SetActive(false);
                    slot3silver.SetActive(false);
                    slot3gold.SetActive(false);
                    break;

                case 1:
                    slot3silver.SetActive(false);
                    slot3gold.SetActive(false);
                    break;

                case 2:
                    slot3gold.SetActive(false);
                    break;
            }
        }

    }

    public static void ActivateDeleteSavePanel()
    {
        if (!ScreenManager.ConfirmDelete.activeSelf)
        {
            ScreenManager.ConfirmDelete.SetActive(true);
        }
    }
}
