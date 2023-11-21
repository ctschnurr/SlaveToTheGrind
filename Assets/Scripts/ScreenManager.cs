using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using static Globals;
using static Unity.Burst.Intrinsics.X86.Avx;

public class ScreenManager : MonoBehaviour
{
    public enum Screen
    {
        title,
        loadSave,
        customizePlayer,
        HUD,
        raceStart,
        finish,
        defeat,
        endRace,
        earnings,
        shop,
        armoury,
        school,
        saveSlot,
        confirmDelete,
        story,
        controls,
        cupWinner,
        storyEnd,
        options,
        pause
    }

    public enum UpgradeScreen
    {
        car,
        racer,
        ammo
    }

    static GameObject titleScreen;
    static GameObject garageScreen;
    static GameObject armouryScreen;
    static GameObject schoolScreen;
    static GameObject storyScreen;
    static GameObject controlsScreen;
    static GameObject storyEndScreen;
    static GameObject optionsScreen;

    // Race Start Screen Elements:
    static GameObject raceStartScreen;

    static GameObject startBronze;
    static GameObject startSilver;
    static GameObject startGold;
    static GameObject startChamp;

    static TextMeshProUGUI startTitleText;
    static TextMeshProUGUI startDescText;

    // ---

    // Cup Winner Screen Elements:
    static GameObject cupWinnerScreen;

    static GameObject cupButtonsPanel;
    static GameObject bronzeCup;
    static GameObject silverCup;
    static GameObject goldCup;
    static GameObject championshipCup;

    static TextMeshProUGUI cupTitleText;
    static TextMeshProUGUI cupDescText;
    // ---

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

    static GameObject repair2lock;
    static GameObject repair3lock;
         
    static GameObject speech2lock;
    static GameObject speech3lock;

    static TextMeshProUGUI upgradeName;
    static TextMeshProUGUI upgradeDescription;
    static TextMeshProUGUI upgradePrice;
    static TextMeshProUGUI playerFunds;
    static TextMeshProUGUI upgradeStatus;
    static GameObject purchaseButton;

    static TextMeshProUGUI armouryUpgradeName;
    static TextMeshProUGUI armouryUpgradeDescription;
    static TextMeshProUGUI armouryUpgradePrice;
    static TextMeshProUGUI armouryPlayerFunds;
    static TextMeshProUGUI armouryUpgradeStatus;
    static GameObject armouryPurchaseButton;

    static TextMeshProUGUI schoolUpgradeName;
    static TextMeshProUGUI schoolUpgradeDescription;
    static TextMeshProUGUI schoolUpgradePrice;
    static TextMeshProUGUI schoolPlayerFunds;
    static TextMeshProUGUI schoolUpgradeStatus;
    static GameObject schoolPurchaseButton;

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
    static Image bulletAmmo;
    static Image bulletCooldown;
    static Image missleAmmo;
    static Image missleCooldown;
    static Image mineAmmo;
    static Image mineCooldown;
    static Image countdown3;
    static Image countdown2;
    static Image countdown1;
    static Image countdownGO;

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
            if (playerController == null) playerController = GameObject.Find("PlayerRacer").GetComponent<PlayerController>();

            float[] bulletInfo = playerController.GetBulletInfo();
            if (playerController.BulletAmmo > 0) bulletCooldown.fillAmount = 1 - (bulletInfo[0] / bulletInfo[1]);
            bulletAmmo.fillAmount = (float)playerController.BulletAmmo / playerController.BulletAmmoMax;

            float[] missleInfo = playerController.GetMissleInfo();
            if (playerController.MissleAmmo > 0) missleCooldown.fillAmount = 1 - (missleInfo[0] / missleInfo[1]);
            missleAmmo.fillAmount = (float)playerController.MissleAmmo / playerController.MissleAmmoMax;

            float[] mineInfo = playerController.GetMineInfo();
            if (playerController.MineAmmo > 0) mineCooldown.fillAmount = 1 - (mineInfo[0] / mineInfo[1]);
            mineAmmo.fillAmount = (float)playerController.MineAmmo / playerController.MineAmmoMax;

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

