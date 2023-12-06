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


    private static List<Upgrade> upgradeList;

    static Upgrade currentUpgrade;

    static GameObject upgradeSelect;

    static GameObject schoolT1;
    static GameObject schoolT2;
    static GameObject schoolT3;
    static GameObject schoolT4;

    static Button repair1Button;
    static Button repair4Button;
    static Button repair7Button;
    static Button repair10Button;

    // T1 School Elements:
    static GameObject repair1check;
    static GameObject repair1grey;

    static GameObject repair2lock;
    static GameObject repair2check;
    static GameObject repair2grey;

    static GameObject repair3lock;
    static GameObject repair3check;
    static GameObject repair3grey;

    static GameObject speech1check;
    static GameObject speech1grey;

    static GameObject speech2lock;
    static GameObject speech2check;
    static GameObject speech2grey;

    static GameObject speech3lock;
    static GameObject speech3check;
    static GameObject speech3grey;

    static GameObject charm1check;
    static GameObject charm1grey;

    static GameObject charm2lock;
    static GameObject charm2check;
    static GameObject charm2grey;

    static GameObject charm3lock;
    static GameObject charm3check;
    static GameObject charm3grey;

    // T2 School Elements:
    static GameObject repair4check;
    static GameObject repair4grey;

    static GameObject repair5lock;
    static GameObject repair5check;
    static GameObject repair5grey;

    static GameObject repair6lock;
    static GameObject repair6check;
    static GameObject repair6grey;

    static GameObject speech4check;
    static GameObject speech4grey;

    static GameObject speech5lock;
    static GameObject speech5check;
    static GameObject speech5grey;

    static GameObject speech6lock;
    static GameObject speech6check;
    static GameObject speech6grey;

    static GameObject charm4check;
    static GameObject charm4grey;

    static GameObject charm5lock;
    static GameObject charm5check;
    static GameObject charm5grey;

    static GameObject charm6lock;
    static GameObject charm6check;
    static GameObject charm6grey;

    // T3 School Elements
    static GameObject repair7check;
    static GameObject repair7grey;

    static GameObject repair8lock;
    static GameObject repair8check;
    static GameObject repair8grey;

    static GameObject repair9lock;
    static GameObject repair9check;
    static GameObject repair9grey;

    static GameObject speech7check;
    static GameObject speech7grey;

    static GameObject speech8lock;
    static GameObject speech8check;
    static GameObject speech8grey;

    static GameObject speech9lock;
    static GameObject speech9check;
    static GameObject speech9grey;

    static GameObject charm7check;
    static GameObject charm7grey;

    static GameObject charm8lock;
    static GameObject charm8check;
    static GameObject charm8grey;

    static GameObject charm9lock;
    static GameObject charm9check;
    static GameObject charm9grey;

    // T4 School Elements
    static GameObject repair10check;
    static GameObject repair10grey;

    static GameObject repair11lock;
    static GameObject repair11check;
    static GameObject repair11grey;

    static GameObject repair12lock;
    static GameObject repair12check;
    static GameObject repair12grey;

    static GameObject speech10check;
    static GameObject speech10grey;

    static GameObject speech11lock;
    static GameObject speech11check;
    static GameObject speech11grey;

    static GameObject speech12lock;
    static GameObject speech12check;
    static GameObject speech12grey;

    static GameObject charm10check;
    static GameObject charm10grey;

    static GameObject charm11lock;
    static GameObject charm11check;
    static GameObject charm11grey;

    static GameObject charm12lock;
    static GameObject charm12check;
    static GameObject charm12grey;
    //
    static List<GameObject> schoolIconList;

    static PlayerController playerController;

    void StartElements()
    {
        schoolT1 = GameObject.Find("School/T1");
        schoolT2 = GameObject.Find("School/T2");
        schoolT3 = GameObject.Find("School/T3");
        schoolT4 = GameObject.Find("School/T4");

        repair1Button = GameObject.Find("ScreenManager/School/T1/RepairUpgrades/Upgrade1").GetComponent<Button>();
        repair4Button = GameObject.Find("ScreenManager/School/T2/RepairUpgrades/Upgrade1").GetComponent<Button>();
        repair7Button = GameObject.Find("ScreenManager/School/T3/RepairUpgrades/Upgrade1").GetComponent<Button>();
        repair10Button = GameObject.Find("ScreenManager/School/T4/RepairUpgrades/Upgrade1").GetComponent<Button>();

        upgradeSelect = GameObject.Find("ScreenManager/School/Select");

        // School T1 Elements
        repair1check = GameObject.Find("ScreenManager/School/T1/RepairUpgrades/Upgrade1/Check");
        repair1grey = GameObject.Find("ScreenManager/School/T1/RepairUpgrades/Upgrade1/Grey");


        repair2lock = GameObject.Find("ScreenManager/School/T1/RepairUpgrades/Upgrade2/Lock");
        repair2check = GameObject.Find("ScreenManager/School/T1/RepairUpgrades/Upgrade2/Check");
        repair2grey = GameObject.Find("ScreenManager/School/T1/RepairUpgrades/Upgrade2/Grey");

        repair3lock = GameObject.Find("ScreenManager/School/T1/RepairUpgrades/Upgrade3/Lock");
        repair3check = GameObject.Find("ScreenManager/School/T1/RepairUpgrades/Upgrade3/Check");
        repair3grey = GameObject.Find("ScreenManager/School/T1/RepairUpgrades/Upgrade3/Grey");

        speech1check = GameObject.Find("ScreenManager/School/T1/SpeechUpgrades/Upgrade1/Check");
        speech1grey = GameObject.Find("ScreenManager/School/T1/SpeechUpgrades/Upgrade1/Grey");

        speech2lock = GameObject.Find("ScreenManager/School/T1/SpeechUpgrades/Upgrade2/Lock");
        speech2check = GameObject.Find("ScreenManager/School/T1/SpeechUpgrades/Upgrade2/Check");
        speech2grey = GameObject.Find("ScreenManager/School/T1/SpeechUpgrades/Upgrade2/Grey");

        speech3lock = GameObject.Find("ScreenManager/School/T1/SpeechUpgrades/Upgrade3/Lock");
        speech3check = GameObject.Find("ScreenManager/School/T1/SpeechUpgrades/Upgrade3/Check");
        speech3grey = GameObject.Find("ScreenManager/School/T1/SpeechUpgrades/Upgrade3/Grey");

        charm1check = GameObject.Find("ScreenManager/School/T1/CharmUpgrades/Upgrade1/Check");
        charm1grey = GameObject.Find("ScreenManager/School/T1/CharmUpgrades/Upgrade1/Grey");

        charm2lock = GameObject.Find("ScreenManager/School/T1/CharmUpgrades/Upgrade2/Lock");
        charm2check = GameObject.Find("ScreenManager/School/T1/CharmUpgrades/Upgrade2/Check");
        charm2grey = GameObject.Find("ScreenManager/School/T1/CharmUpgrades/Upgrade2/Grey");

        charm3lock = GameObject.Find("ScreenManager/School/T1/CharmUpgrades/Upgrade3/Lock");
        charm3check = GameObject.Find("ScreenManager/School/T1/CharmUpgrades/Upgrade3/Check");
        charm3grey = GameObject.Find("ScreenManager/School/T1/CharmUpgrades/Upgrade3/Grey");

        // School T2 Elements
        repair4check = GameObject.Find("ScreenManager/School/T2/RepairUpgrades/Upgrade1/Check");
        repair4grey = GameObject.Find("ScreenManager/School/T2/RepairUpgrades/Upgrade1/Grey");

        repair5lock = GameObject.Find("ScreenManager/School/T2/RepairUpgrades/Upgrade2/Lock");
        repair5check = GameObject.Find("ScreenManager/School/T2/RepairUpgrades/Upgrade2/Check");
        repair5grey = GameObject.Find("ScreenManager/School/T2/RepairUpgrades/Upgrade2/Grey");

        repair6lock = GameObject.Find("ScreenManager/School/T2/RepairUpgrades/Upgrade3/Lock");
        repair6check = GameObject.Find("ScreenManager/School/T2/RepairUpgrades/Upgrade3/Check");
        repair6grey = GameObject.Find("ScreenManager/School/T2/RepairUpgrades/Upgrade3/Grey");

        speech4check = GameObject.Find("ScreenManager/School/T2/SpeechUpgrades/Upgrade1/Check");
        speech4grey = GameObject.Find("ScreenManager/School/T2/SpeechUpgrades/Upgrade1/Grey");

        speech5lock = GameObject.Find("ScreenManager/School/T2/SpeechUpgrades/Upgrade2/Lock");
        speech5check = GameObject.Find("ScreenManager/School/T2/SpeechUpgrades/Upgrade2/Check");
        speech5grey = GameObject.Find("ScreenManager/School/T2/SpeechUpgrades/Upgrade2/Grey");

        speech6lock = GameObject.Find("ScreenManager/School/T2/SpeechUpgrades/Upgrade3/Lock");
        speech6check = GameObject.Find("ScreenManager/School/T2/SpeechUpgrades/Upgrade3/Check");
        speech6grey = GameObject.Find("ScreenManager/School/T2/SpeechUpgrades/Upgrade3/Grey");

        charm4check = GameObject.Find("ScreenManager/School/T2/CharmUpgrades/Upgrade1/Check");
        charm4grey = GameObject.Find("ScreenManager/School/T2/CharmUpgrades/Upgrade1/Grey");

        charm5lock = GameObject.Find("ScreenManager/School/T2/CharmUpgrades/Upgrade2/Lock");
        charm5check = GameObject.Find("ScreenManager/School/T2/CharmUpgrades/Upgrade2/Check");
        charm5grey = GameObject.Find("ScreenManager/School/T2/CharmUpgrades/Upgrade2/Grey");

        charm6lock = GameObject.Find("ScreenManager/School/T2/CharmUpgrades/Upgrade3/Lock");
        charm6check = GameObject.Find("ScreenManager/School/T2/CharmUpgrades/Upgrade3/Check");
        charm6grey = GameObject.Find("ScreenManager/School/T2/CharmUpgrades/Upgrade3/Grey");

        // School T3 Elements
        repair7check = GameObject.Find("ScreenManager/School/T3/RepairUpgrades/Upgrade1/Check");
        repair7grey = GameObject.Find("ScreenManager/School/T3/RepairUpgrades/Upgrade1/Grey");

        repair8lock = GameObject.Find("ScreenManager/School/T3/RepairUpgrades/Upgrade2/Lock");
        repair8check = GameObject.Find("ScreenManager/School/T3/RepairUpgrades/Upgrade2/Check");
        repair8grey = GameObject.Find("ScreenManager/School/T3/RepairUpgrades/Upgrade2/Grey");

        repair9lock = GameObject.Find("ScreenManager/School/T3/RepairUpgrades/Upgrade3/Lock");
        repair9check = GameObject.Find("ScreenManager/School/T3/RepairUpgrades/Upgrade3/Check");
        repair9grey = GameObject.Find("ScreenManager/School/T3/RepairUpgrades/Upgrade3/Grey");

        speech7check = GameObject.Find("ScreenManager/School/T3/SpeechUpgrades/Upgrade1/Check");
        speech7grey = GameObject.Find("ScreenManager/School/T3/SpeechUpgrades/Upgrade1/Grey");

        speech8lock = GameObject.Find("ScreenManager/School/T3/SpeechUpgrades/Upgrade2/Lock");
        speech8check = GameObject.Find("ScreenManager/School/T3/SpeechUpgrades/Upgrade2/Check");
        speech8grey = GameObject.Find("ScreenManager/School/T3/SpeechUpgrades/Upgrade2/Grey");

        speech9lock = GameObject.Find("ScreenManager/School/T3/SpeechUpgrades/Upgrade3/Lock");
        speech9check = GameObject.Find("ScreenManager/School/T3/SpeechUpgrades/Upgrade3/Check");
        speech9grey = GameObject.Find("ScreenManager/School/T3/SpeechUpgrades/Upgrade3/Grey");

        charm7check = GameObject.Find("ScreenManager/School/T3/CharmUpgrades/Upgrade1/Check");
        charm7grey = GameObject.Find("ScreenManager/School/T3/CharmUpgrades/Upgrade1/Grey");

        charm8lock = GameObject.Find("ScreenManager/School/T3/CharmUpgrades/Upgrade2/Lock");
        charm8check = GameObject.Find("ScreenManager/School/T3/CharmUpgrades/Upgrade2/Check");
        charm8grey = GameObject.Find("ScreenManager/School/T3/CharmUpgrades/Upgrade2/Grey");

        charm9lock = GameObject.Find("ScreenManager/School/T3/CharmUpgrades/Upgrade3/Lock");
        charm9check = GameObject.Find("ScreenManager/School/T3/CharmUpgrades/Upgrade3/Check");
        charm9grey = GameObject.Find("ScreenManager/School/T3/CharmUpgrades/Upgrade3/Grey");

        // School T4 Elements
        repair10check = GameObject.Find("ScreenManager/School/T4/RepairUpgrades/Upgrade1/Check");
        repair10grey = GameObject.Find("ScreenManager/School/T4/RepairUpgrades/Upgrade1/Grey");

        repair11lock = GameObject.Find("ScreenManager/School/T4/RepairUpgrades/Upgrade2/Lock");
        repair11check = GameObject.Find("ScreenManager/School/T4/RepairUpgrades/Upgrade2/Check");
        repair11grey = GameObject.Find("ScreenManager/School/T4/RepairUpgrades/Upgrade2/Grey");

        repair12lock = GameObject.Find("ScreenManager/School/T4/RepairUpgrades/Upgrade3/Lock");
        repair12check = GameObject.Find("ScreenManager/School/T4/RepairUpgrades/Upgrade3/Check");
        repair12grey = GameObject.Find("ScreenManager/School/T4/RepairUpgrades/Upgrade3/Grey");

        speech10check = GameObject.Find("ScreenManager/School/T4/SpeechUpgrades/Upgrade1/Check");
        speech10grey = GameObject.Find("ScreenManager/School/T4/SpeechUpgrades/Upgrade1/Grey");

        speech11lock = GameObject.Find("ScreenManager/School/T4/SpeechUpgrades/Upgrade2/Lock");
        speech11check = GameObject.Find("ScreenManager/School/T4/SpeechUpgrades/Upgrade2/Check");
        speech11grey = GameObject.Find("ScreenManager/School/T4/SpeechUpgrades/Upgrade2/Grey");

        speech12lock = GameObject.Find("ScreenManager/School/T4/SpeechUpgrades/Upgrade3/Lock");
        speech12check = GameObject.Find("ScreenManager/School/T4/SpeechUpgrades/Upgrade3/Check");
        speech12grey = GameObject.Find("ScreenManager/School/T4/SpeechUpgrades/Upgrade3/Grey");

        charm10check = GameObject.Find("ScreenManager/School/T4/CharmUpgrades/Upgrade1/Check");
        charm10grey = GameObject.Find("ScreenManager/School/T4/CharmUpgrades/Upgrade1/Grey");

        charm11lock = GameObject.Find("ScreenManager/School/T4/CharmUpgrades/Upgrade2/Lock");
        charm11check = GameObject.Find("ScreenManager/School/T4/CharmUpgrades/Upgrade2/Check");
        charm11grey = GameObject.Find("ScreenManager/School/T4/CharmUpgrades/Upgrade2/Grey");

        charm12lock = GameObject.Find("ScreenManager/School/T4/CharmUpgrades/Upgrade3/Lock");
        charm12check = GameObject.Find("ScreenManager/School/T4/CharmUpgrades/Upgrade3/Check");
        charm12grey = GameObject.Find("ScreenManager/School/T4/CharmUpgrades/Upgrade3/Grey");

        schoolIconList = new List<GameObject>
        {
            repair1check, repair2lock, repair2check, repair3lock, repair3check, speech1check, speech2lock, speech2check, speech3lock, speech3check, charm1check, charm2lock, charm2check, charm3lock, charm3check,
            repair4check, repair5lock, repair5check, repair6lock, repair6check, speech4check, speech5lock, speech5check, speech6lock, speech6check, charm4check, charm5lock, charm5check, charm6lock, charm6check,
            repair7check, repair8lock, repair8check, repair9lock, repair9check, speech7check, speech8lock, speech8check, speech9lock, speech9check, charm7check, charm8lock, charm8check, charm9lock, charm9check,
            repair10check, repair11lock, repair11check, repair12lock, repair12check, speech10check, speech11lock, speech11check, speech12lock, speech12check, charm10check, charm11lock, charm11check, charm12lock, charm12check,
            repair1grey, repair2grey, repair3grey, repair4grey, repair5grey, repair6grey, repair7grey, repair8grey, repair9grey, repair10grey, repair11grey, repair12grey,
            speech1grey, speech2grey, speech3grey, speech4grey, speech5grey, speech6grey, speech7grey, speech8grey, speech9grey, speech10grey, speech11grey, speech12grey,
            charm1grey, charm2grey, charm3grey, charm4grey, charm5grey, charm6grey, charm7grey, charm8grey, charm9grey, charm10grey, charm11grey, charm12grey
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
            name = "Repair Skill I",
            description = "+1 health gained from repair kits.",
            price = 100,
            greyObj = repair1grey,
            checkObj = repair1check,
            lockObj = null
        };

        repair2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.repair,
            state = Upgrade.State.locked,
            name = "Repair Skill II",
            description = "+2 health gained from repair kits.",
            price = 200,
            greyObj = repair2grey,
            checkObj = repair2check,
            lockObj = repair2lock
        };

        repair3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.repair,
            state = Upgrade.State.locked,
            name = "Repair Skill III",
            description = "+3 health gained from repair kits.",
            price = 300,
            greyObj = repair3grey,
            checkObj = repair3check,
            lockObj = repair3lock
        };

        repair4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.repair,
            state = Upgrade.State.available,
            name = "Repair Skill IV",
            description = "+4 health gained from repair kits.",
            price = 200,
            greyObj = repair4grey,
            checkObj = repair4check,
            lockObj = null
        };

        repair5 = new Upgrade
        {
            upgradeNumber = 5,
            category = Upgrade.Category.repair,
            state = Upgrade.State.locked,
            name = "Repair Skill V",
            description = "+5 health gained from repair kits.",
            price = 300,
            greyObj = repair5grey,
            checkObj = repair5check,
            lockObj = repair5lock
        };

        repair6 = new Upgrade
        {
            upgradeNumber = 6,
            category = Upgrade.Category.repair,
            state = Upgrade.State.locked,
            name = "Repair Skill VI",
            description = "+6 health gained from repair kits.",
            price = 400,
            greyObj = repair6grey,
            checkObj = repair6check,
            lockObj = repair6lock
        };

        repair7 = new Upgrade
        {
            upgradeNumber = 7,
            category = Upgrade.Category.repair,
            state = Upgrade.State.available,
            name = "Repair Skill VII",
            description = "+7 health gained from repair kits.",
            price = 300,
            greyObj = repair7grey,
            checkObj = repair7check,
            lockObj = null
        };

        repair8 = new Upgrade
        {
            upgradeNumber = 8,
            category = Upgrade.Category.repair,
            state = Upgrade.State.locked,
            name = "Repair Skill VIII",
            description = "+8 health gained from repair kits.",
            price = 400,
            greyObj = repair8grey,
            checkObj = repair8check,
            lockObj = repair8lock
        };

        repair9 = new Upgrade
        {
            upgradeNumber = 9,
            category = Upgrade.Category.repair,
            state = Upgrade.State.locked,
            name = "Repair Skill IX",
            description = "+9 health gained from repair kits.",
            price = 500,
            greyObj = repair9grey,
            checkObj = repair9check,
            lockObj = repair9lock
        };

        repair10 = new Upgrade
        {
            upgradeNumber = 10,
            category = Upgrade.Category.repair,
            state = Upgrade.State.available,
            name = "Repair Skill X",
            description = "+10 health gained from repair kits.",
            price = 400,
            greyObj = repair10grey,
            checkObj = repair10check,
            lockObj = null
        };

        repair11 = new Upgrade
        {
            upgradeNumber = 11,
            category = Upgrade.Category.repair,
            state = Upgrade.State.locked,
            name = "Repair Skill XI",
            description = "+11 health gained from repair kits.",
            price = 500,
            greyObj = repair11grey,
            checkObj = repair11check,
            lockObj = repair11lock
        };

        repair12 = new Upgrade
        {
            upgradeNumber = 12,
            category = Upgrade.Category.repair,
            state = Upgrade.State.locked,
            name = "Repair Skill XII",
            description = "+12 health gained from repair kits.",
            price = 600,
            greyObj = repair12grey,
            checkObj = repair12check,
            lockObj = repair12lock
        };

        speech1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.speech,
            state = Upgrade.State.available,
            name = "Rat Speech I",
            description = "+1 bonus to money earned after races.",
            price = 100,
            greyObj = speech1grey,
            checkObj = speech1check,
            lockObj = null
        };

        speech2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.speech,
            state = Upgrade.State.locked,
            name = "Rat Speech II",
            description = "+2 bonus to money earned after races.",
            price = 200,
            greyObj = speech2grey,
            checkObj = speech2check,
            lockObj = speech2lock
        };

        speech3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.speech,
            state = Upgrade.State.locked,
            name = "Rat Speech III",
            description = "+3 bonus to money earned after races.",
            price = 400,
            greyObj = speech3grey,
            checkObj = speech3check,
            lockObj = speech3lock
        };

        speech4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.speech,
            state = Upgrade.State.available,
            name = "Rat Speech IV",
            description = "+4 bonus to money earned after races.",
            price = 200,
            greyObj = speech4grey,
            checkObj = speech4check,
            lockObj = null
        };

        speech5 = new Upgrade
        {
            upgradeNumber = 5,
            category = Upgrade.Category.speech,
            state = Upgrade.State.locked,
            name = "Rat Speech V",
            description = "+5 bonus to money earned after races.",
            price = 300,
            greyObj = speech5grey,
            checkObj = speech5check,
            lockObj = speech5lock
        };

        speech6 = new Upgrade
        {
            upgradeNumber = 6,
            category = Upgrade.Category.speech,
            state = Upgrade.State.locked,
            name = "Rat Speech VI",
            description = "+6 bonus to money earned after races.",
            price = 400,
            greyObj = speech6grey,
            checkObj = speech6check,
            lockObj = speech6lock
        };

        speech7 = new Upgrade
        {
            upgradeNumber = 7,
            category = Upgrade.Category.speech,
            state = Upgrade.State.available,
            name = "Rat Speech VII",
            description = "+7 bonus to money earned after races.",
            price = 300,
            greyObj = speech7grey,
            checkObj = speech7check,
            lockObj = null
        };

        speech8 = new Upgrade
        {
            upgradeNumber = 8,
            category = Upgrade.Category.speech,
            state = Upgrade.State.locked,
            name = "Rat Speech VIII",
            description = "+8 bonus to money earned after races.",
            price = 400,
            greyObj = speech8grey,
            checkObj = speech8check,
            lockObj = speech8lock
        };

        speech9 = new Upgrade
        {
            upgradeNumber = 9,
            category = Upgrade.Category.speech,
            state = Upgrade.State.locked,
            name = "Rat Speech IX",
            description = "+9 bonus to money earned after races.",
            price = 500,
            greyObj = speech9grey,
            checkObj = speech9check,
            lockObj = speech9lock
        };

        speech10 = new Upgrade
        {
            upgradeNumber = 10,
            category = Upgrade.Category.speech,
            state = Upgrade.State.available,
            name = "Rat Speech X",
            description = "+10 bonus to money earned after races.",
            price = 400,
            greyObj = speech10grey,
            checkObj = speech10check,
            lockObj = null
        };

        speech11 = new Upgrade
        {
            upgradeNumber = 11,
            category = Upgrade.Category.speech,
            state = Upgrade.State.locked,
            name = "Rat Speech XI",
            description = "+11 bonus to money earned after races.",
            price = 500,
            greyObj = speech11grey,
            checkObj = speech11check,
            lockObj = speech11lock
        };

        speech12 = new Upgrade
        {
            upgradeNumber = 12,
            category = Upgrade.Category.speech,
            state = Upgrade.State.locked,
            name = "Rat Speech XII",
            description = "+12 bonus to money earned after races.",
            price = 600,
            greyObj = speech12grey,
            checkObj = speech12check,
            lockObj = speech12lock
        };

        charm1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.charm,
            state = Upgrade.State.available,
            name = "Charm Skill I",
            description = "-1 to chances of opponents firing at you.",
            price = 100,
            greyObj = charm1grey,
            checkObj = charm1check,
            lockObj = null
        };

        charm2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.charm,
            state = Upgrade.State.locked,
            name = "Charm Skill II",
            description = "-2 to chances of opponents firing at you.",
            price = 200,
            greyObj = charm2grey,
            checkObj = charm2check,
            lockObj = charm2lock
        };

        charm3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.charm,
            state = Upgrade.State.locked,
            name = "Charm Skill III",
            description = "-3 to chances of opponents firing at you.",
            price = 300,
            greyObj = charm3grey,
            checkObj = charm3check,
            lockObj = charm3lock
        };

        charm4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.charm,
            state = Upgrade.State.available,
            name = "Charm Skill IV",
            description = "-4 to chances of opponents firing at you.",
            price = 200,
            greyObj = charm4grey,
            checkObj = charm4check,
            lockObj = null
        };

        charm5 = new Upgrade
        {
            upgradeNumber = 5,
            category = Upgrade.Category.charm,
            state = Upgrade.State.locked,
            name = "Charm Skill V",
            description = "-5 to chances of opponents firing at you.",
            price = 300,
            greyObj = charm5grey,
            checkObj = charm5check,
            lockObj = charm5lock
        };

        charm6 = new Upgrade
        {
            upgradeNumber = 6,
            category = Upgrade.Category.charm,
            state = Upgrade.State.locked,
            name = "Charm Skill IV",
            description = "-6 to chances of opponents firing at you.",
            price = 400,
            greyObj = charm6grey,
            checkObj = charm6check,
            lockObj = charm6lock
        };

        charm7 = new Upgrade
        {
            upgradeNumber = 7,
            category = Upgrade.Category.charm,
            state = Upgrade.State.available,
            name = "Charm Skill VII",
            description = "-7 to chances of opponents firing at you.",
            price = 300,
            greyObj = charm7grey,
            checkObj = charm7check,
            lockObj = null
        };

        charm8 = new Upgrade
        {
            upgradeNumber = 8,
            category = Upgrade.Category.charm,
            state = Upgrade.State.locked,
            name = "Charm Skill VIII",
            description = "-8 to chances of opponents firing at you.",
            price = 400,
            greyObj = charm8grey,
            checkObj = charm8check,
            lockObj = charm8lock
        };

        charm9 = new Upgrade
        {
            upgradeNumber = 9,
            category = Upgrade.Category.charm,
            state = Upgrade.State.locked,
            name = "Charm Skill IX",
            description = "-9 to chances of opponents firing at you.",
            price = 500,
            greyObj = charm9grey,
            checkObj = charm9check,
            lockObj = charm9lock
        };

        charm10 = new Upgrade
        {
            upgradeNumber = 10,
            category = Upgrade.Category.charm,
            state = Upgrade.State.available,
            name = "Charm Skill X",
            description = "-10 to chances of opponents firing at you.",
            price = 400,
            greyObj = charm10grey,
            checkObj = charm10check,
            lockObj = null
        };

        charm11 = new Upgrade
        {
            upgradeNumber = 11,
            category = Upgrade.Category.charm,
            state = Upgrade.State.locked,
            name = "Charm Skill XI",
            description = "-11 to chances of opponents firing at you.",
            price = 500,
            greyObj = charm11grey,
            checkObj = charm11check,
            lockObj = charm11lock
        };

        charm12 = new Upgrade
        {
            upgradeNumber = 12,
            category = Upgrade.Category.charm,
            state = Upgrade.State.locked,
            name = "Charm Skill XII",
            description = "-12 to chances of opponents firing at you.",
            price = 600,
            greyObj = charm12grey,
            checkObj = charm12check,
            lockObj = charm12lock
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

        foreach (Upgrade upgrade in upgradeList)
        {
            switch (upgrade.state)
            {
                case Upgrade.State.available:
                    if (playerController.TotalMoney < upgrade.price) upgrade.greyObj.SetActive(true);
                    upgrade.checkObj.SetActive(false);
                    if (upgrade.lockObj != null) upgrade.lockObj.SetActive(false);
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
    }

    public static Upgrade GetDefaultUpgrade()
    {
        switch (GameManager.GameLevel)
        {
            case 0:
                currentUpgrade = repair1;
                repair1Button.Select();
                break;
            case 1:
                currentUpgrade = repair4;
                repair4Button.Select();
                break;
            case 2:
                currentUpgrade = repair7;
                repair7Button.Select();
                break;
            case 3:
                currentUpgrade = repair10;
                repair10Button.Select();
                break;
        }

        return currentUpgrade;
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

        foreach (Upgrade nextUpgrade in upgradeList)
        {
            if (nextUpgrade.category == currentUpgrade.category && nextUpgrade.upgradeNumber == currentUpgrade.upgradeNumber + 1) nextUpgrade.state = Upgrade.State.available;
        }

        currentUpgrade.state = Upgrade.State.owned;

        UpdateSchoolIcons();
        ScreenManager.UpdateSchoolClicked(currentUpgrade);
    }
}
