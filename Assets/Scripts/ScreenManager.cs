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
    static GameObject shop;
    static GameObject shopT1;
    static GameObject shopT2;
    static GameObject shopT3;
    static GameObject shopT4;
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

    // Upgrade screen elements:
    static GameObject upgradeSelect;

    // T1 Shop Elements:
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

    // T2 Shop Elements:
    static GameObject engine4check;

    static GameObject engine5lock;
    static GameObject engine5check;

    static GameObject engine6lock;
    static GameObject engine6check;

    static GameObject armour4check;

    static GameObject armour5lock;
    static GameObject armour5check;

    static GameObject armour6lock;
    static GameObject armour6check;

    static GameObject boostSpeed2check;
    static GameObject boostCooldown2check;
    static GameObject boostRecharge2check;

    // T3 Shop Elements
    static GameObject engine7check;

    static GameObject engine8lock;
    static GameObject engine8check;

    static GameObject engine9lock;
    static GameObject engine9check;

    static GameObject armour7check;

    static GameObject armour8lock;
    static GameObject armour8check;

    static GameObject armour9lock;
    static GameObject armour9check;

    static GameObject boostSpeed3check;
    static GameObject boostCooldown3check;
    static GameObject boostRecharge3check;

    // T4 Shop Elements
    static GameObject engine10check;

    static GameObject engine11lock;
    static GameObject engine11check;

    static GameObject engine12lock;
    static GameObject engine12check;

    static GameObject armour10check;

    static GameObject armour11lock;
    static GameObject armour11check;

    static GameObject armour12lock;
    static GameObject armour12check;

    static GameObject boostSpeed4check;
    static GameObject boostCooldown4check;
    static GameObject boostRecharge4check;
    //

    static GameObject repair2lock;
    static GameObject repair3lock;
         
    static GameObject speech2lock;
    static GameObject speech3lock;

    static List<GameObject> shopIconList;

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

    static TextMeshProUGUI bulletAmmo;
    static TextMeshProUGUI missleAmmo;
    static TextMeshProUGUI mineAmmo;

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
            bulletAmmo.text = "x " + playerController.BulletAmmo;

            float[] missleInfo = playerController.GetMissleInfo();
            missleCooldown.fillAmount = missleInfo[1];
            missleAmmo.text = "x " + playerController.MissleAmmo;

            float[] mineInfo = playerController.GetMineInfo();
            mineCooldown.fillAmount = mineInfo[1];
            mineAmmo.text = "x " + playerController.MineAmmo;

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

        armouryScreen = GameObject.Find("ScreenManager/Armoury");
        schoolScreen = GameObject.Find("ScreenManager/School");
        storyScreen = GameObject.Find("ScreenManager/storyScreen");
        controlsScreen = GameObject.Find("ScreenManager/controlsScreen");
        storyEndScreen = GameObject.Find("ScreenManager/storyEndScreen");
        optionsScreen = GameObject.Find("ScreenManager/Options");


        // Race Start Screen Elements
        raceStartScreen = GameObject.Find("ScreenManager/RaceStart");

        startBronze = GameObject.Find("ScreenManager/RaceStart/BronzeCup");
        startSilver = GameObject.Find("ScreenManager/RaceStart/SilverCup");
        startGold = GameObject.Find("ScreenManager/RaceStart/GoldCup");
        startChamp = GameObject.Find("ScreenManager/RaceStart/ChampionshipCup");

        startTitleText = GameObject.Find("ScreenManager/RaceStart/LevelTitle").GetComponent<TextMeshProUGUI>();
        startDescText = GameObject.Find("ScreenManager/RaceStart/LevelDescription").GetComponent<TextMeshProUGUI>();
        // ---

        // Cup Winner Screen Elements
        cupWinnerScreen = GameObject.Find("ScreenManager/CupWinner");

        cupButtonsPanel = GameObject.Find("ScreenManager/CupWinner/ButtonsPanel");
        bronzeCup = GameObject.Find("ScreenManager/CupWinner/BronzeCup");
        silverCup = GameObject.Find("ScreenManager/CupWinner/SilverCup");
        goldCup = GameObject.Find("ScreenManager/CupWinner/GoldCup");
        championshipCup = GameObject.Find("ScreenManager/CupWinner/ChampionshipCup");

        cupTitleText = GameObject.Find("ScreenManager/CupWinner/Title").GetComponent<TextMeshProUGUI>();
        cupDescText = GameObject.Find("ScreenManager/CupWinner/Description").GetComponent<TextMeshProUGUI>();

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

        // Shop Screen Elements:
        shop = GameObject.Find("ScreenManager/Shop");

        // Shop Tier Panels
        shopT1 = GameObject.Find("ScreenManager/Shop/T1");
        shopT2 = GameObject.Find("ScreenManager/Shop/T2");
        shopT3 = GameObject.Find("ScreenManager/Shop/T3");
        shopT4 = GameObject.Find("ScreenManager/Shop/T4");

        upgradeSelect = GameObject.Find("ScreenManager/Shop/Select");

        // Shop T1 Elements
        engine1check = GameObject.Find("ScreenManager/Shop/T1/EngineUpgrades/Upgrade1/Check");

        engine2lock = GameObject.Find("ScreenManager/Shop/T1/EngineUpgrades/Upgrade2/Lock");
        engine2check = GameObject.Find("ScreenManager/Shop/T1/EngineUpgrades/Upgrade2/Check");

        engine3lock = GameObject.Find("ScreenManager/Shop/T1/EngineUpgrades/Upgrade3/Lock");
        engine3check = GameObject.Find("ScreenManager/Shop/T1/EngineUpgrades/Upgrade3/Check");

        armour1check = GameObject.Find("ScreenManager/Shop/T1/ArmourUpgrades/Upgrade1/Check");

        armour2lock = GameObject.Find("ScreenManager/Shop/T1/ArmourUpgrades/Upgrade2/Lock");
        armour2check = GameObject.Find("ScreenManager/Shop/T1/ArmourUpgrades/Upgrade2/Check");

        armour3lock = GameObject.Find("ScreenManager/Shop/T1/ArmourUpgrades/Upgrade3/Lock");
        armour3check = GameObject.Find("ScreenManager/Shop/T1/ArmourUpgrades/Upgrade3/Check");

        boostSpeed1check = GameObject.Find("ScreenManager/Shop/T1/BoostUpgrades/Upgrade1/Check");
        boostCooldown1check = GameObject.Find("ScreenManager/Shop/T1/BoostUpgrades/Upgrade2/Check");
        boostRecharge1check = GameObject.Find("ScreenManager/Shop/T1/BoostUpgrades/Upgrade3/Check");

        // Shop T2 Elements
        engine4check = GameObject.Find("ScreenManager/Shop/T2/EngineUpgrades/Upgrade1/Check");

        engine5lock = GameObject.Find("ScreenManager/Shop/T2/EngineUpgrades/Upgrade2/Lock");
        engine5check = GameObject.Find("ScreenManager/Shop/T2/EngineUpgrades/Upgrade2/Check");

        engine6lock = GameObject.Find("ScreenManager/Shop/T2/EngineUpgrades/Upgrade3/Lock");
        engine6check = GameObject.Find("ScreenManager/Shop/T2/EngineUpgrades/Upgrade3/Check");

        armour4check = GameObject.Find("ScreenManager/Shop/T2/ArmourUpgrades/Upgrade1/Check");

        armour5lock = GameObject.Find("ScreenManager/Shop/T2/ArmourUpgrades/Upgrade2/Lock");
        armour5check = GameObject.Find("ScreenManager/Shop/T2/ArmourUpgrades/Upgrade2/Check");

        armour6lock = GameObject.Find("ScreenManager/Shop/T2/ArmourUpgrades/Upgrade3/Lock");
        armour6check = GameObject.Find("ScreenManager/Shop/T2/ArmourUpgrades/Upgrade3/Check");

        boostSpeed2check = GameObject.Find("ScreenManager/Shop/T2/BoostUpgrades/Upgrade1/Check");
        boostCooldown2check = GameObject.Find("ScreenManager/Shop/T2/BoostUpgrades/Upgrade2/Check");
        boostRecharge2check = GameObject.Find("ScreenManager/Shop/T2/BoostUpgrades/Upgrade3/Check");

        // Shop T3 Elements
        engine7check = GameObject.Find("ScreenManager/Shop/T3/EngineUpgrades/Upgrade1/Check");

        engine8lock = GameObject.Find("ScreenManager/Shop/T3/EngineUpgrades/Upgrade2/Lock");
        engine8check = GameObject.Find("ScreenManager/Shop/T3/EngineUpgrades/Upgrade2/Check");

        engine9lock = GameObject.Find("ScreenManager/Shop/T3/EngineUpgrades/Upgrade3/Lock");
        engine9check = GameObject.Find("ScreenManager/Shop/T3/EngineUpgrades/Upgrade3/Check");

        armour7check = GameObject.Find("ScreenManager/Shop/T3/ArmourUpgrades/Upgrade1/Check");

        armour8lock = GameObject.Find("ScreenManager/Shop/T3/ArmourUpgrades/Upgrade2/Lock");
        armour8check = GameObject.Find("ScreenManager/Shop/T3/ArmourUpgrades/Upgrade2/Check");

        armour9lock = GameObject.Find("ScreenManager/Shop/T3/ArmourUpgrades/Upgrade3/Lock");
        armour9check = GameObject.Find("ScreenManager/Shop/T3/ArmourUpgrades/Upgrade3/Check");

        boostSpeed3check = GameObject.Find("ScreenManager/Shop/T3/BoostUpgrades/Upgrade1/Check");
        boostCooldown3check = GameObject.Find("ScreenManager/Shop/T3/BoostUpgrades/Upgrade2/Check");
        boostRecharge3check = GameObject.Find("ScreenManager/Shop/T3/BoostUpgrades/Upgrade3/Check");

        // Shop T4 Elements
        engine10check = GameObject.Find("ScreenManager/Shop/T4/EngineUpgrades/Upgrade1/Check");

        engine11lock = GameObject.Find("ScreenManager/Shop/T4/EngineUpgrades/Upgrade2/Lock");
        engine11check = GameObject.Find("ScreenManager/Shop/T4/EngineUpgrades/Upgrade2/Check");

        engine12lock = GameObject.Find("ScreenManager/Shop/T4/EngineUpgrades/Upgrade3/Lock");
        engine12check = GameObject.Find("ScreenManager/Shop/T4/EngineUpgrades/Upgrade3/Check");

        armour10check = GameObject.Find("ScreenManager/Shop/T4/ArmourUpgrades/Upgrade1/Check");

        armour11lock = GameObject.Find("ScreenManager/Shop/T4/ArmourUpgrades/Upgrade2/Lock");
        armour11check = GameObject.Find("ScreenManager/Shop/T4/ArmourUpgrades/Upgrade2/Check");

        armour12lock = GameObject.Find("ScreenManager/Shop/T4/ArmourUpgrades/Upgrade3/Lock");
        armour12check = GameObject.Find("ScreenManager/Shop/T4/ArmourUpgrades/Upgrade3/Check");

        boostSpeed4check = GameObject.Find("ScreenManager/Shop/T4/BoostUpgrades/Upgrade1/Check");
        boostCooldown4check = GameObject.Find("ScreenManager/Shop/T4/BoostUpgrades/Upgrade2/Check");
        boostRecharge4check = GameObject.Find("ScreenManager/Shop/T4/BoostUpgrades/Upgrade3/Check");

        shopIconList = new List<GameObject> { engine1check, engine2lock, engine2check, engine3lock, engine3check, armour1check, armour2lock, armour2check, armour3lock, armour3check, boostSpeed1check, boostCooldown1check, boostRecharge1check, 
                                        engine4check, engine5lock, engine5check, engine6lock, engine6check, armour4check, armour5lock, armour5check, armour6lock, armour6check, boostSpeed2check, boostCooldown2check, boostRecharge2check,
                                        engine7check, engine8lock, engine8check, engine9lock, engine9check, armour7check, armour8lock, armour8check, armour9lock, armour9check, boostSpeed3check, boostCooldown3check, boostRecharge3check,
                                        engine7check, engine8lock, engine8check, engine9lock, engine9check, armour7check, armour8lock, armour8check, armour9lock, armour9check, boostSpeed3check, boostCooldown3check, boostRecharge3check };
        // repair2lock
        // repair3lock
        // 
        // 
        // speech2lock
        // speech3lock

        upgradeName = GameObject.Find("ScreenManager/Shop/DescriptionPanel/UpgradeName").GetComponent<TextMeshProUGUI>();
        upgradeDescription = GameObject.Find("ScreenManager/Shop/DescriptionPanel/UpgradeDescription").GetComponent<TextMeshProUGUI>();
        upgradePrice = GameObject.Find("ScreenManager/Shop/DescriptionPanel/UpgradePrice").GetComponent<TextMeshProUGUI>();
        playerFunds = GameObject.Find("ScreenManager/Shop/DescriptionPanel/PlayerFunds").GetComponent<TextMeshProUGUI>();
        upgradeStatus = GameObject.Find("ScreenManager/Shop/DescriptionPanel/UpgradeStatus").GetComponent<TextMeshProUGUI>();

        purchaseButton = GameObject.Find("ScreenManager/Shop/DescriptionPanel/PurchaseButton");

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

        bulletAmmo = GameObject.Find("ScreenManager/HUD/BulletCooldown/BulletAmmo").GetComponent<TextMeshProUGUI>();
        missleAmmo = GameObject.Find("ScreenManager/HUD/MissleCooldown/MissleAmmo").GetComponent<TextMeshProUGUI>();
        mineAmmo = GameObject.Find("ScreenManager/HUD/MineCooldown/MineAmmo").GetComponent<TextMeshProUGUI>();

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

        screensList = new List<GameObject> { titleScreen, customizePlayer, shop, schoolScreen, armouryScreen, HUD, finishScreen, defeatScreen, raceResultsScreen, earningsScreen, pauseScreen, saveSlotScreen, storyScreen, controlsScreen, raceStartScreen, cupWinnerScreen, storyEndScreen, optionsScreen };

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
                if (!shop.activeSelf) shop.SetActive(true);
                UpdateShopIcons();
                temp = UpgradeManager.GetCurrentUpgrade();
                UpdateUpgradeClicked(temp);
                break;

            case Screen.armoury:
                if (!armouryScreen.activeSelf) armouryScreen.SetActive(true);
                //UpdateUpgradeIcons();
                //temp = UpgradeManager.GetCurrentUpgrade();
                //UpdateUpgradeClicked(temp);
                break;

            case Screen.school:
                if (!schoolScreen.activeSelf) schoolScreen.SetActive(true);
                //UpdateUpgradeIcons();
                //temp = UpgradeManager.GetCurrentUpgrade();
                //UpdateUpgradeClicked(temp);
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

    public static void UpdateShopIcons()
    {
        int engineLevel = playerController.EngineUpgradeLevel;
        int armourLevel = playerController.ArmourUpgradeLevel;
        int boostSpeedLevel = playerController.BoostSpeedLevel;
        int boostCooldownLevel = playerController.BoostCooldownLevel;
        int boostRechargeLevel = playerController.BoostRechargeLevel;


        foreach (GameObject icon in shopIconList)
        {
            icon.SetActive(false);
        }

        switch(GameManager.GameLevel)
        {
            case 0:
                shopT1.SetActive(true);
                shopT2.SetActive(false);
                shopT3.SetActive(false);
                shopT4.SetActive(false);
                break;

            case 1:
                shopT1.SetActive(false);
                shopT2.SetActive(true);
                shopT3.SetActive(false);
                shopT4.SetActive(false);
                break;

            case 2:
                shopT1.SetActive(false);
                shopT2.SetActive(false);
                shopT3.SetActive(true);
                shopT4.SetActive(false);
                break;

            case 3:
                shopT1.SetActive(false);
                shopT2.SetActive(false);
                shopT3.SetActive(false);
                shopT4.SetActive(true);
                break;
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

                engine5lock.SetActive(true);
                engine6lock.SetActive(true);
                break;

            case 4:
                engine4check.SetActive(true);
                engine6lock.SetActive(true);
                break;
            case 5:
                engine4check.SetActive(true);
                engine6lock.SetActive(true);
                break;
            case 6:
                engine4check.SetActive(true);
                engine5check.SetActive(true);
                engine6check.SetActive(true);

                //engine8lock.SetActive(true);
                //engine9lock.SetActive(true);
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

                if (cupButtonsPanel.activeSelf) cupButtonsPanel.SetActive(false);
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

                startTitleText.text = "BRONZE CUP\n(Level 1)";
                startDescText.text = "Win 1st place to move up to the Silver Cup!";
                break;

            case 1:
                if (startBronze.activeSelf) startBronze.SetActive(false);
                if (!startSilver.activeSelf) startSilver.SetActive(true);
                if (startGold.activeSelf) startGold.SetActive(false);
                if (startChamp.activeSelf) startChamp.SetActive(false);

                startTitleText.text = "SILVER CUP\n(Level 2)";
                startDescText.text = "Win 1st place to move up to the Gold Cup!";
                break;

            case 2:
                if (startBronze.activeSelf) startBronze.SetActive(false);
                if (startSilver.activeSelf) startSilver.SetActive(false);
                if (!startGold.activeSelf) startGold.SetActive(true);
                if (startChamp.activeSelf) startChamp.SetActive(false);

                startTitleText.text = "GOLD CUP\n(Level 3)";
                startDescText.text = "Win 1st place to move up to the Championship Cup!";
                break;

            case 3:
                if (startBronze.activeSelf) startBronze.SetActive(false);
                if (startSilver.activeSelf) startSilver.SetActive(false);
                if (startGold.activeSelf) startGold.SetActive(false);
                if (!startChamp.activeSelf) startChamp.SetActive(true);

                startTitleText.text = "CHAMPIONSHIP CUP\n(Final Level)";
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
