using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class SchoolManager : MonoBehaviour
{
    public enum UpgradeCategory
    {
        repair,
        speech,
        charm
    }

    public UpgradeCategory currentCategory = UpgradeCategory.repair;
    public int currentSelectedLevel = 0;
    // Start is called before the first frame update

    PlayerController player;

    static Upgrade repair1;
    static Upgrade repair2;
    static Upgrade repair3;
    static Upgrade repair4;
    static Upgrade repair5;
    static Upgrade repair6;
    static Upgrade repair7;
    static Upgrade repair8;
    static Upgrade repair9;
    static Upgrade repair10;
    static Upgrade repair11;
    static Upgrade repair12;

    static Upgrade speech1;
    static Upgrade speech2;
    static Upgrade speech3;
    static Upgrade speech4;
    static Upgrade speech5;
    static Upgrade speech6;
    static Upgrade speech7;
    static Upgrade speech8;
    static Upgrade speech9;
    static Upgrade speech10;
    static Upgrade speech11;
    static Upgrade speech12;

    static Upgrade charm1;
    static Upgrade charm2;
    static Upgrade charm3;
    static Upgrade charm4;
    static Upgrade charm5;
    static Upgrade charm6;
    static Upgrade charm7;
    static Upgrade charm8;
    static Upgrade charm9;
    static Upgrade charm10;
    static Upgrade charm11;
    static Upgrade charm12;


    private List<Upgrade> upgradeList;

    static Upgrade currentUpgrade;

    static GameObject upgradeSelect;

    static GameObject schoolT1;
    static GameObject schoolT2;
    static GameObject schoolT3;
    static GameObject schoolT4;

    // T1 School Elements:
    static GameObject repair1check;

    static GameObject repair2lock;
    static GameObject repair2check;

    static GameObject repair3lock;
    static GameObject repair3check;

    static GameObject speech1check;

    static GameObject speech2lock;
    static GameObject speech2check;

    static GameObject speech3lock;
    static GameObject speech3check;

    static GameObject charm1check;

    static GameObject charm2lock;
    static GameObject charm2check;

    static GameObject charm3lock;
    static GameObject charm3check;

    // T2 School Elements:
    static GameObject repair4check;

    static GameObject repair5lock;
    static GameObject repair5check;

    static GameObject repair6lock;
    static GameObject repair6check;

    static GameObject speech4check;

    static GameObject speech5lock;
    static GameObject speech5check;

    static GameObject speech6lock;
    static GameObject speech6check;

    static GameObject charm4check;
                    
    static GameObject charm5lock;
    static GameObject charm5check;
                 
    static GameObject charm6lock;
    static GameObject charm6check;

    // T3 School Elements
    static GameObject repair7check;

    static GameObject repair8lock;
    static GameObject repair8check;

    static GameObject repair9lock;
    static GameObject repair9check;

    static GameObject speech7check;

    static GameObject speech8lock;
    static GameObject speech8check;

    static GameObject speech9lock;
    static GameObject speech9check;

    static GameObject charm7check;

    static GameObject charm8lock;
    static GameObject charm8check;

    static GameObject charm9lock;
    static GameObject charm9check;

    // T4 School Elements
    static GameObject repair10check;

    static GameObject repair11lock;
    static GameObject repair11check;

    static GameObject repair12lock;
    static GameObject repair12check;

    static GameObject speech10check;

    static GameObject speech11lock;
    static GameObject speech11check;

    static GameObject speech12lock;
    static GameObject speech12check;

    static GameObject charm10check;

    static GameObject charm11lock;
    static GameObject charm11check;

    static GameObject charm12lock;
    static GameObject charm12check;
    //
    static List<GameObject> schoolIconList;

    static PlayerController playerController;

    void StartElements()
    {
        schoolT1 = GameObject.Find("School/T1");
        schoolT2 = GameObject.Find("School/T2");
        schoolT3 = GameObject.Find("School/T3");
        schoolT4 = GameObject.Find("School/T4");

        upgradeSelect = GameObject.Find("ScreenManager/School/Select");

        // School T1 Elements
        repair1check = GameObject.Find("ScreenManager/School/T1/RepairUpgrades/Upgrade1/Check");

        repair2lock = GameObject.Find("ScreenManager/School/T1/RepairUpgrades/Upgrade2/Lock");
        repair2check = GameObject.Find("ScreenManager/School/T1/RepairUpgrades/Upgrade2/Check");

        repair3lock = GameObject.Find("ScreenManager/School/T1/RepairUpgrades/Upgrade3/Lock");
        repair3check = GameObject.Find("ScreenManager/School/T1/RepairUpgrades/Upgrade3/Check");

        speech1check = GameObject.Find("ScreenManager/School/T1/SpeechUpgrades/Upgrade1/Check");

        speech2lock = GameObject.Find("ScreenManager/School/T1/SpeechUpgrades/Upgrade2/Lock");
        speech2check = GameObject.Find("ScreenManager/School/T1/SpeechUpgrades/Upgrade2/Check");

        speech3lock = GameObject.Find("ScreenManager/School/T1/SpeechUpgrades/Upgrade3/Lock");
        speech3check = GameObject.Find("ScreenManager/School/T1/SpeechUpgrades/Upgrade3/Check");

        charm1check = GameObject.Find("ScreenManager/School/T1/CharmUpgrades/Upgrade1/Check");
  
        charm2lock = GameObject.Find("ScreenManager/School/T1/CharmUpgrades/Upgrade2/Lock");
        charm2check = GameObject.Find("ScreenManager/School/T1/CharmUpgrades/Upgrade2/Check");
        
        charm3lock = GameObject.Find("ScreenManager/School/T1/CharmUpgrades/Upgrade3/Lock");
        charm3check = GameObject.Find("ScreenManager/School/T1/CharmUpgrades/Upgrade3/Check");

        // School T2 Elements
        repair4check = GameObject.Find("ScreenManager/School/T2/RepairUpgrades/Upgrade1/Check");

        repair5lock = GameObject.Find("ScreenManager/School/T2/RepairUpgrades/Upgrade2/Lock");
        repair5check = GameObject.Find("ScreenManager/School/T2/RepairUpgrades/Upgrade2/Check");

        repair6lock = GameObject.Find("ScreenManager/School/T2/RepairUpgrades/Upgrade3/Lock");
        repair6check = GameObject.Find("ScreenManager/School/T2/RepairUpgrades/Upgrade3/Check");

        speech4check = GameObject.Find("ScreenManager/School/T2/SpeechUpgrades/Upgrade1/Check");

        speech5lock = GameObject.Find("ScreenManager/School/T2/SpeechUpgrades/Upgrade2/Lock");
        speech5check = GameObject.Find("ScreenManager/School/T2/SpeechUpgrades/Upgrade2/Check");

        speech6lock = GameObject.Find("ScreenManager/School/T2/SpeechUpgrades/Upgrade3/Lock");
        speech6check = GameObject.Find("ScreenManager/School/T2/SpeechUpgrades/Upgrade3/Check");

        charm4check = GameObject.Find("ScreenManager/School/T2/CharmUpgrades/Upgrade1/Check");

        charm5lock = GameObject.Find("ScreenManager/School/T2/CharmUpgrades/Upgrade2/Lock");
        charm5check = GameObject.Find("ScreenManager/School/T2/CharmUpgrades/Upgrade2/Check");

        charm6lock = GameObject.Find("ScreenManager/School/T2/CharmUpgrades/Upgrade3/Lock");
        charm6check = GameObject.Find("ScreenManager/School/T2/CharmUpgrades/Upgrade3/Check");

        // School T3 Elements
        repair7check = GameObject.Find("ScreenManager/School/T3/RepairUpgrades/Upgrade1/Check");

        repair8lock = GameObject.Find("ScreenManager/School/T3/RepairUpgrades/Upgrade2/Lock");
        repair8check = GameObject.Find("ScreenManager/School/T3/RepairUpgrades/Upgrade2/Check");

        repair9lock = GameObject.Find("ScreenManager/School/T3/RepairUpgrades/Upgrade3/Lock");
        repair9check = GameObject.Find("ScreenManager/School/T3/RepairUpgrades/Upgrade3/Check");

        speech7check = GameObject.Find("ScreenManager/School/T3/SpeechUpgrades/Upgrade1/Check");

        speech8lock = GameObject.Find("ScreenManager/School/T3/SpeechUpgrades/Upgrade2/Lock");
        speech8check = GameObject.Find("ScreenManager/School/T3/SpeechUpgrades/Upgrade2/Check");

        speech9lock = GameObject.Find("ScreenManager/School/T3/SpeechUpgrades/Upgrade3/Lock");
        speech9check = GameObject.Find("ScreenManager/School/T3/SpeechUpgrades/Upgrade3/Check");

        charm7check = GameObject.Find("ScreenManager/School/T3/CharmUpgrades/Upgrade1/Check");

        charm8lock = GameObject.Find("ScreenManager/School/T3/CharmUpgrades/Upgrade2/Lock");
        charm8check = GameObject.Find("ScreenManager/School/T3/CharmUpgrades/Upgrade2/Check");

        charm9lock = GameObject.Find("ScreenManager/School/T3/CharmUpgrades/Upgrade3/Lock");
        charm9check = GameObject.Find("ScreenManager/School/T3/CharmUpgrades/Upgrade3/Check");

        // School T4 Elements
        repair10check = GameObject.Find("ScreenManager/School/T4/RepairUpgrades/Upgrade1/Check");

        repair11lock = GameObject.Find("ScreenManager/School/T4/RepairUpgrades/Upgrade2/Lock");
        repair11check = GameObject.Find("ScreenManager/School/T4/RepairUpgrades/Upgrade2/Check");

        repair12lock = GameObject.Find("ScreenManager/School/T4/RepairUpgrades/Upgrade3/Lock");
        repair12check = GameObject.Find("ScreenManager/School/T4/RepairUpgrades/Upgrade3/Check");

        speech10check = GameObject.Find("ScreenManager/School/T4/SpeechUpgrades/Upgrade1/Check");

        speech11lock = GameObject.Find("ScreenManager/School/T4/SpeechUpgrades/Upgrade2/Lock");
        speech11check = GameObject.Find("ScreenManager/School/T4/SpeechUpgrades/Upgrade2/Check");

        speech12lock = GameObject.Find("ScreenManager/School/T4/SpeechUpgrades/Upgrade3/Lock");
        speech12check = GameObject.Find("ScreenManager/School/T4/SpeechUpgrades/Upgrade3/Check");

        charm10check = GameObject.Find("ScreenManager/School/T4/CharmUpgrades/Upgrade1/Check");

        charm11lock = GameObject.Find("ScreenManager/School/T4/CharmUpgrades/Upgrade2/Lock");
        charm11check = GameObject.Find("ScreenManager/School/T4/CharmUpgrades/Upgrade2/Check");

        charm12lock = GameObject.Find("ScreenManager/School/T4/CharmUpgrades/Upgrade3/Lock");
        charm12check = GameObject.Find("ScreenManager/School/T4/CharmUpgrades/Upgrade3/Check");

        schoolIconList = new List<GameObject>
        {
            repair1check, repair2lock, repair2check, repair3lock, repair3check, speech1check, speech2lock, speech2check, speech3lock, speech3check, charm1check, charm2lock, charm2check, charm3lock, charm3check,
            repair4check, repair5lock, repair5check, repair6lock, repair6check, speech4check, speech5lock, speech5check, speech6lock, speech6check, charm4check, charm5lock, charm5check, charm6lock, charm6check,
            repair7check, repair8lock, repair8check, repair9lock, repair9check, speech7check, speech8lock, speech8check, speech9lock, speech9check, charm7check, charm8lock, charm8check, charm9lock, charm9check,
            repair10check, repair11lock, repair11check, repair12lock, repair12check, speech10check, speech11lock, speech11check, speech12lock, speech12check, charm10check, charm11lock, charm11check, charm12lock, charm12check
        };
    }
    public void SetupSchool()
    {
        StartElements();

        repair1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.repair,
            state = Upgrade.State.available,
            name = "Tune-Up",
            description = "Basic maintenance. Increases speed.",
            price = 100
        };

        repair2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.repair,
            state = Upgrade.State.locked,
            name = "New Repair",
            description = "Better than old junk. Increases speed again.",
            price = 200
        };

        repair3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.repair,
            state = Upgrade.State.locked,
            name = "Modify Repair",
            description = "Performance tweaks. Further increases speed.",
            price = 300
        };

        repair4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.repair,
            state = Upgrade.State.available,
            name = "Engine Level IV",
            description = "Speed +4",
            price = 200
        };

        repair5 = new Upgrade
        {
            upgradeNumber = 5,
            category = Upgrade.Category.repair,
            state = Upgrade.State.locked,
            name = "Engine Level V",
            description = "Speed +5",
            price = 300
        };

        repair6 = new Upgrade
        {
            upgradeNumber = 6,
            category = Upgrade.Category.repair,
            state = Upgrade.State.locked,
            name = "Engine Level VI",
            description = "Speed +6",
            price = 400
        };

        repair7 = new Upgrade
        {
            upgradeNumber = 7,
            category = Upgrade.Category.repair,
            state = Upgrade.State.available,
            name = "Engine Level VII",
            description = "Speed +7",
            price = 300
        };

        repair8 = new Upgrade
        {
            upgradeNumber = 8,
            category = Upgrade.Category.repair,
            state = Upgrade.State.locked,
            name = "Engine Level VIII",
            description = "Speed +8",
            price = 400
        };

        repair9 = new Upgrade
        {
            upgradeNumber = 9,
            category = Upgrade.Category.repair,
            state = Upgrade.State.locked,
            name = "Engine Level IX",
            description = "Speed +9",
            price = 500
        };

        repair10 = new Upgrade
        {
            upgradeNumber = 10,
            category = Upgrade.Category.repair,
            state = Upgrade.State.available,
            name = "Engine Level X",
            description = "Speed +10",
            price = 400
        };

        repair11 = new Upgrade
        {
            upgradeNumber = 11,
            category = Upgrade.Category.repair,
            state = Upgrade.State.locked,
            name = "Engine Level XI",
            description = "Speed +11",
            price = 500
        };

        repair12 = new Upgrade
        {
            upgradeNumber = 12,
            category = Upgrade.Category.repair,
            state = Upgrade.State.locked,
            name = "Engine Level XII",
            description = "Speed +12",
            price = 600
        };

        speech1 = new Upgrade();
        speech1.upgradeNumber = 1;
        speech1.category = Upgrade.Category.speech;
        speech1.state = Upgrade.State.available;
        speech1.name = "Fix Holes";
        speech1.description = "Patch up your car's body. Decreases damage.";
        speech1.price = 100;

        speech2 = new Upgrade();
        speech2.upgradeNumber = 2;
        speech2.category = Upgrade.Category.speech;
        speech2.state = Upgrade.State.locked;
        speech2.name = "Added Plating";
        speech2.description = "Extra protection. Decreases damage more.";
        speech2.price = 200;

        speech3 = new Upgrade();
        speech3.upgradeNumber = 3;
        speech3.category = Upgrade.Category.speech;
        speech3.state = Upgrade.State.locked;
        speech3.name = "Vehicle Armour";
        speech3.description = "Reinforced for extra strength. Decreases damage further.";
        speech3.price = 400;

        speech4 = new Upgrade();
        speech4.upgradeNumber = 4;
        speech4.category = Upgrade.Category.speech;
        speech4.state = Upgrade.State.available;
        speech4.name = "Armour Level IV";
        speech4.description = "Damage -4";
        speech4.price = 200;

        speech5 = new Upgrade();
        speech5.upgradeNumber = 5;
        speech5.category = Upgrade.Category.speech;
        speech5.state = Upgrade.State.locked;
        speech5.name = "Armour Level V";
        speech5.description = "Damage -5";
        speech5.price = 300;

        speech6 = new Upgrade();
        speech6.upgradeNumber = 6;
        speech6.category = Upgrade.Category.speech;
        speech6.state = Upgrade.State.locked;
        speech6.name = "Armour Level VI";
        speech6.description = "Damage -6";
        speech6.price = 400;

        speech7 = new Upgrade();
        speech7.upgradeNumber = 7;
        speech7.category = Upgrade.Category.speech;
        speech7.state = Upgrade.State.available;
        speech7.name = "Armour Level VII";
        speech7.description = "Damage -7";
        speech7.price = 300;

        speech8 = new Upgrade();
        speech8.upgradeNumber = 8;
        speech8.category = Upgrade.Category.speech;
        speech8.state = Upgrade.State.locked;
        speech8.name = "Armour Level VIII";
        speech8.description = "Damage -8";
        speech8.price = 400;

        speech9 = new Upgrade();
        speech9.upgradeNumber = 9;
        speech9.category = Upgrade.Category.speech;
        speech9.state = Upgrade.State.locked;
        speech9.name = "Armour Level IX";
        speech9.description = "Damage -9";
        speech9.price = 500;

        speech10 = new Upgrade();
        speech10.upgradeNumber = 10;
        speech10.category = Upgrade.Category.speech;
        speech10.state = Upgrade.State.available;
        speech10.name = "Armour Level X";
        speech10.description = "Damage -10";
        speech10.price = 400;

        speech11 = new Upgrade();
        speech11.upgradeNumber = 11;
        speech11.category = Upgrade.Category.speech;
        speech11.state = Upgrade.State.locked;
        speech11.name = "Armour Level XI";
        speech11.description = "Damage -11";
        speech11.price = 500;

        speech12 = new Upgrade();
        speech12.upgradeNumber = 12;
        speech12.category = Upgrade.Category.speech;
        speech12.state = Upgrade.State.locked;
        speech12.name = "Armour Level XII";
        speech12.description = "Damage -12";
        speech12.price = 600;

        charm1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.charm,
            state = Upgrade.State.available,
            name = "Tune-Up",
            description = "Basic maintenance. Increases speed.",
            price = 100
        };

        charm2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.charm,
            state = Upgrade.State.locked,
            name = "New Repair",
            description = "Better than old junk. Increases speed again.",
            price = 200
        };

        charm3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.charm,
            state = Upgrade.State.locked,
            name = "Modify Repair",
            description = "Performance tweaks. Further increases speed.",
            price = 300
        };

        charm4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.charm,
            state = Upgrade.State.available,
            name = "Engine Level IV",
            description = "Speed +4",
            price = 200
        };

        charm5 = new Upgrade
        {
            upgradeNumber = 5,
            category = Upgrade.Category.charm,
            state = Upgrade.State.locked,
            name = "Engine Level V",
            description = "Speed +5",
            price = 300
        };

        charm6 = new Upgrade
        {
            upgradeNumber = 6,
            category = Upgrade.Category.charm,
            state = Upgrade.State.locked,
            name = "Engine Level VI",
            description = "Speed +6",
            price = 400
        };

        charm7 = new Upgrade
        {
            upgradeNumber = 7,
            category = Upgrade.Category.charm,
            state = Upgrade.State.available,
            name = "Engine Level VII",
            description = "Speed +7",
            price = 300
        };

        charm8 = new Upgrade
        {
            upgradeNumber = 8,
            category = Upgrade.Category.charm,
            state = Upgrade.State.locked,
            name = "Engine Level VIII",
            description = "Speed +8",
            price = 400
        };

        charm9 = new Upgrade
        {
            upgradeNumber = 9,
            category = Upgrade.Category.charm,
            state = Upgrade.State.locked,
            name = "Engine Level IX",
            description = "Speed +9",
            price = 500
        };

        charm10 = new Upgrade
        {
            upgradeNumber = 10,
            category = Upgrade.Category.charm,
            state = Upgrade.State.available,
            name = "Engine Level X",
            description = "Speed +10",
            price = 400
        };

        charm11 = new Upgrade
        {
            upgradeNumber = 11,
            category = Upgrade.Category.charm,
            state = Upgrade.State.locked,
            name = "Engine Level XI",
            description = "Speed +11",
            price = 500
        };

        charm12 = new Upgrade
        {
            upgradeNumber = 12,
            category = Upgrade.Category.charm,
            state = Upgrade.State.locked,
            name = "Engine Level XII",
            description = "Speed +12",
            price = 600
        };

        upgradeList = new List<Upgrade>()
        {
            repair1, repair2, repair3, repair4, repair5, repair6, repair7, repair8, repair9, repair10, repair11, repair12,
            speech1, speech2, speech3, speech4, speech5, speech6, speech7, speech8, speech9, speech10, speech11, speech12,
            charm1, charm2, charm3, charm4, charm5, charm6, charm7, charm8, charm9, charm10, charm11, charm12,
        };

        currentUpgrade = repair1;
    }

    public static void UpdateSchoolIcons()
    {
        if (playerController == null) playerController = GameObject.Find("PlayerRacer").GetComponent<PlayerController>();

        int repairLevel = playerController.RepairSkillLevel;
        int speechLevel = playerController.SpeechSkillLevel;
        int charmLevel = playerController.CharmSkillLevel;

        foreach (GameObject icon in schoolIconList)
        {
            icon.SetActive(false);
        }

        switch (GameManager.GameLevel)
        {
            case 0:
                schoolT1.SetActive(true);
                schoolT2.SetActive(false);
                schoolT3.SetActive(false);
                schoolT4.SetActive(false);
                break;

            case 1:
                schoolT1.SetActive(false);
                schoolT2.SetActive(true);
                schoolT3.SetActive(false);
                schoolT4.SetActive(false);
                break;

            case 2:
                schoolT1.SetActive(false);
                schoolT2.SetActive(false);
                schoolT3.SetActive(true);
                schoolT4.SetActive(false);
                break;

            case 3:
                schoolT1.SetActive(false);
                schoolT2.SetActive(false);
                schoolT3.SetActive(false);
                schoolT4.SetActive(true);
                break;
        }

        switch (repairLevel)
        {
            case 0:
                //repair 1 available
                repair2lock.SetActive(true);
                repair3lock.SetActive(true);
                break;
            case 1:
                repair1check.SetActive(true);
                //repair 2 available
                repair3lock.SetActive(true);
                break;
            case 2:
                repair1check.SetActive(true);
                repair2check.SetActive(true);
                //repair 3 available
                break;
            case 3:
                repair1check.SetActive(true);
                repair2check.SetActive(true);
                repair3check.SetActive(true);
                // repair 4 available
                repair5lock.SetActive(true);
                repair6lock.SetActive(true);
                break;
            case 4:
                repair4check.SetActive(true);
                //repair 5 available
                repair6lock.SetActive(true);
                break;
            case 5:
                repair4check.SetActive(true);
                repair5check.SetActive(true);
                //repair 6 available
                break;
            case 6:
                repair4check.SetActive(true);
                repair5check.SetActive(true);
                repair6check.SetActive(true);
                // repair 7 available
                repair8lock.SetActive(true);
                repair9lock.SetActive(true);
                break;
            case 7:
                repair7check.SetActive(true);
                //repair 8 available
                repair9lock.SetActive(true);
                break;
            case 8:
                repair7check.SetActive(true);
                repair8check.SetActive(true);
                //repair 9 available
                break;
            case 9:
                repair7check.SetActive(true);
                repair8check.SetActive(true);
                repair9check.SetActive(true);
                //repair 10 available
                repair11lock.SetActive(true);
                repair12lock.SetActive(true);
                break;
            case 10:
                repair10check.SetActive(true);
                //repair 11 available
                repair12lock.SetActive(true);
                break;
            case 11:
                repair10check.SetActive(true);
                repair11check.SetActive(true);
                //repair 12 available
                break;
            case 12:
                repair10check.SetActive(true);
                repair11check.SetActive(true);
                repair12check.SetActive(true);
                break;

        }

        switch (speechLevel)
        {
            case 0:
                //speech 1 available
                speech2lock.SetActive(true);
                speech3lock.SetActive(true);
                break;
            case 1:
                speech1check.SetActive(true);
                //speech 2 available
                speech3lock.SetActive(true);
                break;
            case 2:
                speech1check.SetActive(true);
                speech2check.SetActive(true);
                //speech 3 available
                break;
            case 3:
                speech1check.SetActive(true);
                speech2check.SetActive(true);
                speech3check.SetActive(true);
                // speech 4 available
                speech5lock.SetActive(true);
                speech6lock.SetActive(true);
                break;
            case 4:
                speech4check.SetActive(true);
                //speech 5 available
                speech6lock.SetActive(true);
                break;
            case 5:
                speech4check.SetActive(true);
                speech5check.SetActive(true);
                //speech 6 available
                break;
            case 6:
                speech4check.SetActive(true);
                speech5check.SetActive(true);
                speech6check.SetActive(true);
                // speech 7 available
                speech8lock.SetActive(true);
                speech9lock.SetActive(true);
                break;
            case 7:
                speech7check.SetActive(true);
                //speech 8 available
                speech9lock.SetActive(true);
                break;
            case 8:
                speech7check.SetActive(true);
                speech8check.SetActive(true);
                //speech 9 available
                break;
            case 9:
                speech7check.SetActive(true);
                speech8check.SetActive(true);
                speech9check.SetActive(true);
                //speech 10 available
                speech11lock.SetActive(true);
                speech12lock.SetActive(true);
                break;
            case 10:
                speech10check.SetActive(true);
                //speech 11 available
                speech12lock.SetActive(true);
                break;
            case 11:
                speech10check.SetActive(true);
                speech11check.SetActive(true);
                //speech 12 available
                break;
            case 12:
                speech10check.SetActive(true);
                speech11check.SetActive(true);
                speech12check.SetActive(true);
                break;
        }

        switch (charmLevel)
        {
            case 0:
                //charm 1 available
                charm2lock.SetActive(true);
                charm3lock.SetActive(true);
                break;
            case 1:
                charm1check.SetActive(true);
                //charm 2 available
                charm3lock.SetActive(true);
                break;
            case 2:
                charm1check.SetActive(true);
                charm2check.SetActive(true);
                //charm 3 available
                break;
            case 3:
                charm1check.SetActive(true);
                charm2check.SetActive(true);
                charm3check.SetActive(true);
                // charm 4 available
                charm5lock.SetActive(true);
                charm6lock.SetActive(true);
                break;
            case 4:
                charm4check.SetActive(true);
                //charm 5 available
                charm6lock.SetActive(true);
                break;
            case 5:
                charm4check.SetActive(true);
                charm5check.SetActive(true);
                //charm 6 available
                break;
            case 6:
                charm4check.SetActive(true);
                charm5check.SetActive(true);
                charm6check.SetActive(true);
                // charm 7 available
                charm8lock.SetActive(true);
                charm9lock.SetActive(true);
                break;
            case 7:
                charm7check.SetActive(true);
                //charm 8 available
                charm9lock.SetActive(true);
                break;
            case 8:
                charm7check.SetActive(true);
                charm8check.SetActive(true);
                //charm 9 available
                break;
            case 9:
                charm7check.SetActive(true);
                charm8check.SetActive(true);
                charm9check.SetActive(true);
                //charm 10 available
                charm11lock.SetActive(true);
                charm12lock.SetActive(true);
                break;
            case 10:
                charm10check.SetActive(true);
                //charm 11 available
                charm12lock.SetActive(true);
                break;
            case 11:
                charm10check.SetActive(true);
                charm11check.SetActive(true);
                //charm 12 available
                break;
            case 12:
                charm10check.SetActive(true);
                charm11check.SetActive(true);
                charm12check.SetActive(true);
                break;
        }
    }

    public static Upgrade GetDefaultUpgrade()
    {
        switch (GameManager.GameLevel)
        {
            case 0:
                return repair1;
            case 1:
                return repair4;
            case 2:
                return repair7;
            case 3:
                return repair10;
            default:
                return repair1;
        }
    }

    public void RepairUpgradeClicked(int levelButton)
    {
        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateSchoolClicked(repair1);
                currentUpgrade = repair1;
                break;
            case 2:
                ScreenManager.UpdateSchoolClicked(repair2);
                currentUpgrade = repair2;
                break;
            case 3:
                ScreenManager.UpdateSchoolClicked(repair3);
                currentUpgrade = repair3;
                break;
            case 4:
                ScreenManager.UpdateSchoolClicked(repair4);
                currentUpgrade = repair4;
                break;
            case 5:
                ScreenManager.UpdateSchoolClicked(repair5);
                currentUpgrade = repair5;
                break;
            case 6:
                ScreenManager.UpdateSchoolClicked(repair6);
                currentUpgrade = repair6;
                break;
            case 7:
                ScreenManager.UpdateSchoolClicked(repair7);
                currentUpgrade = repair7;
                break;
            case 8:
                ScreenManager.UpdateSchoolClicked(repair8);
                currentUpgrade = repair8;
                break;
            case 9:
                ScreenManager.UpdateSchoolClicked(repair9);
                currentUpgrade = repair9;
                break;
            case 10:
                ScreenManager.UpdateSchoolClicked(repair10);
                currentUpgrade = repair10;
                break;
            case 11:
                ScreenManager.UpdateSchoolClicked(repair11);
                currentUpgrade = repair11;
                break;
            case 12:
                ScreenManager.UpdateSchoolClicked(repair12);
                currentUpgrade = repair12;
                break;
        }
        UpdateSelectedIcon(currentUpgrade);
    }

    public void SpeechUpgradeClicked(int levelButton)
    {
        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateSchoolClicked(speech1);
                currentUpgrade = speech1;
                break;
            case 2:
                ScreenManager.UpdateSchoolClicked(speech2);
                currentUpgrade = speech2;
                break;
            case 3:
                ScreenManager.UpdateSchoolClicked(speech3);
                currentUpgrade = speech3;
                break;
            case 4:
                ScreenManager.UpdateSchoolClicked(speech4);
                currentUpgrade = speech4;
                break;
            case 5:
                ScreenManager.UpdateSchoolClicked(speech5);
                currentUpgrade = speech5;
                break;
            case 6:
                ScreenManager.UpdateSchoolClicked(speech6);
                currentUpgrade = speech6;
                break;
            case 7:
                ScreenManager.UpdateSchoolClicked(speech7);
                currentUpgrade = speech7;
                break;
            case 8:
                ScreenManager.UpdateSchoolClicked(speech8);
                currentUpgrade = speech8;
                break;
            case 9:
                ScreenManager.UpdateSchoolClicked(speech9);
                currentUpgrade = speech9;
                break;
            case 10:
                ScreenManager.UpdateSchoolClicked(speech10);
                currentUpgrade = speech10;
                break;
            case 11:
                ScreenManager.UpdateSchoolClicked(speech11);
                currentUpgrade = speech11;
                break;
            case 12:
                ScreenManager.UpdateSchoolClicked(speech12);
                currentUpgrade = speech12;
                break;
        }
        UpdateSelectedIcon(currentUpgrade);
    }

    public void CharmUpgradeClicked(int levelButton)
    {
        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateSchoolClicked(charm1);
                currentUpgrade = charm1;
                break;
            case 2:
                ScreenManager.UpdateSchoolClicked(charm2);
                currentUpgrade = charm2;
                break;
            case 3:
                ScreenManager.UpdateSchoolClicked(charm3);
                currentUpgrade = charm3;
                break;
            case 4:
                ScreenManager.UpdateSchoolClicked(charm4);
                currentUpgrade = charm4;
                break;
            case 5:
                ScreenManager.UpdateSchoolClicked(charm5);
                currentUpgrade = charm5;
                break;
            case 6:
                ScreenManager.UpdateSchoolClicked(charm6);
                currentUpgrade = charm6;
                break;
            case 7:
                ScreenManager.UpdateSchoolClicked(charm7);
                currentUpgrade = charm7;
                break;
            case 8:
                ScreenManager.UpdateSchoolClicked(charm8);
                currentUpgrade = charm8;
                break;
            case 9:
                ScreenManager.UpdateSchoolClicked(charm9);
                currentUpgrade = charm9;
                break;
            case 10:
                ScreenManager.UpdateSchoolClicked(charm10);
                currentUpgrade = charm10;
                break;
            case 11:
                ScreenManager.UpdateSchoolClicked(charm11);
                currentUpgrade = charm11;
                break;
            case 12:
                ScreenManager.UpdateSchoolClicked(charm12);
                currentUpgrade = charm12;
                break;
        }
        UpdateSelectedIcon(currentUpgrade);
    }

    public void PurchaseClicked()
    {
        player = GameObject.Find("PlayerRacer").GetComponent<PlayerController>();
        switch(currentUpgrade.category)
        {
            case Upgrade.Category.repair:
                player.SpendMoney(currentUpgrade.price);
                player.RepairSkillLevel = currentUpgrade.upgradeNumber;
                break;

            case Upgrade.Category.speech:
                player.SpendMoney(currentUpgrade.price);
                player.SpeechSkillLevel = currentUpgrade.upgradeNumber;
                break;

            case Upgrade.Category.charm:
                player.SpendMoney(currentUpgrade.price);
                player.CharmSkillLevel = currentUpgrade.upgradeNumber;
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

        UpdateSchoolIcons();
        ScreenManager.UpdateSchoolClicked(currentUpgrade);
        UpdateSelectedIcon(currentUpgrade);
    }

    static void UpdateSelectedIcon(Upgrade input)
    {
        if (!upgradeSelect.activeSelf) upgradeSelect.SetActive(true);

        switch (input.category)
        {
            case Upgrade.Category.repair:
                if (input.upgradeNumber == 1 || input.upgradeNumber == 4 || input.upgradeNumber == 7 || input.upgradeNumber == 10) upgradeSelect.transform.position = repair1check.transform.position;
                if (input.upgradeNumber == 2 || input.upgradeNumber == 5 || input.upgradeNumber == 8 || input.upgradeNumber == 11) upgradeSelect.transform.position = repair2check.transform.position;
                if (input.upgradeNumber == 3 || input.upgradeNumber == 6 || input.upgradeNumber == 9 || input.upgradeNumber == 12) upgradeSelect.transform.position = repair3check.transform.position;
                break;

            case Upgrade.Category.speech:
                if (input.upgradeNumber == 1 || input.upgradeNumber == 4 || input.upgradeNumber == 7 || input.upgradeNumber == 10) upgradeSelect.transform.position = speech1check.transform.position;
                if (input.upgradeNumber == 2 || input.upgradeNumber == 5 || input.upgradeNumber == 8 || input.upgradeNumber == 11) upgradeSelect.transform.position = speech2lock.transform.position;
                if (input.upgradeNumber == 3 || input.upgradeNumber == 6 || input.upgradeNumber == 9 || input.upgradeNumber == 12) upgradeSelect.transform.position = speech3lock.transform.position;
                break;

            case Upgrade.Category.charm:
                if (input.upgradeNumber == 1 || input.upgradeNumber == 4 || input.upgradeNumber == 7 || input.upgradeNumber == 10) upgradeSelect.transform.position = charm1check.transform.position;
                if (input.upgradeNumber == 2 || input.upgradeNumber == 5 || input.upgradeNumber == 8 || input.upgradeNumber == 11) upgradeSelect.transform.position = charm2lock.transform.position;
                if (input.upgradeNumber == 3 || input.upgradeNumber == 6 || input.upgradeNumber == 9 || input.upgradeNumber == 12) upgradeSelect.transform.position = charm3lock.transform.position;
                break;
        }
    }

}