        armouryScreen = GameObject.Find("ScreenManager/Armoury");
        schoolScreen = GameObject.Find("ScreenManager/School");
        storyScreen = GameObject.Find("ScreenManager/storyScreen");
        controlsScreen = GameObject.Find("ScreenManager/controlsScreen");
        storyEndScreen = GameObject.Find("ScreenManager/storyEndScreen");
        optionsScreen = GameObject.Find("ScreenManager/Options");


        // Race Start Screen Elements
        raceStartScreen = GameObject.Find("ScreenManager/RaceStart");

        startBronze = GameObject.Find("ScreenManager/RaceStart/TitlePanel/BronzeCup");
        startSilver = GameObject.Find("ScreenManager/RaceStart/TitlePanel/SilverCup");
        startGold = GameObject.Find("ScreenManager/RaceStart/TitlePanel/GoldCup");
        startChamp = GameObject.Find("ScreenManager/RaceStart/TitlePanel/ChampionshipCup");

        startTitleText = GameObject.Find("ScreenManager/RaceStart/TitlePanel/LevelTitle").GetComponent<TextMeshProUGUI>();
        startDescText = GameObject.Find("ScreenManager/RaceStart/TitlePanel/LevelDescription").GetComponent<TextMeshProUGUI>();
        // ---

        // Cup Winner Screen Elements
        cupWinnerScreen = GameObject.Find("ScreenManager/CupWinner");

        bronzeCup = GameObject.Find("ScreenManager/CupWinner/Panel/BronzeCup");
        silverCup = GameObject.Find("ScreenManager/CupWinner/Panel/SilverCup");
        goldCup = GameObject.Find("ScreenManager/CupWinner/Panel/GoldCup");
        championshipCup = GameObject.Find("ScreenManager/CupWinner/Panel/ChampionshipCup");

        cupTitleText = GameObject.Find("ScreenManager/CupWinner/Panel/Title").GetComponent<TextMeshProUGUI>();
        cupDescText = GameObject.Find("ScreenManager/CupWinner/Panel/Description").GetComponent<TextMeshProUGUI>();

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

        garageScreen = GameObject.Find("ScreenManager/Garage");

        upgradeName = GameObject.Find("ScreenManager/Garage/DescriptionPanel/UpgradeName").GetComponent<TextMeshProUGUI>();
        upgradeDescription = GameObject.Find("ScreenManager/Garage/DescriptionPanel/UpgradeDescription").GetComponent<TextMeshProUGUI>();
        upgradePrice = GameObject.Find("ScreenManager/Garage/DescriptionPanel/UpgradePrice").GetComponent<TextMeshProUGUI>();
        playerFunds = GameObject.Find("ScreenManager/Garage/DescriptionPanel/PlayerFunds").GetComponent<TextMeshProUGUI>();
        upgradeStatus = GameObject.Find("ScreenManager/Garage/DescriptionPanel/UpgradeStatus").GetComponent<TextMeshProUGUI>();

        purchaseButton = GameObject.Find("ScreenManager/Garage/DescriptionPanel/PurchaseButton");

        armouryUpgradeName = GameObject.Find("ScreenManager/Armoury/DescriptionPanel/UpgradeName").GetComponent<TextMeshProUGUI>();
        armouryUpgradeDescription = GameObject.Find("ScreenManager/Armoury/DescriptionPanel/UpgradeDescription").GetComponent<TextMeshProUGUI>();
        armouryUpgradePrice = GameObject.Find("ScreenManager/Armoury/DescriptionPanel/UpgradePrice").GetComponent<TextMeshProUGUI>();
        armouryPlayerFunds = GameObject.Find("ScreenManager/Armoury/DescriptionPanel/PlayerFunds").GetComponent<TextMeshProUGUI>();
        armouryUpgradeStatus = GameObject.Find("ScreenManager/Armoury/DescriptionPanel/UpgradeStatus").GetComponent<TextMeshProUGUI>();
        armouryPurchaseButton = GameObject.Find("ScreenManager/Armoury/DescriptionPanel/PurchaseButton");

