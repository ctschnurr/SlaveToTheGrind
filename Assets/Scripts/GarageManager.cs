using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class GarageManager : MonoBehaviour
{
    public enum UpgradeCategory
    {
        engine,
        armour,
        boost
    }

    public UpgradeCategory currentCategory = UpgradeCategory.engine;
    public int currentSelectedLevel = 0;
    // Start is called before the first frame update

    PlayerController player;

    static Upgrade engine1;
    static Upgrade engine2;
    static Upgrade engine3;
    static Upgrade engine4;
    static Upgrade engine5;
    static Upgrade engine6;
    static Upgrade engine7;
    static Upgrade engine8;
    static Upgrade engine9;
    static Upgrade engine10;
    static Upgrade engine11;
    static Upgrade engine12;

    static Upgrade armour1;
    static Upgrade armour2;
    static Upgrade armour3;
    static Upgrade armour4;
    static Upgrade armour5;
    static Upgrade armour6;
    static Upgrade armour7;
    static Upgrade armour8;
    static Upgrade armour9;
    static Upgrade armour10;
    static Upgrade armour11;
    static Upgrade armour12;
     
    static Upgrade boostSpeed1;
    static Upgrade boostSpeed2;
    static Upgrade boostSpeed3;
    static Upgrade boostSpeed4;
     
    static Upgrade boostCooldown1;
    static Upgrade boostCooldown2;
    static Upgrade boostCooldown3;
    static Upgrade boostCooldown4;
     
    static Upgrade boostRecharge1;
    static Upgrade boostRecharge2;
    static Upgrade boostRecharge3;
    static Upgrade boostRecharge4;

    private List<Upgrade> upgradeList;

    static Upgrade currentUpgrade;

    static GameObject upgradeSelect;

    static GameObject garageT1;
    static GameObject garageT2;
    static GameObject garageT3;
    static GameObject garageT4;

    // T1 Garage Elements:
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

    // T2 Garage Elements:
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

    // T3 Garage Elements
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

    // T4 Garage Elements
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
    static List<GameObject> garageIconList;

    static PlayerController playerController;

    void StartElements()
    {
        garageT1 = GameObject.Find("Garage/T1");
        garageT2 = GameObject.Find("Garage/T2");
        garageT3 = GameObject.Find("Garage/T3");
        garageT4 = GameObject.Find("Garage/T4");

        upgradeSelect = GameObject.Find("ScreenManager/Garage/Select");

        // Garage T1 Elements
        engine1check = GameObject.Find("ScreenManager/Garage/T1/EngineUpgrades/Upgrade1/Check");

        engine2lock = GameObject.Find("ScreenManager/Garage/T1/EngineUpgrades/Upgrade2/Lock");
        engine2check = GameObject.Find("ScreenManager/Garage/T1/EngineUpgrades/Upgrade2/Check");

        engine3lock = GameObject.Find("ScreenManager/Garage/T1/EngineUpgrades/Upgrade3/Lock");
        engine3check = GameObject.Find("ScreenManager/Garage/T1/EngineUpgrades/Upgrade3/Check");

        armour1check = GameObject.Find("ScreenManager/Garage/T1/ArmourUpgrades/Upgrade1/Check");

        armour2lock = GameObject.Find("ScreenManager/Garage/T1/ArmourUpgrades/Upgrade2/Lock");
        armour2check = GameObject.Find("ScreenManager/Garage/T1/ArmourUpgrades/Upgrade2/Check");

        armour3lock = GameObject.Find("ScreenManager/Garage/T1/ArmourUpgrades/Upgrade3/Lock");
        armour3check = GameObject.Find("ScreenManager/Garage/T1/ArmourUpgrades/Upgrade3/Check");

        boostSpeed1check = GameObject.Find("ScreenManager/Garage/T1/BoostUpgrades/Upgrade1/Check");
        boostCooldown1check = GameObject.Find("ScreenManager/Garage/T1/BoostUpgrades/Upgrade2/Check");
        boostRecharge1check = GameObject.Find("ScreenManager/Garage/T1/BoostUpgrades/Upgrade3/Check");

        // Garage T2 Elements
        engine4check = GameObject.Find("ScreenManager/Garage/T2/EngineUpgrades/Upgrade1/Check");

        engine5lock = GameObject.Find("ScreenManager/Garage/T2/EngineUpgrades/Upgrade2/Lock");
        engine5check = GameObject.Find("ScreenManager/Garage/T2/EngineUpgrades/Upgrade2/Check");

        engine6lock = GameObject.Find("ScreenManager/Garage/T2/EngineUpgrades/Upgrade3/Lock");
        engine6check = GameObject.Find("ScreenManager/Garage/T2/EngineUpgrades/Upgrade3/Check");

        armour4check = GameObject.Find("ScreenManager/Garage/T2/ArmourUpgrades/Upgrade1/Check");

        armour5lock = GameObject.Find("ScreenManager/Garage/T2/ArmourUpgrades/Upgrade2/Lock");
        armour5check = GameObject.Find("ScreenManager/Garage/T2/ArmourUpgrades/Upgrade2/Check");

        armour6lock = GameObject.Find("ScreenManager/Garage/T2/ArmourUpgrades/Upgrade3/Lock");
        armour6check = GameObject.Find("ScreenManager/Garage/T2/ArmourUpgrades/Upgrade3/Check");

        boostSpeed2check = GameObject.Find("ScreenManager/Garage/T2/BoostUpgrades/Upgrade1/Check");
        boostCooldown2check = GameObject.Find("ScreenManager/Garage/T2/BoostUpgrades/Upgrade2/Check");
        boostRecharge2check = GameObject.Find("ScreenManager/Garage/T2/BoostUpgrades/Upgrade3/Check");

        // Garage T3 Elements
        engine7check = GameObject.Find("ScreenManager/Garage/T3/EngineUpgrades/Upgrade1/Check");

        engine8lock = GameObject.Find("ScreenManager/Garage/T3/EngineUpgrades/Upgrade2/Lock");
        engine8check = GameObject.Find("ScreenManager/Garage/T3/EngineUpgrades/Upgrade2/Check");

        engine9lock = GameObject.Find("ScreenManager/Garage/T3/EngineUpgrades/Upgrade3/Lock");
        engine9check = GameObject.Find("ScreenManager/Garage/T3/EngineUpgrades/Upgrade3/Check");

        armour7check = GameObject.Find("ScreenManager/Garage/T3/ArmourUpgrades/Upgrade1/Check");

        armour8lock = GameObject.Find("ScreenManager/Garage/T3/ArmourUpgrades/Upgrade2/Lock");
        armour8check = GameObject.Find("ScreenManager/Garage/T3/ArmourUpgrades/Upgrade2/Check");

        armour9lock = GameObject.Find("ScreenManager/Garage/T3/ArmourUpgrades/Upgrade3/Lock");
        armour9check = GameObject.Find("ScreenManager/Garage/T3/ArmourUpgrades/Upgrade3/Check");

        boostSpeed3check = GameObject.Find("ScreenManager/Garage/T3/BoostUpgrades/Upgrade1/Check");
        boostCooldown3check = GameObject.Find("ScreenManager/Garage/T3/BoostUpgrades/Upgrade2/Check");
        boostRecharge3check = GameObject.Find("ScreenManager/Garage/T3/BoostUpgrades/Upgrade3/Check");

        // Garage T4 Elements
        engine10check = GameObject.Find("ScreenManager/Garage/T4/EngineUpgrades/Upgrade1/Check");

        engine11lock = GameObject.Find("ScreenManager/Garage/T4/EngineUpgrades/Upgrade2/Lock");
        engine11check = GameObject.Find("ScreenManager/Garage/T4/EngineUpgrades/Upgrade2/Check");

        engine12lock = GameObject.Find("ScreenManager/Garage/T4/EngineUpgrades/Upgrade3/Lock");
        engine12check = GameObject.Find("ScreenManager/Garage/T4/EngineUpgrades/Upgrade3/Check");

        armour10check = GameObject.Find("ScreenManager/Garage/T4/ArmourUpgrades/Upgrade1/Check");

        armour11lock = GameObject.Find("ScreenManager/Garage/T4/ArmourUpgrades/Upgrade2/Lock");
        armour11check = GameObject.Find("ScreenManager/Garage/T4/ArmourUpgrades/Upgrade2/Check");

        armour12lock = GameObject.Find("ScreenManager/Garage/T4/ArmourUpgrades/Upgrade3/Lock");
        armour12check = GameObject.Find("ScreenManager/Garage/T4/ArmourUpgrades/Upgrade3/Check");

        boostSpeed4check = GameObject.Find("ScreenManager/Garage/T4/BoostUpgrades/Upgrade1/Check");
        boostCooldown4check = GameObject.Find("ScreenManager/Garage/T4/BoostUpgrades/Upgrade2/Check");
        boostRecharge4check = GameObject.Find("ScreenManager/Garage/T4/BoostUpgrades/Upgrade3/Check");

        garageIconList = new List<GameObject>
        {
            engine1check, engine2lock, engine2check, engine3lock, engine3check, armour1check, armour2lock, armour2check, armour3lock, armour3check, boostSpeed1check, boostCooldown1check, boostRecharge1check,
            engine4check, engine5lock, engine5check, engine6lock, engine6check, armour4check, armour5lock, armour5check, armour6lock, armour6check, boostSpeed2check, boostCooldown2check, boostRecharge2check,
            engine7check, engine8lock, engine8check, engine9lock, engine9check, armour7check, armour8lock, armour8check, armour9lock, armour9check, boostSpeed3check, boostCooldown3check, boostRecharge3check,
            engine10check, engine11lock, engine11check, engine12lock, engine12check, armour10check, armour11lock, armour11check, armour12lock, armour12check, boostSpeed4check, boostCooldown4check, boostRecharge4check
        };
    }
    public void SetupGarage()
    {
        StartElements();

        engine1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.engine,
            state = Upgrade.State.available,
            name = "Tune-Up",
            description = "Basic maintenance. Increases speed.",
            price = 100
        };

        engine2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.engine,
            state = Upgrade.State.locked,
            name = "New Engine",
            description = "Better than old junk. Increases speed again.",
            price = 200
        };

        engine3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.engine,
            state = Upgrade.State.locked,
            name = "Modify Engine",
            description = "Performance tweaks. Further increases speed.",
            price = 300
        };

        engine4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.engine,
            state = Upgrade.State.available,
            name = "Engine Level IV",
            description = "Speed +4",
            price = 200
        };

        engine5 = new Upgrade
        {
            upgradeNumber = 5,
            category = Upgrade.Category.engine,
            state = Upgrade.State.locked,
            name = "Engine Level V",
            description = "Speed +5",
            price = 300
        };

        engine6 = new Upgrade
        {
            upgradeNumber = 6,
            category = Upgrade.Category.engine,
            state = Upgrade.State.locked,
            name = "Engine Level VI",
            description = "Speed +6",
            price = 400
        };

        engine7 = new Upgrade
        {
            upgradeNumber = 7,
            category = Upgrade.Category.engine,
            state = Upgrade.State.available,
            name = "Engine Level VII",
            description = "Speed +7",
            price = 300
        };

        engine8 = new Upgrade
        {
            upgradeNumber = 8,
            category = Upgrade.Category.engine,
            state = Upgrade.State.locked,
            name = "Engine Level VIII",
            description = "Speed +8",
            price = 400
        };

        engine9 = new Upgrade
        {
            upgradeNumber = 9,
            category = Upgrade.Category.engine,
            state = Upgrade.State.locked,
            name = "Engine Level IX",
            description = "Speed +9",
            price = 500
        };

        engine10 = new Upgrade
        {
            upgradeNumber = 10,
            category = Upgrade.Category.engine,
            state = Upgrade.State.available,
            name = "Engine Level X",
            description = "Speed +10",
            price = 400
        };

        engine11 = new Upgrade
        {
            upgradeNumber = 11,
            category = Upgrade.Category.engine,
            state = Upgrade.State.locked,
            name = "Engine Level XI",
            description = "Speed +11",
            price = 500
        };

        engine12 = new Upgrade
        {
            upgradeNumber = 12,
            category = Upgrade.Category.engine,
            state = Upgrade.State.locked,
            name = "Engine Level XII",
            description = "Speed +12",
            price = 600
        };

        armour1 = new Upgrade();
        armour1.upgradeNumber = 1;
        armour1.category = Upgrade.Category.armour;
        armour1.state = Upgrade.State.available;
        armour1.name = "Fix Holes";
        armour1.description = "Patch up your car's body. Decreases damage.";
        armour1.price = 100;

        armour2 = new Upgrade();
        armour2.upgradeNumber = 2;
        armour2.category = Upgrade.Category.armour;
        armour2.state = Upgrade.State.locked;
        armour2.name = "Added Plating";
        armour2.description = "Extra protection. Decreases damage more.";
        armour2.price = 200;

        armour3 = new Upgrade();
        armour3.upgradeNumber = 3;
        armour3.category = Upgrade.Category.armour;
        armour3.state = Upgrade.State.locked;
        armour3.name = "Vehicle Armour";
        armour3.description = "Reinforced for extra strength. Decreases damage further.";
        armour3.price = 400;

        armour4 = new Upgrade();
        armour4.upgradeNumber = 4;
        armour4.category = Upgrade.Category.armour;
        armour4.state = Upgrade.State.available;
        armour4.name = "Armour Level IV";
        armour4.description = "Damage -4";
        armour4.price = 200;

        armour5 = new Upgrade();
        armour5.upgradeNumber = 5;
        armour5.category = Upgrade.Category.armour;
        armour5.state = Upgrade.State.locked;
        armour5.name = "Armour Level V";
        armour5.description = "Damage -5";
        armour5.price = 300;

        armour6 = new Upgrade();
        armour6.upgradeNumber = 6;
        armour6.category = Upgrade.Category.armour;
        armour6.state = Upgrade.State.locked;
        armour6.name = "Armour Level VI";
        armour6.description = "Damage -6";
        armour6.price = 400;

        armour7 = new Upgrade();
        armour7.upgradeNumber = 7;
        armour7.category = Upgrade.Category.armour;
        armour7.state = Upgrade.State.available;
        armour7.name = "Armour Level VII";
        armour7.description = "Damage -7";
        armour7.price = 300;

        armour8 = new Upgrade();
        armour8.upgradeNumber = 8;
        armour8.category = Upgrade.Category.armour;
        armour8.state = Upgrade.State.locked;
        armour8.name = "Armour Level VIII";
        armour8.description = "Damage -8";
        armour8.price = 400;

        armour9 = new Upgrade();
        armour9.upgradeNumber = 9;
        armour9.category = Upgrade.Category.armour;
        armour9.state = Upgrade.State.locked;
        armour9.name = "Armour Level IX";
        armour9.description = "Damage -9";
        armour9.price = 500;

        armour10 = new Upgrade();
        armour10.upgradeNumber = 10;
        armour10.category = Upgrade.Category.armour;
        armour10.state = Upgrade.State.available;
        armour10.name = "Armour Level X";
        armour10.description = "Damage -10";
        armour10.price = 400;

        armour11 = new Upgrade();
        armour11.upgradeNumber = 11;
        armour11.category = Upgrade.Category.armour;
        armour11.state = Upgrade.State.locked;
        armour11.name = "Armour Level XI";
        armour11.description = "Damage -11";
        armour11.price = 500;

        armour12 = new Upgrade();
        armour12.upgradeNumber = 12;
        armour12.category = Upgrade.Category.armour;
        armour12.state = Upgrade.State.locked;
        armour12.name = "Armour Level XII";
        armour12.description = "Damage -12";
        armour12.price = 600;

        boostSpeed1 = new Upgrade();
        boostSpeed1.upgradeNumber = 1;
        boostSpeed1.category = Upgrade.Category.boostSpeed;
        boostSpeed1.state = Upgrade.State.available;
        boostSpeed1.name = "Filtered Fuel";
        boostSpeed1.description = "Slightly cleaner burning. Increases boost speed.";
        boostSpeed1.price = 200;

        boostSpeed2 = new Upgrade();
        boostSpeed2.upgradeNumber = 2;
        boostSpeed2.category = Upgrade.Category.boostSpeed;
        boostSpeed2.state = Upgrade.State.available;
        boostSpeed2.name = "Boost Speed II";
        boostSpeed2.description = "Boost Speed +2";
        boostSpeed2.price = 300;

        boostSpeed3 = new Upgrade();
        boostSpeed3.upgradeNumber = 3;
        boostSpeed3.category = Upgrade.Category.boostSpeed;
        boostSpeed3.state = Upgrade.State.available;
        boostSpeed3.name = "Boost Speed III";
        boostSpeed3.description = "Boost Speed +3";
        boostSpeed3.price = 400;

        boostSpeed4 = new Upgrade();
        boostSpeed4.upgradeNumber = 4;
        boostSpeed4.category = Upgrade.Category.boostSpeed;
        boostSpeed4.state = Upgrade.State.available;
        boostSpeed4.name = "Boost Speed IV";
        boostSpeed4.description = "Boost Speed +4";
        boostSpeed4.price = 500;

        boostCooldown1 = new Upgrade();
        boostCooldown1.upgradeNumber = 1;
        boostCooldown1.category = Upgrade.Category.boostCooldown;
        boostCooldown1.state = Upgrade.State.available;
        boostCooldown1.name = "Calibrate Booster";
        boostCooldown1.description = "A little fine-tuning. Decreases boost cooldown.";
        boostCooldown1.price = 250;

        boostCooldown2 = new Upgrade();
        boostCooldown2.upgradeNumber = 2;
        boostCooldown2.category = Upgrade.Category.boostCooldown;
        boostCooldown2.state = Upgrade.State.available;
        boostCooldown2.name = "Boost Cooldown II";
        boostCooldown2.description = "Boost Cooldown -2";
        boostCooldown2.price = 300;

        boostCooldown3 = new Upgrade();
        boostCooldown3.upgradeNumber = 3;
        boostCooldown3.category = Upgrade.Category.boostCooldown;
        boostCooldown3.state = Upgrade.State.available;
        boostCooldown3.name = "Boost Cooldown III";
        boostCooldown3.description = "Boost Cooldown -3";
        boostCooldown3.price = 400;

        boostCooldown4 = new Upgrade();
        boostCooldown4.upgradeNumber = 4;
        boostCooldown4.category = Upgrade.Category.boostCooldown;
        boostCooldown4.state = Upgrade.State.available;
        boostCooldown4.name = "Boost Cooldown IV";
        boostCooldown4.description = "Boost Cooldown -4";
        boostCooldown4.price = 500;

        boostRecharge1 = new Upgrade();
        boostRecharge1.upgradeNumber = 1;
        boostRecharge1.category = Upgrade.Category.boostRecharge;
        boostRecharge1.state = Upgrade.State.available;
        boostRecharge1.name = "Second-Hand Parts";
        boostRecharge1.description = "Better than yours. Increases boost recharge speed.";
        boostRecharge1.price = 250;

        boostRecharge2 = new Upgrade();
        boostRecharge2.upgradeNumber = 2;
        boostRecharge2.category = Upgrade.Category.boostRecharge;
        boostRecharge2.state = Upgrade.State.available;
        boostRecharge2.name = "Boost Recharge II";
        boostRecharge2.description = "Boost Recharge +2";
        boostRecharge2.price = 300;

        boostRecharge3 = new Upgrade();
        boostRecharge3.upgradeNumber = 3;
        boostRecharge3.category = Upgrade.Category.boostRecharge;
        boostRecharge3.state = Upgrade.State.available;
        boostRecharge3.name = "Boost Recharge III";
        boostRecharge3.description = "Boost Recharge +3";
        boostRecharge3.price = 400;

        boostRecharge4 = new Upgrade();
        boostRecharge4.upgradeNumber = 4;
        boostRecharge4.category = Upgrade.Category.boostRecharge;
        boostRecharge4.state = Upgrade.State.available;
        boostRecharge4.name = "Boost Recharge IV";
        boostRecharge4.description = "Boost Recharge +4";
        boostRecharge4.price = 500;

        upgradeList = new List<Upgrade>()
        {
            engine1, engine2, engine3, engine4, engine5, engine6, engine7, engine8, engine9, engine10, engine11, engine12,
            armour1, armour2, armour3, armour4, armour5, armour6, armour7, armour8, armour9, armour10, armour11, armour12,
            boostSpeed1, boostSpeed2, boostSpeed3, boostSpeed4,
            boostCooldown1, boostCooldown2, boostCooldown3, boostCooldown4,
            boostRecharge1, boostRecharge2, boostRecharge3, boostRecharge4
        };

        currentUpgrade = engine1;
    }

    public static void UpdateShopIcons()
    {
        if (playerController == null) playerController = GameObject.Find("PlayerRacer").GetComponent<PlayerController>();

        int engineLevel = playerController.EngineUpgradeLevel;
        int armourLevel = playerController.ArmourUpgradeLevel;
        int boostSpeedLevel = playerController.BoostSpeedLevel;
        int boostCooldownLevel = playerController.BoostCooldownLevel;
        int boostRechargeLevel = playerController.BoostRechargeLevel;

        foreach (GameObject icon in garageIconList)
        {
            icon.SetActive(false);
        }

        switch (GameManager.GameLevel)
        {
            case 0:
                garageT1.SetActive(true);
                garageT2.SetActive(false);
                garageT3.SetActive(false);
                garageT4.SetActive(false);
                break;

            case 1:
                garageT1.SetActive(false);
                garageT2.SetActive(true);
                garageT3.SetActive(false);
                garageT4.SetActive(false);
                break;

            case 2:
                garageT1.SetActive(false);
                garageT2.SetActive(false);
                garageT3.SetActive(true);
                garageT4.SetActive(false);
                break;

            case 3:
                garageT1.SetActive(false);
                garageT2.SetActive(false);
                garageT3.SetActive(false);
                garageT4.SetActive(true);
                break;
        }

        switch (engineLevel)
        {
            case 0:
                //engine 1 available
                engine2lock.SetActive(true);
                engine3lock.SetActive(true);
                break;
            case 1:
                engine1check.SetActive(true);
                //engine 2 available
                engine3lock.SetActive(true);
                break;
            case 2:
                engine1check.SetActive(true);
                engine2check.SetActive(true);
                //engine 3 available
                break;
            case 3:
                engine1check.SetActive(true);
                engine2check.SetActive(true);
                engine3check.SetActive(true);
                // engine 4 available
                engine5lock.SetActive(true);
                engine6lock.SetActive(true);
                break;
            case 4:
                engine4check.SetActive(true);
                //engine 5 available
                engine6lock.SetActive(true);
                break;
            case 5:
                engine4check.SetActive(true);
                engine5check.SetActive(true);
                //engine 6 available
                break;
            case 6:
                engine4check.SetActive(true);
                engine5check.SetActive(true);
                engine6check.SetActive(true);
                // engine 7 available
                engine8lock.SetActive(true);
                engine9lock.SetActive(true);
                break;
            case 7:
                engine7check.SetActive(true);
                //engine 8 available
                engine9lock.SetActive(true);
                break;
            case 8:
                engine7check.SetActive(true);
                engine8check.SetActive(true);
                //engine 9 available
                break;
            case 9:
                engine7check.SetActive(true);
                engine8check.SetActive(true);
                engine9check.SetActive(true);
                //engine 10 available
                engine11lock.SetActive(true);
                engine12lock.SetActive(true);
                break;
            case 10:
                engine10check.SetActive(true);
                //engine 11 available
                engine12lock.SetActive(true);
                break;
            case 11:
                engine10check.SetActive(true);
                engine11check.SetActive(true);
                //engine 12 available
                break;
            case 12:
                engine10check.SetActive(true);
                engine11check.SetActive(true);
                engine12check.SetActive(true);
                break;

        }

        switch (armourLevel)
        {
            case 0:
                //armour 1 available
                armour2lock.SetActive(true);
                armour3lock.SetActive(true);
                break;
            case 1:
                armour1check.SetActive(true);
                //armour 2 available
                armour3lock.SetActive(true);
                break;
            case 2:
                armour1check.SetActive(true);
                armour2check.SetActive(true);
                //armour 3 available
                break;
            case 3:
                armour1check.SetActive(true);
                armour2check.SetActive(true);
                armour3check.SetActive(true);
                // armour 4 available
                armour5lock.SetActive(true);
                armour6lock.SetActive(true);
                break;
            case 4:
                armour4check.SetActive(true);
                //armour 5 available
                armour6lock.SetActive(true);
                break;
            case 5:
                armour4check.SetActive(true);
                armour5check.SetActive(true);
                //armour 6 available
                break;
            case 6:
                armour4check.SetActive(true);
                armour5check.SetActive(true);
                armour6check.SetActive(true);
                // armour 7 available
                armour8lock.SetActive(true);
                armour9lock.SetActive(true);
                break;
            case 7:
                armour7check.SetActive(true);
                //armour 8 available
                armour9lock.SetActive(true);
                break;
            case 8:
                armour7check.SetActive(true);
                armour8check.SetActive(true);
                //armour 9 available
                break;
            case 9:
                armour7check.SetActive(true);
                armour8check.SetActive(true);
                armour9check.SetActive(true);
                //armour 10 available
                armour11lock.SetActive(true);
                armour12lock.SetActive(true);
                break;
            case 10:
                armour10check.SetActive(true);
                //armour 11 available
                armour12lock.SetActive(true);
                break;
            case 11:
                armour10check.SetActive(true);
                armour11check.SetActive(true);
                //armour 12 available
                break;
            case 12:
                armour10check.SetActive(true);
                armour11check.SetActive(true);
                armour12check.SetActive(true);
                break;
        }

        switch (boostSpeedLevel)
        {
            case 1:
                boostSpeed1check.SetActive(true);
                break;
            case 2:
                boostSpeed1check.SetActive(true);
                boostSpeed2check.SetActive(true);
                break;
            case 3:
                boostSpeed1check.SetActive(true);
                boostSpeed2check.SetActive(true);
                boostSpeed3check.SetActive(true);
                break;
            case 4:
                boostSpeed1check.SetActive(true);
                boostSpeed2check.SetActive(true);
                boostSpeed3check.SetActive(true);
                boostSpeed4check.SetActive(true);
                break;
        }

        switch (boostCooldownLevel)
        {
            case 1:
                boostCooldown1check.SetActive(true);
                break;
            case 2:
                boostCooldown1check.SetActive(true);
                boostCooldown2check.SetActive(true);
                break;
            case 3:
                boostCooldown1check.SetActive(true);
                boostCooldown2check.SetActive(true);
                boostCooldown3check.SetActive(true);
                break;
            case 4:
                boostCooldown1check.SetActive(true);
                boostCooldown2check.SetActive(true);
                boostCooldown3check.SetActive(true);
                boostCooldown4check.SetActive(true);
                break;
        }

        switch (boostRechargeLevel)
        {
            case 1:
                boostRecharge1check.SetActive(true);
                break;
            case 2:
                boostRecharge1check.SetActive(true);
                boostRecharge2check.SetActive(true);
                break;
            case 3:
                boostCooldown1check.SetActive(true);
                boostRecharge2check.SetActive(true);
                boostRecharge3check.SetActive(true);
                break;
            case 4:
                boostCooldown1check.SetActive(true);
                boostRecharge2check.SetActive(true);
                boostRecharge3check.SetActive(true);
                boostRecharge4check.SetActive(true);
                break;
        }
    }

    public static Upgrade GetDefaultUpgrade()
    {
        switch (GameManager.GameLevel)
        {
            case 0:
                return engine1;
            case 1:
                return engine4;
            case 2:
                return engine7;
            case 3:
                return engine10;
            default:
                return engine1;
        }
    }

    public void EngineUpgradeClicked(int levelButton)
    {
        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateUpgradeClicked(engine1);
                currentUpgrade = engine1;
                break;
            case 2:
                ScreenManager.UpdateUpgradeClicked(engine2);
                currentUpgrade = engine2;
                break;
            case 3:
                ScreenManager.UpdateUpgradeClicked(engine3);
                currentUpgrade = engine3;
                break;
            case 4:
                ScreenManager.UpdateUpgradeClicked(engine4);
                currentUpgrade = engine4;
                break;
            case 5:
                ScreenManager.UpdateUpgradeClicked(engine5);
                currentUpgrade = engine5;
                break;
            case 6:
                ScreenManager.UpdateUpgradeClicked(engine6);
                currentUpgrade = engine6;
                break;
            case 7:
                ScreenManager.UpdateUpgradeClicked(engine7);
                currentUpgrade = engine7;
                break;
            case 8:
                ScreenManager.UpdateUpgradeClicked(engine8);
                currentUpgrade = engine8;
                break;
            case 9:
                ScreenManager.UpdateUpgradeClicked(engine9);
                currentUpgrade = engine9;
                break;
            case 10:
                ScreenManager.UpdateUpgradeClicked(engine10);
                currentUpgrade = engine10;
                break;
            case 11:
                ScreenManager.UpdateUpgradeClicked(engine11);
                currentUpgrade = engine11;
                break;
            case 12:
                ScreenManager.UpdateUpgradeClicked(engine12);
                currentUpgrade = engine12;
                break;
        }
        UpdateSelectedIcon(currentUpgrade);
    }

    public void ArmourUpgradeClicked(int levelButton)
    {
        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateUpgradeClicked(armour1);
                currentUpgrade = armour1;
                break;
            case 2:
                ScreenManager.UpdateUpgradeClicked(armour2);
                currentUpgrade = armour2;
                break;
            case 3:
                ScreenManager.UpdateUpgradeClicked(armour3);
                currentUpgrade = armour3;
                break;
            case 4:
                ScreenManager.UpdateUpgradeClicked(armour4);
                currentUpgrade = armour4;
                break;
            case 5:
                ScreenManager.UpdateUpgradeClicked(armour5);
                currentUpgrade = armour5;
                break;
            case 6:
                ScreenManager.UpdateUpgradeClicked(armour6);
                currentUpgrade = armour6;
                break;
            case 7:
                ScreenManager.UpdateUpgradeClicked(armour7);
                currentUpgrade = armour7;
                break;
            case 8:
                ScreenManager.UpdateUpgradeClicked(armour8);
                currentUpgrade = armour8;
                break;
            case 9:
                ScreenManager.UpdateUpgradeClicked(armour9);
                currentUpgrade = armour9;
                break;
            case 10:
                ScreenManager.UpdateUpgradeClicked(armour10);
                currentUpgrade = armour10;
                break;
            case 11:
                ScreenManager.UpdateUpgradeClicked(armour11);
                currentUpgrade = armour11;
                break;
            case 12:
                ScreenManager.UpdateUpgradeClicked(armour12);
                currentUpgrade = armour12;
                break;
        }
        UpdateSelectedIcon(currentUpgrade);
    }

    public void BoostSpeedUpgradeClicked(int levelButton)
    {

        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateUpgradeClicked(boostSpeed1);
                currentUpgrade = boostSpeed1;
                break;
            case 2:
                ScreenManager.UpdateUpgradeClicked(boostSpeed2);
                currentUpgrade = boostSpeed2;
                break;
            case 3:
                ScreenManager.UpdateUpgradeClicked(boostSpeed3);
                currentUpgrade = boostSpeed3;
                break;
            case 4:
                ScreenManager.UpdateUpgradeClicked(boostSpeed4);
                currentUpgrade = boostSpeed4;
                break;
        }
        UpdateSelectedIcon(currentUpgrade);
    }

    public void BoostCooldownUpgradeClicked(int levelButton)
    {
        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateUpgradeClicked(boostCooldown1);
                currentUpgrade = boostCooldown1;
                break;
            case 2:
                ScreenManager.UpdateUpgradeClicked(boostCooldown2);
                currentUpgrade = boostCooldown2;
                break;
            case 3:
                ScreenManager.UpdateUpgradeClicked(boostCooldown3);
                currentUpgrade = boostCooldown3;
                break;
            case 4:
                ScreenManager.UpdateUpgradeClicked(boostCooldown4);
                currentUpgrade = boostCooldown4;
                break;
        }
        UpdateSelectedIcon(currentUpgrade);
    }

    public void BoostRechargeUpgradeClicked(int levelButton)
    {
        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateUpgradeClicked(boostRecharge1);
                currentUpgrade = boostRecharge1;
                break;
            case 2:
                ScreenManager.UpdateUpgradeClicked(boostRecharge2);
                currentUpgrade = boostRecharge2;
                break;
            case 3:
                ScreenManager.UpdateUpgradeClicked(boostRecharge3);
                currentUpgrade = boostRecharge3;
                break;
            case 4:
                ScreenManager.UpdateUpgradeClicked(boostRecharge4);
                currentUpgrade = boostRecharge4;
                break;
        }
        UpdateSelectedIcon(currentUpgrade);
    }

    public void PurchaseClicked()
    {
        player = GameObject.Find("PlayerRacer").GetComponent<PlayerController>();
        switch(currentUpgrade.category)
        {
            case Upgrade.Category.engine:
                player.SpendMoney(currentUpgrade.price);
                player.EngineUpgradeLevel = currentUpgrade.upgradeNumber;
                break;

            case Upgrade.Category.armour:
                player.SpendMoney(currentUpgrade.price);
                player.ArmourUpgradeLevel = currentUpgrade.upgradeNumber;
                break;

            case Upgrade.Category.boostSpeed:
                player.SpendMoney(currentUpgrade.price);
                player.BoostSpeedLevel = currentUpgrade.upgradeNumber;
                break;

            case Upgrade.Category.boostCooldown:
                player.SpendMoney(currentUpgrade.price);
                player.BoostCooldownLevel = currentUpgrade.upgradeNumber;
                break;

            case Upgrade.Category.boostRecharge:
                player.SpendMoney(currentUpgrade.price);
                player.BoostRechargeLevel = currentUpgrade.upgradeNumber;
                break;
        }

        if(currentUpgrade.upgradeNumber < 3)
        {
            foreach(Upgrade nextUpgrade in upgradeList)
            {
                if (nextUpgrade.category == currentUpgrade.category && nextUpgrade.upgradeNumber == currentUpgrade.upgradeNumber + 1) nextUpgrade.state = Upgrade.State.available;
            }
        }

        currentUpgrade.state = Upgrade.State.owned;

        UpdateShopIcons();
        ScreenManager.UpdateUpgradeClicked(currentUpgrade);
        UpdateSelectedIcon(currentUpgrade);
    }

    static void UpdateSelectedIcon(Upgrade input)
    {
        if (!upgradeSelect.activeSelf) upgradeSelect.SetActive(true);

        switch (input.category)
        {
            case Upgrade.Category.engine:
                if (input.upgradeNumber == 1 || input.upgradeNumber == 4 || input.upgradeNumber == 7 || input.upgradeNumber == 10) upgradeSelect.transform.position = engine1check.transform.position;
                if (input.upgradeNumber == 2 || input.upgradeNumber == 5 || input.upgradeNumber == 8 || input.upgradeNumber == 11) upgradeSelect.transform.position = engine2check.transform.position;
                if (input.upgradeNumber == 3 || input.upgradeNumber == 6 || input.upgradeNumber == 9 || input.upgradeNumber == 12) upgradeSelect.transform.position = engine3check.transform.position;
                break;

            case Upgrade.Category.armour:
                if (input.upgradeNumber == 1 || input.upgradeNumber == 4 || input.upgradeNumber == 7 || input.upgradeNumber == 10) upgradeSelect.transform.position = armour1check.transform.position;
                if (input.upgradeNumber == 2 || input.upgradeNumber == 5 || input.upgradeNumber == 8 || input.upgradeNumber == 11) upgradeSelect.transform.position = armour2lock.transform.position;
                if (input.upgradeNumber == 3 || input.upgradeNumber == 6 || input.upgradeNumber == 9 || input.upgradeNumber == 12) upgradeSelect.transform.position = armour3lock.transform.position;
                break;

            case Upgrade.Category.boostSpeed:
                upgradeSelect.transform.position = boostSpeed1check.transform.position;
                break;

            case Upgrade.Category.boostCooldown:
                upgradeSelect.transform.position = boostCooldown1check.transform.position;
                break;

            case Upgrade.Category.boostRecharge:
                upgradeSelect.transform.position = boostRecharge1check.transform.position;
                break;
        }
    }

}

public class Upgrade
{
    public enum State
    {
        equipped,
        owned,
        available,
        locked,
    }

    public enum Category
    {
        engine,
        armour,
        boostSpeed,
        boostCooldown,
        boostRecharge,
        bulletAmmo,
        bulletClip,
        bulletCooldown,
        missleAmmo,
        missleClip,
        missleCooldown,
        mineAmmo,
        mineClip,
        mineCooldown,
        repair,
        speech,
        charm
    }

    public State state;
    public Category category;
    public int upgradeNumber;
    public string name;
    public string description;
    public int price;
}
