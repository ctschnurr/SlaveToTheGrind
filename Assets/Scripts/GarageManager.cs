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

    private static List<Upgrade> upgradeList;

    static Upgrade currentUpgrade;

    static GameObject upgradeSelect;

    static GameObject garageT1;
    static GameObject garageT2;
    static GameObject garageT3;
    static GameObject garageT4;

    // T1 Garage Elements:
    static GameObject engine1check;
    static GameObject engine1grey;

    static GameObject engine2lock;
    static GameObject engine2check;
    static GameObject engine2grey;

    static GameObject engine3lock;
    static GameObject engine3check;
    static GameObject engine3grey;

    static GameObject armour1check;
    static GameObject armour1grey;

    static GameObject armour2lock;
    static GameObject armour2check;
    static GameObject armour2grey;

    static GameObject armour3lock;
    static GameObject armour3check;
    static GameObject armour3grey;

    static GameObject boostSpeed1check;
    static GameObject boostSpeed1grey;

    static GameObject boostCooldown1check;
    static GameObject boostCooldown1grey;

    static GameObject boostRecharge1check;
    static GameObject boostRecharge1grey;

    // T2 Garage Elements:
    static GameObject engine4check;
    static GameObject engine4grey;

    static GameObject engine5lock;
    static GameObject engine5check;
    static GameObject engine5grey;

    static GameObject engine6lock;
    static GameObject engine6check;
    static GameObject engine6grey;

    static GameObject armour4check;
    static GameObject armour4grey;

    static GameObject armour5lock;
    static GameObject armour5check;
    static GameObject armour5grey;

    static GameObject armour6lock;
    static GameObject armour6check;
    static GameObject armour6grey;

    static GameObject boostSpeed2check;
    static GameObject boostSpeed2grey;

    static GameObject boostCooldown2check;
    static GameObject boostCooldown2grey;

    static GameObject boostRecharge2check;
    static GameObject boostRecharge2grey;

    // T3 Garage Elements
    static GameObject engine7check;
    static GameObject engine7grey;

    static GameObject engine8lock;
    static GameObject engine8check;
    static GameObject engine8grey;

    static GameObject engine9lock;
    static GameObject engine9check;
    static GameObject engine9grey;

    static GameObject armour7check;
    static GameObject armour7grey;

    static GameObject armour8lock;
    static GameObject armour8check;
    static GameObject armour8grey;

    static GameObject armour9lock;
    static GameObject armour9check;
    static GameObject armour9grey;

    static GameObject boostSpeed3check;
    static GameObject boostSpeed3grey;

    static GameObject boostCooldown3check;
    static GameObject boostCooldown3grey;

    static GameObject boostRecharge3check;
    static GameObject boostRecharge3grey;

    // T4 Garage Elements
    static GameObject engine10check;
    static GameObject engine10grey;

    static GameObject engine11lock;
    static GameObject engine11check;
    static GameObject engine11grey;

    static GameObject engine12lock;
    static GameObject engine12check;
    static GameObject engine12grey;

    static GameObject armour10check;
    static GameObject armour10grey;

    static GameObject armour11lock;
    static GameObject armour11check;
    static GameObject armour11grey;

    static GameObject armour12lock;
    static GameObject armour12check;
    static GameObject armour12grey;

    static GameObject boostSpeed4check;
    static GameObject boostSpeed4grey;

    static GameObject boostCooldown4check;
    static GameObject boostCooldown4grey;

    static GameObject boostRecharge4check;
    static GameObject boostRecharge4grey;

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
        engine1grey = GameObject.Find("ScreenManager/Garage/T1/EngineUpgrades/Upgrade1/Grey");

        engine2lock = GameObject.Find("ScreenManager/Garage/T1/EngineUpgrades/Upgrade2/Lock");
        engine2check = GameObject.Find("ScreenManager/Garage/T1/EngineUpgrades/Upgrade2/Check");
        engine2grey = GameObject.Find("ScreenManager/Garage/T1/EngineUpgrades/Upgrade2/Grey");

        engine3lock = GameObject.Find("ScreenManager/Garage/T1/EngineUpgrades/Upgrade3/Lock");
        engine3check = GameObject.Find("ScreenManager/Garage/T1/EngineUpgrades/Upgrade3/Check");
        engine3grey = GameObject.Find("ScreenManager/Garage/T1/EngineUpgrades/Upgrade3/Grey");

        armour1check = GameObject.Find("ScreenManager/Garage/T1/ArmourUpgrades/Upgrade1/Check");
        armour1grey = GameObject.Find("ScreenManager/Garage/T1/ArmourUpgrades/Upgrade1/Grey");

        armour2lock = GameObject.Find("ScreenManager/Garage/T1/ArmourUpgrades/Upgrade2/Lock");
        armour2check = GameObject.Find("ScreenManager/Garage/T1/ArmourUpgrades/Upgrade2/Check");
        armour2grey = GameObject.Find("ScreenManager/Garage/T1/ArmourUpgrades/Upgrade2/Grey");

        armour3lock = GameObject.Find("ScreenManager/Garage/T1/ArmourUpgrades/Upgrade3/Lock");
        armour3check = GameObject.Find("ScreenManager/Garage/T1/ArmourUpgrades/Upgrade3/Check");
        armour3grey = GameObject.Find("ScreenManager/Garage/T1/ArmourUpgrades/Upgrade3/Grey");

        boostSpeed1check = GameObject.Find("ScreenManager/Garage/T1/BoostUpgrades/Upgrade1/Check");
        boostSpeed1grey = GameObject.Find("ScreenManager/Garage/T1/BoostUpgrades/Upgrade1/Grey");
        boostCooldown1check = GameObject.Find("ScreenManager/Garage/T1/BoostUpgrades/Upgrade2/Check");
        boostCooldown1grey = GameObject.Find("ScreenManager/Garage/T1/BoostUpgrades/Upgrade2/Grey");
        boostRecharge1check = GameObject.Find("ScreenManager/Garage/T1/BoostUpgrades/Upgrade3/Check");
        boostRecharge1grey = GameObject.Find("ScreenManager/Garage/T1/BoostUpgrades/Upgrade3/Grey");

        // Garage T2 Elements
        engine4check = GameObject.Find("ScreenManager/Garage/T2/EngineUpgrades/Upgrade1/Check");
        engine4grey = GameObject.Find("ScreenManager/Garage/T1/BoostUpgrades/Upgrade1/Grey");

        engine5lock = GameObject.Find("ScreenManager/Garage/T2/EngineUpgrades/Upgrade2/Lock");
        engine5check = GameObject.Find("ScreenManager/Garage/T2/EngineUpgrades/Upgrade2/Check");
        engine5grey = GameObject.Find("ScreenManager/Garage/T2/EngineUpgrades/Upgrade2/Grey");

        engine6lock = GameObject.Find("ScreenManager/Garage/T2/EngineUpgrades/Upgrade3/Lock");
        engine6check = GameObject.Find("ScreenManager/Garage/T2/EngineUpgrades/Upgrade3/Check");
        engine6grey = GameObject.Find("ScreenManager/Garage/T2/EngineUpgrades/Upgrade3/Grey");

        armour4check = GameObject.Find("ScreenManager/Garage/T2/ArmourUpgrades/Upgrade1/Check");
        armour4grey = GameObject.Find("ScreenManager/Garage/T2/ArmourUpgrades/Upgrade1/Grey");

        armour5lock = GameObject.Find("ScreenManager/Garage/T2/ArmourUpgrades/Upgrade2/Lock");
        armour5check = GameObject.Find("ScreenManager/Garage/T2/ArmourUpgrades/Upgrade2/Check");
        armour5grey = GameObject.Find("ScreenManager/Garage/T2/ArmourUpgrades/Upgrade2/Grey");

        armour6lock = GameObject.Find("ScreenManager/Garage/T2/ArmourUpgrades/Upgrade3/Lock");
        armour6check = GameObject.Find("ScreenManager/Garage/T2/ArmourUpgrades/Upgrade3/Check");
        armour6grey = GameObject.Find("ScreenManager/Garage/T2/ArmourUpgrades/Upgrade3/Grey");

        boostSpeed2check = GameObject.Find("ScreenManager/Garage/T2/BoostUpgrades/Upgrade1/Check");
        boostSpeed2grey = GameObject.Find("ScreenManager/Garage/T2/BoostUpgrades/Upgrade1/Grey");

        boostCooldown2check = GameObject.Find("ScreenManager/Garage/T2/BoostUpgrades/Upgrade2/Check");
        boostCooldown2grey = GameObject.Find("ScreenManager/Garage/T2/BoostUpgrades/Upgrade2/Grey");

        boostRecharge2check = GameObject.Find("ScreenManager/Garage/T2/BoostUpgrades/Upgrade3/Check");
        boostRecharge2grey = GameObject.Find("ScreenManager/Garage/T2/BoostUpgrades/Upgrade3/Grey");

        // Garage T3 Elements
        engine7check = GameObject.Find("ScreenManager/Garage/T3/EngineUpgrades/Upgrade1/Check");
        engine7grey = GameObject.Find("ScreenManager/Garage/T3/EngineUpgrades/Upgrade1/Grey");

        engine8lock = GameObject.Find("ScreenManager/Garage/T3/EngineUpgrades/Upgrade2/Lock");
        engine8check = GameObject.Find("ScreenManager/Garage/T3/EngineUpgrades/Upgrade2/Check");
        engine8grey = GameObject.Find("ScreenManager/Garage/T3/EngineUpgrades/Upgrade2/Grey");

        engine9lock = GameObject.Find("ScreenManager/Garage/T3/EngineUpgrades/Upgrade3/Lock");
        engine9check = GameObject.Find("ScreenManager/Garage/T3/EngineUpgrades/Upgrade3/Check");
        engine9grey = GameObject.Find("ScreenManager/Garage/T3/EngineUpgrades/Upgrade3/Grey");

        armour7check = GameObject.Find("ScreenManager/Garage/T3/ArmourUpgrades/Upgrade1/Check");
        armour7grey = GameObject.Find("ScreenManager/Garage/T3/ArmourUpgrades/Upgrade1/Grey");

        armour8lock = GameObject.Find("ScreenManager/Garage/T3/ArmourUpgrades/Upgrade2/Lock");
        armour8check = GameObject.Find("ScreenManager/Garage/T3/ArmourUpgrades/Upgrade2/Check");
        armour8grey = GameObject.Find("ScreenManager/Garage/T3/ArmourUpgrades/Upgrade2/Grey");

        armour9lock = GameObject.Find("ScreenManager/Garage/T3/ArmourUpgrades/Upgrade3/Lock");
        armour9check = GameObject.Find("ScreenManager/Garage/T3/ArmourUpgrades/Upgrade3/Check");
        armour9grey = GameObject.Find("ScreenManager/Garage/T3/ArmourUpgrades/Upgrade3/Grey");

        boostSpeed3check = GameObject.Find("ScreenManager/Garage/T3/BoostUpgrades/Upgrade1/Check");
        boostSpeed3grey = GameObject.Find("ScreenManager/Garage/T3/BoostUpgrades/Upgrade1/Grey");

        boostCooldown3check = GameObject.Find("ScreenManager/Garage/T3/BoostUpgrades/Upgrade2/Check");
        boostCooldown3grey = GameObject.Find("ScreenManager/Garage/T3/BoostUpgrades/Upgrade2/Grey");

        boostRecharge3check = GameObject.Find("ScreenManager/Garage/T3/BoostUpgrades/Upgrade3/Check");
        boostRecharge3grey = GameObject.Find("ScreenManager/Garage/T3/BoostUpgrades/Upgrade3/Grey");

        // Garage T4 Elements
        engine10check = GameObject.Find("ScreenManager/Garage/T4/EngineUpgrades/Upgrade1/Check");
        engine10grey = GameObject.Find("ScreenManager/Garage/T4/EngineUpgrades/Upgrade1/Grey");

        engine11lock = GameObject.Find("ScreenManager/Garage/T4/EngineUpgrades/Upgrade2/Lock");
        engine11check = GameObject.Find("ScreenManager/Garage/T4/EngineUpgrades/Upgrade2/Check");
        engine11grey = GameObject.Find("ScreenManager/Garage/T4/EngineUpgrades/Upgrade2/Grey");

        engine12lock = GameObject.Find("ScreenManager/Garage/T4/EngineUpgrades/Upgrade3/Lock");
        engine12check = GameObject.Find("ScreenManager/Garage/T4/EngineUpgrades/Upgrade3/Check");
        engine12grey = GameObject.Find("ScreenManager/Garage/T4/EngineUpgrades/Upgrade3/Grey");

        armour10check = GameObject.Find("ScreenManager/Garage/T4/ArmourUpgrades/Upgrade1/Check");
        armour10grey = GameObject.Find("ScreenManager/Garage/T4/ArmourUpgrades/Upgrade1/Grey");

        armour11lock = GameObject.Find("ScreenManager/Garage/T4/ArmourUpgrades/Upgrade2/Lock");
        armour11check = GameObject.Find("ScreenManager/Garage/T4/ArmourUpgrades/Upgrade2/Check");
        armour11grey = GameObject.Find("ScreenManager/Garage/T4/ArmourUpgrades/Upgrade2/Grey");

        armour12lock = GameObject.Find("ScreenManager/Garage/T4/ArmourUpgrades/Upgrade3/Lock");
        armour12check = GameObject.Find("ScreenManager/Garage/T4/ArmourUpgrades/Upgrade3/Check");
        armour12grey = GameObject.Find("ScreenManager/Garage/T4/ArmourUpgrades/Upgrade3/Grey");

        boostSpeed4check = GameObject.Find("ScreenManager/Garage/T4/BoostUpgrades/Upgrade1/Check");
        boostSpeed4grey = GameObject.Find("ScreenManager/Garage/T4/BoostUpgrades/Upgrade1/Grey");

        boostCooldown4check = GameObject.Find("ScreenManager/Garage/T4/BoostUpgrades/Upgrade2/Check");
        boostCooldown4grey = GameObject.Find("ScreenManager/Garage/T4/BoostUpgrades/Upgrade2/Grey");

        boostRecharge4check = GameObject.Find("ScreenManager/Garage/T4/BoostUpgrades/Upgrade3/Check");
        boostRecharge4grey = GameObject.Find("ScreenManager/Garage/T4/BoostUpgrades/Upgrade3/Grey");

        garageIconList = new List<GameObject>
        {
            engine1check, engine1grey, engine2lock, engine2check, engine2grey, engine3lock, engine3check, engine3grey, 
            armour1check, armour1grey, armour2lock, armour2check, armour2grey, armour3lock, armour3check, armour3grey, 
            boostSpeed1check, boostSpeed1grey, boostCooldown1check, boostCooldown1grey, boostRecharge1check, boostRecharge1grey,
            engine4check, engine4grey, engine5lock, engine5check, engine5grey, engine6lock, engine6check, engine6grey,
            armour4check, armour4grey, armour5lock, armour5check, armour5grey, armour6lock, armour6check, armour6grey,
            boostSpeed2check, boostSpeed2grey, boostCooldown2check, boostCooldown2grey, boostRecharge2check, boostRecharge2grey,
            engine7check, engine7grey, engine8lock, engine8check, engine8grey, engine9lock, engine9check, engine9grey, 
            armour7check, armour7grey, armour8lock, armour8check, armour8grey, armour9lock, armour9check, armour9grey,
            boostSpeed3check, boostSpeed3grey, boostCooldown3check, boostCooldown3grey, boostRecharge3check, boostRecharge3grey,
            engine10check, engine10grey, engine11lock, engine11check, engine11grey, engine12lock, engine12check, engine12grey,
            armour10check, armour10grey, armour11lock, armour11check, armour11grey, armour12lock, armour12check, armour12grey,
            boostSpeed4check, boostSpeed4grey, boostCooldown4check, boostCooldown4grey, boostRecharge4check, boostRecharge4grey
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
            price = 100,
            greyObj = engine1grey,
            checkObj = engine1check,
            lockObj = null
        };

        engine2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.engine,
            state = Upgrade.State.locked,
            name = "New Engine",
            description = "Better than old junk. Increases speed again.",
            price = 200,
            greyObj = engine2grey,
            checkObj = engine2check,
            lockObj = engine2lock
        };

        engine3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.engine,
            state = Upgrade.State.locked,
            name = "Modify Engine",
            description = "Performance tweaks. Further increases speed.",
            price = 300,
            greyObj = engine3grey,
            checkObj = engine3check,
            lockObj = engine3lock
        };

        engine4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.engine,
            state = Upgrade.State.available,
            name = "Engine Level IV",
            description = "Speed +4",
            price = 200,
            greyObj = engine4grey,
            checkObj = engine4check,
            lockObj = null
        };

        engine5 = new Upgrade
        {
            upgradeNumber = 5,
            category = Upgrade.Category.engine,
            state = Upgrade.State.locked,
            name = "Engine Level V",
            description = "Speed +5",
            price = 300,
            greyObj = engine5grey,
            checkObj = engine5check,
            lockObj = engine5lock
        };

        engine6 = new Upgrade
        {
            upgradeNumber = 6,
            category = Upgrade.Category.engine,
            state = Upgrade.State.locked,
            name = "Engine Level VI",
            description = "Speed +6",
            price = 400,
            greyObj = engine6grey,
            checkObj = engine6check,
            lockObj = engine6lock
        };

        engine7 = new Upgrade
        {
            upgradeNumber = 7,
            category = Upgrade.Category.engine,
            state = Upgrade.State.available,
            name = "Engine Level VII",
            description = "Speed +7",
            price = 300,
            greyObj = engine7grey,
            checkObj = engine7check,
            lockObj = null
        };

        engine8 = new Upgrade
        {
            upgradeNumber = 8,
            category = Upgrade.Category.engine,
            state = Upgrade.State.locked,
            name = "Engine Level VIII",
            description = "Speed +8",
            price = 400,
            greyObj = engine8grey,
            checkObj = engine8check,
            lockObj = engine8lock
        };

        engine9 = new Upgrade
        {
            upgradeNumber = 9,
            category = Upgrade.Category.engine,
            state = Upgrade.State.locked,
            name = "Engine Level IX",
            description = "Speed +9",
            price = 500,
            greyObj = engine9grey,
            checkObj = engine9check,
            lockObj = engine9lock
        };

        engine10 = new Upgrade
        {
            upgradeNumber = 10,
            category = Upgrade.Category.engine,
            state = Upgrade.State.available,
            name = "Engine Level X",
            description = "Speed +10",
            price = 400,
            greyObj = engine10grey,
            checkObj = engine11check,
            lockObj = null
        };

        engine11 = new Upgrade
        {
            upgradeNumber = 11,
            category = Upgrade.Category.engine,
            state = Upgrade.State.locked,
            name = "Engine Level XI",
            description = "Speed +11",
            price = 500,
            greyObj = engine11grey,
            checkObj = engine11check,
            lockObj = engine11lock
        };

        engine12 = new Upgrade
        {
            upgradeNumber = 12,
            category = Upgrade.Category.engine,
            state = Upgrade.State.locked,
            name = "Engine Level XII",
            description = "Speed +12",
            price = 600,
            greyObj = engine12grey,
            checkObj = engine12check,
            lockObj = engine12lock
        };

        armour1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.armour,
            state = Upgrade.State.available,
            name = "Fix Holes",
            description = "Patch up your car's body. Decreases damage.",
            price = 100,
            greyObj = armour1grey,
            checkObj = armour1check,
            lockObj = null
        };

        armour2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.armour,
            state = Upgrade.State.locked,
            name = "Added Plating",
            description = "Extra protection. Decreases damage more.",
            price = 200,
            greyObj = armour2grey,
            checkObj = armour2check,
            lockObj = armour2lock
        };

        armour3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.armour,
            state = Upgrade.State.locked,
            name = "Vehicle Armour",
            description = "Reinforced for extra strength. Decreases damage further.",
            price = 400,
            greyObj = armour3grey,
            checkObj = armour3check,
            lockObj = armour3lock
        };

        armour4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.armour,
            state = Upgrade.State.available,
            name = "Armour Level IV",
            description = "Damage -4",
            price = 200,
            greyObj = armour4grey,
            checkObj = armour4check,
            lockObj = null
        };

        armour5 = new Upgrade
        {
            upgradeNumber = 5,
            category = Upgrade.Category.armour,
            state = Upgrade.State.locked,
            name = "Armour Level V",
            description = "Damage -5",
            price = 300,
            greyObj = armour5grey,
            checkObj = armour5check,
            lockObj = armour5lock
        };

        armour6 = new Upgrade
        {
            upgradeNumber = 6,
            category = Upgrade.Category.armour,
            state = Upgrade.State.locked,
            name = "Armour Level VI",
            description = "Damage -6",
            price = 400,
            greyObj = armour6grey,
            checkObj = armour6check,
            lockObj = armour6lock
        };

        armour7 = new Upgrade
        {
            upgradeNumber = 7,
            category = Upgrade.Category.armour,
            state = Upgrade.State.available,
            name = "Armour Level VII",
            description = "Damage -7",
            price = 300,
            greyObj = armour7grey,
            checkObj = armour7check,
            lockObj = null
        };

        armour8 = new Upgrade
        {
            upgradeNumber = 8,
            category = Upgrade.Category.armour,
            state = Upgrade.State.locked,
            name = "Armour Level VIII",
            description = "Damage -8",
            price = 400,
            greyObj = armour8grey,
            checkObj = armour8check,
            lockObj = armour8lock
        };

        armour9 = new Upgrade
        {
            upgradeNumber = 9,
            category = Upgrade.Category.armour,
            state = Upgrade.State.locked,
            name = "Armour Level IX",
            description = "Damage -9",
            price = 500,
            greyObj = armour9grey,
            checkObj = armour9check,
            lockObj = armour9lock
        };

        armour10 = new Upgrade
        {
            upgradeNumber = 10,
            category = Upgrade.Category.armour,
            state = Upgrade.State.available,
            name = "Armour Level X",
            description = "Damage -10",
            price = 400,
            greyObj = armour10grey,
            checkObj = armour10check,
            lockObj = null
        };

        armour11 = new Upgrade
        {
            upgradeNumber = 11,
            category = Upgrade.Category.armour,
            state = Upgrade.State.locked,
            name = "Armour Level XI",
            description = "Damage -11",
            price = 500,
            greyObj = armour11grey,
            checkObj = armour11check,
            lockObj = armour11lock
        };

        armour12 = new Upgrade
        {
            upgradeNumber = 12,
            category = Upgrade.Category.armour,
            state = Upgrade.State.locked,
            name = "Armour Level XII",
            description = "Damage -12",
            price = 600,
            greyObj = armour12grey,
            checkObj = armour12check,
            lockObj = armour12lock
        };

        boostSpeed1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.boostSpeed,
            state = Upgrade.State.available,
            name = "Filtered Fuel",
            description = "Slightly cleaner burning. Increases boost speed.",
            price = 200,
            greyObj = boostSpeed1grey,
            checkObj = boostSpeed1check,
            lockObj = null
        };

        boostSpeed2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.boostSpeed,
            state = Upgrade.State.available,
            name = "Boost Speed II",
            description = "Boost Speed +2",
            price = 300,
            greyObj = boostSpeed2grey,
            checkObj = boostSpeed2check,
            lockObj = null
        };

        boostSpeed3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.boostSpeed,
            state = Upgrade.State.available,
            name = "Boost Speed III",
            description = "Boost Speed +3",
            price = 400,
            greyObj = boostSpeed3grey,
            checkObj = boostSpeed3check,
            lockObj = null
        };

        boostSpeed4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.boostSpeed,
            state = Upgrade.State.available,
            name = "Boost Speed IV",
            description = "Boost Speed +4",
            price = 500,
            greyObj = boostSpeed4grey,
            checkObj = boostSpeed4check,
            lockObj = null
        };

        boostCooldown1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.boostCooldown,
            state = Upgrade.State.available,
            name = "Calibrate Booster",
            description = "A little fine-tuning. Decreases boost cooldown.",
            price = 250,
            greyObj = boostCooldown1grey,
            checkObj = boostCooldown1check,
            lockObj = null
        };

        boostCooldown2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.boostCooldown,
            state = Upgrade.State.available,
            name = "Boost Cooldown II",
            description = "Boost Cooldown -2",
            price = 300,
            greyObj = boostCooldown2grey,
            checkObj = boostCooldown2check,
            lockObj = null
        };

        boostCooldown3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.boostCooldown,
            state = Upgrade.State.available,
            name = "Boost Cooldown III",
            description = "Boost Cooldown -3",
            price = 400,
            greyObj = boostCooldown3grey,
            checkObj = boostCooldown3check,
            lockObj = null
        };

        boostCooldown4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.boostCooldown,
            state = Upgrade.State.available,
            name = "Boost Cooldown IV",
            description = "Boost Cooldown -4",
            price = 500,
            greyObj = boostCooldown4grey,
            checkObj = boostCooldown4check,
            lockObj = null
        };

        boostRecharge1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.boostRecharge,
            state = Upgrade.State.available,
            name = "Second-Hand Parts",
            description = "Better than yours. Increases boost recharge speed.",
            price = 250,
            greyObj = boostRecharge1grey,
            checkObj = boostRecharge1check,
            lockObj = null
        };

        boostRecharge2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.boostRecharge,
            state = Upgrade.State.available,
            name = "Boost Recharge II",
            description = "Boost Recharge +2",
            price = 300,
            greyObj = boostRecharge2grey,
            checkObj = boostRecharge2check,
            lockObj = null
        };

        boostRecharge3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.boostRecharge,
            state = Upgrade.State.available,
            name = "Boost Recharge III",
            description = "Boost Recharge +3",
            price = 400,
            greyObj = boostRecharge3grey,
            checkObj = boostRecharge3check,
            lockObj = null
        };

        boostRecharge4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.boostRecharge,
            state = Upgrade.State.available,
            name = "Boost Recharge IV",
            description = "Boost Recharge +4",
            price = 500,
            greyObj = boostRecharge4grey,
            checkObj = boostRecharge4check,
            lockObj = null
        };

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

        foreach(Upgrade upgrade in upgradeList)
        {
            switch(upgrade.state)
            {
                case Upgrade.State.available:
                    if(playerController.TotalMoney < upgrade.price) upgrade.greyObj.SetActive(true);
                    upgrade.checkObj.SetActive(false);
                    if(upgrade.lockObj != null) upgrade.lockObj.SetActive(false);
                    break;

                case Upgrade.State.locked:
                    upgrade.greyObj.SetActive(false);
                    upgrade.checkObj.SetActive(false);
                    if (upgrade.lockObj != null) upgrade.lockObj.SetActive(true);
                    break;

                case Upgrade.State.owned:
                    upgrade.greyObj.SetActive(false);
                    upgrade.checkObj.SetActive(true);
                    if (upgrade.lockObj != null) upgrade.lockObj.SetActive(false);
                    break;
            }
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

        foreach (Upgrade nextUpgrade in upgradeList)
        {
            if (nextUpgrade.category == currentUpgrade.category && nextUpgrade.upgradeNumber == currentUpgrade.upgradeNumber + 1 && nextUpgrade.state == Upgrade.State.locked) nextUpgrade.state = Upgrade.State.available;
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

    public GameObject greyObj;
    public GameObject checkObj;
    public GameObject lockObj;
}