        schoolUpgradeName = GameObject.Find("ScreenManager/School/DescriptionPanel/UpgradeName").GetComponent<TextMeshProUGUI>();
        schoolUpgradeDescription = GameObject.Find("ScreenManager/School/DescriptionPanel/UpgradeDescription").GetComponent<TextMeshProUGUI>();
        schoolUpgradePrice = GameObject.Find("ScreenManager/School/DescriptionPanel/UpgradePrice").GetComponent<TextMeshProUGUI>();
        schoolPlayerFunds = GameObject.Find("ScreenManager/School/DescriptionPanel/PlayerFunds").GetComponent<TextMeshProUGUI>();
        schoolUpgradeStatus = GameObject.Find("ScreenManager/School/DescriptionPanel/UpgradeStatus").GetComponent<TextMeshProUGUI>();
        schoolPurchaseButton = GameObject.Find("ScreenManager/School/DescriptionPanel/PurchaseButton");
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
        countdown3 = GameObject.Find("ScreenManager/HUD/3").GetComponent<Image>();
        countdown2 = GameObject.Find("ScreenManager/HUD/2").GetComponent<Image>();
        countdown1 = GameObject.Find("ScreenManager/HUD/1").GetComponent<Image>();
        countdownGO = GameObject.Find("ScreenManager/HUD/GO").GetComponent<Image>();

        bulletAmmo = GameObject.Find("ScreenManager/HUD/BulletAmmo").GetComponent<Image>();
        bulletCooldown =  GameObject.Find("ScreenManager/HUD/BulletAmmo/Reload").GetComponent<Image>();
        missleAmmo = GameObject.Find("ScreenManager/HUD/MissleAmmo").GetComponent<Image>();
        missleCooldown = GameObject.Find("ScreenManager/HUD/MissleAmmo/Reload").GetComponent<Image>();
        mineAmmo = GameObject.Find("ScreenManager/HUD/MineAmmo").GetComponent<Image>();
        mineCooldown = GameObject.Find("ScreenManager/HUD/MineAmmo/Reload").GetComponent<Image>();

        countdown3.gameObject.SetActive(false);
        countdown2.gameObject.SetActive(false);
        countdown1.gameObject.SetActive(false);
        countdownGO.gameObject.SetActive(false);
        // ---


        // END Race Sequence

        finishScreen = GameObject.Find("ScreenManager/finishScreen");
        defeatScreen = GameObject.Find("ScreenManager/defeatScreen");

        raceResultsScreen = GameObject.Find("ScreenManager/RaceResults");
        earningsScreen = GameObject.Find("ScreenManager/Earnings");

        earningsText = GameObject.Find("ScreenManager/Earnings/Panel/earningsText").GetComponent<TextMeshProUGUI>();

        rank1 = GameObject.Find("ScreenManager/RaceResults/rank1").GetComponent<TextMeshProUGUI>();
        rank2 = GameObject.Find("ScreenManager/RaceResults/rank2").GetComponent<TextMeshProUGUI>();
        rank3 = GameObject.Find("ScreenManager/RaceResults/rank3").GetComponent<TextMeshProUGUI>();
        rank4 = GameObject.Find("ScreenManager/RaceResults/rank4").GetComponent<TextMeshProUGUI>();

        ranks = new List<TextMeshProUGUI> { rank1, rank2, rank3, rank4 };
        // ---

        pauseScreen = GameObject.Find("ScreenManager/pause");

        screensList = new List<GameObject> { titleScreen, customizePlayer, garageScreen, schoolScreen, armouryScreen, HUD, finishScreen, defeatScreen, raceResultsScreen, earningsScreen, pauseScreen, saveSlotScreen, storyScreen, controlsScreen, raceStartScreen, cupWinnerScreen, storyEndScreen, optionsScreen,  };

        ClearScreens();

        titleScreen.SetActive(true);

        ready = true;
    }

    public static void SetScreen(Screen screen)
    {
        ClearScreens();
        Upgrade temp;

        switch (screen)
        {
            case Screen.title:
                if (!titleScreen.activeSelf) titleScreen.SetActive(true);
                break;

            case Screen.options:
                if (!optionsScreen.activeSelf) optionsScreen.SetActive(true);
                break;

            case Screen.shop:
                if (!garageScreen.activeSelf) garageScreen.SetActive(true);
                GarageManager.UpdateShopIcons();
                temp = GarageManager.GetDefaultUpgrade();
                UpdateUpgradeClicked(temp);
                break;

            case Screen.armoury:
                if (!armouryScreen.activeSelf) armouryScreen.SetActive(true);
                ArmouryManager.UpdateArmouryIcons();
                temp = ArmouryManager.GetDefaultUpgrade();
                UpdateArmouryClicked(temp);
                break;

            case Screen.school:
                if (!schoolScreen.activeSelf) schoolScreen.SetActive(true);
                SchoolManager.UpdateSchoolIcons();
                temp = SchoolManager.GetDefaultUpgrade();
                UpdateSchoolClicked(temp);
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
                SetupRaceStartScreen();
                break;

            case Screen.cupWinner:
                if (!cupWinnerScreen.activeSelf) cupWinnerScreen.SetActive(true);
                SetupCupWinnerScreen();
                break;

            case Screen.storyEnd:
                if (!storyEndScreen.activeSelf) storyEndScreen.SetActive(true);
                break;
        }

        lastScreen = currentScreen;
        currentScreen = screen;
    }

    public static void ClearScreens()
    {
        foreach (GameObject screen in screensList) { if(screen.activeSelf) screen.SetActive(false); }
    }

    public static void CountDown(int countDown)
    {
        countdown3.gameObject.SetActive(false);
        countdown2.gameObject.SetActive(false);
        countdown1.gameObject.SetActive(false);
        countdownGO.gameObject.SetActive(false);

        switch (countDown)
        {
            case 3:
                countdown3.gameObject.SetActive(true);
                break;
            case 2:
                countdown2.gameObject.SetActive(true);
                break;
            case 1:
                countdown1.gameObject.SetActive(true);
                break;
            case 0:
                countdownGO.gameObject.SetActive(true);
                break;
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

        int speechSkill = playerController.SpeechSkillLevel;
        float speechPay = raceEarnings * (speechSkill * 0.1f);

        if (speechPay > 0)
        {
            earningsReport += "Speech skill bonus! +$" + (int)speechPay;
            raceEarnings += (int)speechPay;
        }

        earningsReport += "\nTotal Earnings: $" + raceEarnings;

        earningsText.text = earningsReport;
        playerController.PayRacer(raceEarnings);

        playerController.UpdateRacer();
        DataManager.SaveGame();
    }

    public static void UpdateUpgradeClicked(Upgrade input)
    {
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

    public static void UpdateArmouryClicked(Upgrade input)
    {
        armouryUpgradeName.text = input.name;
        armouryUpgradeDescription.text = input.description;
        armouryUpgradePrice.text = "Upgrade Price: $" + input.price.ToString();
        armouryPlayerFunds.text = "Your Funds: $" + playerController.GetMoney();

        int bulletAmmo = playerController.BulletAmmo;
        int bulletAmmoMax = playerController.BulletAmmoMax;

        int missleAmmo = playerController.MissleAmmo;
        int missleAmmoMax = playerController.MissleAmmoMax;

        int mineAmmo = playerController.MineAmmo;
        int mineAmmoMax = playerController.MineAmmoMax;

        switch (input.category)
        {
            case Upgrade.Category.bulletAmmo:
                armouryUpgradeDescription.text += "\n\n Bullets: " + bulletAmmo + "/" + bulletAmmoMax;
                break;
                
            case Upgrade.Category.missleAmmo: 
                armouryUpgradeDescription.text += "\n\n Missles: " + missleAmmo + "/" + missleAmmoMax;
                break;

            case Upgrade.Category.mineAmmo:
                armouryUpgradeDescription.text += "\n\n Mines: " + mineAmmo + "/" + mineAmmoMax;
                break;
        }

        switch (input.state)
        {
            case Upgrade.State.available:
                if (playerController.GetMoney() < input.price)
                {
                    if (armouryPurchaseButton.activeSelf) armouryPurchaseButton.SetActive(false);
                    if (!armouryUpgradeStatus.gameObject.activeSelf) armouryUpgradeStatus.gameObject.SetActive(true);
                    armouryUpgradeStatus.text = "Insufficient Funds";
                    break;
                }
                else
                {
                    if (!armouryPurchaseButton.activeSelf) armouryPurchaseButton.SetActive(true);
                    if (armouryUpgradeStatus.gameObject.activeSelf) armouryUpgradeStatus.gameObject.SetActive(false);
                }

                if(input.category == Upgrade.Category.bulletAmmo && bulletAmmo >= bulletAmmoMax) 
                {
                    if (armouryPurchaseButton.activeSelf) armouryPurchaseButton.SetActive(false);
                    if (!armouryUpgradeStatus.gameObject.activeSelf) armouryUpgradeStatus.gameObject.SetActive(true);
                    armouryUpgradeStatus.text = "Bullet Ammo Full";
                    break;
                }

                if (input.category == Upgrade.Category.missleAmmo && missleAmmo >= missleAmmoMax)
                {
                    if (armouryPurchaseButton.activeSelf) armouryPurchaseButton.SetActive(false);
                    if (!armouryUpgradeStatus.gameObject.activeSelf) armouryUpgradeStatus.gameObject.SetActive(true);
                    armouryUpgradeStatus.text = "Missle Ammo Full";
                    break;
                }

                if (input.category == Upgrade.Category.mineAmmo && mineAmmo >= mineAmmoMax)
                {
                    if (armouryPurchaseButton.activeSelf) armouryPurchaseButton.SetActive(false);
                    if (!armouryUpgradeStatus.gameObject.activeSelf) armouryUpgradeStatus.gameObject.SetActive(true);
                    armouryUpgradeStatus.text = "Mine Ammo Full";
                    break;
                }
                break;

            case Upgrade.State.owned:
                if (armouryPurchaseButton.activeSelf) armouryPurchaseButton.SetActive(false);
                if (!armouryUpgradeStatus.gameObject.activeSelf) armouryUpgradeStatus.gameObject.SetActive(true);
                armouryUpgradeStatus.text = "Owned";
                break;

            case Upgrade.State.equipped:
                if (armouryPurchaseButton.activeSelf) armouryPurchaseButton.SetActive(false);
                if (!armouryUpgradeStatus.gameObject.activeSelf) armouryUpgradeStatus.gameObject.SetActive(true);
                armouryUpgradeStatus.text = "Equipped";
                break;
            case Upgrade.State.locked:
                if (armouryPurchaseButton.activeSelf) armouryPurchaseButton.SetActive(false);
                if (!armouryUpgradeStatus.gameObject.activeSelf) armouryUpgradeStatus.gameObject.SetActive(true);
                armouryUpgradeStatus.text = "Locked";
                break;
        }
    }

    public static void UpdateSchoolClicked(Upgrade input)
    {
        schoolUpgradeName.text = input.name;
        schoolUpgradeDescription.text = input.description;
        schoolUpgradePrice.text = "Upgrade Price: $" + input.price.ToString();
        schoolPlayerFunds.text = "Your Funds: $" + playerController.GetMoney();


        switch (input.state)
        {
            case Upgrade.State.available:
                if (playerController.GetMoney() >= input.price)
                {
                    if (!schoolPurchaseButton.activeSelf) schoolPurchaseButton.SetActive(true);
                    if (schoolUpgradeStatus.gameObject.activeSelf) schoolUpgradeStatus.gameObject.SetActive(false);
                }
                else
                {
                    if (schoolPurchaseButton.activeSelf) schoolPurchaseButton.SetActive(false);
                    if (!schoolUpgradeStatus.gameObject.activeSelf) schoolUpgradeStatus.gameObject.SetActive(true);
                    schoolUpgradeStatus.text = "Insufficient Funds";
                }
                break;

            case Upgrade.State.owned:
                if (schoolPurchaseButton.activeSelf) schoolPurchaseButton.SetActive(false);
                if (!schoolUpgradeStatus.gameObject.activeSelf) schoolUpgradeStatus.gameObject.SetActive(true);
                schoolUpgradeStatus.text = "Owned";
                break;

            case Upgrade.State.equipped:
                if (schoolPurchaseButton.activeSelf) schoolPurchaseButton.SetActive(false);
                if (!schoolUpgradeStatus.gameObject.activeSelf) schoolUpgradeStatus.gameObject.SetActive(true);
                schoolUpgradeStatus.text = "Equipped";
                break;
            case Upgrade.State.locked:
                if (schoolPurchaseButton.activeSelf) schoolPurchaseButton.SetActive(false);
                if (!schoolUpgradeStatus.gameObject.activeSelf) schoolUpgradeStatus.gameObject.SetActive(true);
                schoolUpgradeStatus.text = "Locked";
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
            slot2RacerName.text = saveData[2];
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
            slot3RacerName.text = saveData[2];
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

    public static void SetupCupWinnerScreen()
    {
        switch(GameManager.GameLevel)
        {
            case 1:
                if (!bronzeCup.activeSelf) bronzeCup.SetActive(true);
                if (silverCup.activeSelf) silverCup.SetActive(false);
                if (goldCup.activeSelf) goldCup.SetActive(false);
                if (championshipCup.activeSelf) championshipCup.SetActive(false);

                cupTitleText.text = "CONGRATULATIONS!\nYOU WON THE BRONZE CUP!";
                cupDescText.text = "Silver cup race has been unlocked!\nNew upgrades have been unlocked!";
                break;

            case 2:
                if (bronzeCup.activeSelf) bronzeCup.SetActive(false);
                if (!silverCup.activeSelf) silverCup.SetActive(true);
                if (goldCup.activeSelf) goldCup.SetActive(false);
                if (championshipCup.activeSelf) championshipCup.SetActive(false);

                cupTitleText.text = "CONGRATULATIONS!\nYOU WON THE SILVER CUP!";
                cupDescText.text = "Gold cup race has been unlocked!\nNew upgrades have been unlocked!";
                break;

            case 3:
                if (bronzeCup.activeSelf) bronzeCup.SetActive(false);
                if (silverCup.activeSelf) silverCup.SetActive(false);
                if (!goldCup.activeSelf) goldCup.SetActive(true);
                if (championshipCup.activeSelf) championshipCup.SetActive(false);

                cupTitleText.text = "CONGRATULATIONS!\nYOU WON THE GOLD CUP!";
                cupDescText.text = "Championship cup race has been unlocked!\nNew upgrades have been unlocked!";
                break;

            case 4:
                if (bronzeCup.activeSelf) bronzeCup.SetActive(false);
                if (silverCup.activeSelf) silverCup.SetActive(false);
                if (goldCup.activeSelf) goldCup.SetActive(false);
                if (!championshipCup.activeSelf) championshipCup.SetActive(true);

                cupTitleText.text = "CONGRATULATIONS!\nYOU WON THE CHAMPIONSHIP CUP!";
                cupDescText.text = "Time to claim your grand prize!";
                break;
        }
    }

    public static void SetupRaceStartScreen()
    {
        switch (GameManager.GameLevel)
        {
            case 0:
                if (!startBronze.activeSelf) startBronze.SetActive(true);
                if (startSilver.activeSelf) startSilver.SetActive(false);
                if (startGold.activeSelf) startGold.SetActive(false);
                if (startChamp.activeSelf) startChamp.SetActive(false);

                startTitleText.text = "BRONZE CUP - Level 1";
                startDescText.text = "Win 1st place to move up to the Silver Cup!";
                break;

            case 1:
                if (startBronze.activeSelf) startBronze.SetActive(false);
                if (!startSilver.activeSelf) startSilver.SetActive(true);
                if (startGold.activeSelf) startGold.SetActive(false);
                if (startChamp.activeSelf) startChamp.SetActive(false);

                startTitleText.text = "SILVER CUP - Level 2";
                startDescText.text = "Win 1st place to move up to the Gold Cup!";
                break;

            case 2:
                if (startBronze.activeSelf) startBronze.SetActive(false);
                if (startSilver.activeSelf) startSilver.SetActive(false);
                if (!startGold.activeSelf) startGold.SetActive(true);
                if (startChamp.activeSelf) startChamp.SetActive(false);

                startTitleText.text = "GOLD CUP - Level 3";
                startDescText.text = "Win 1st place to move up to the Championship Cup!";
                break;

            case 3:
                if (startBronze.activeSelf) startBronze.SetActive(false);
                if (startSilver.activeSelf) startSilver.SetActive(false);
                if (startGold.activeSelf) startGold.SetActive(false);
                if (!startChamp.activeSelf) startChamp.SetActive(true);

                startTitleText.text = "CHAMPIONSHIP CUP - Final Level";
                startDescText.text = "Win 1st place to claim the grand prize!";

                break;
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
