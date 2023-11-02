using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public enum UpgradeCategory
    {
        engine,
        armour,
        boost,
        repair,
        speech
    }

    public UpgradeCategory currentCategory = UpgradeCategory.engine;
    public int currentSelectedLevel = 0;
    // Start is called before the first frame update
    private int engineUpgradeLevel;
    private int armourUpgradeLevel;
    private int boostSpeedLevel;

    private int repairSkill;
    private int speechSkill;

    private int currentFunds;

    PlayerController player;

    Upgrade engine1;
    Upgrade engine2;
    Upgrade engine3;

    Upgrade armour1;
    Upgrade armour2;
    Upgrade armour3;

    Upgrade boostSpeed1;
    Upgrade boostSpeed2;
    Upgrade boostSpeed3;

    Upgrade boostCooldown1;
    Upgrade boostCooldown2;
    Upgrade boostCooldown3;

    Upgrade boostRecharge1;
    Upgrade boostRecharge2;
    Upgrade boostRecharge3;

    Button engine1Button;
    Button engine2Button;
    Button engine3Button;

    private List<Upgrade> upgradeList;

    static Upgrade currentUpgrade;

    void Start()
    {
        engine1 = new Upgrade();
        engine1.upgradeNumber = 1;
        engine1.category = Upgrade.Category.engine;
        engine1.state = Upgrade.State.available;
        engine1.name = "Tune-Up";
        engine1.description = "Basic maintenance. Increases speed.";
        engine1.price = 100;

        engine2 = new Upgrade();
        engine2.upgradeNumber = 2;
        engine2.state = Upgrade.State.locked;
        engine2.name = "New Engine";
        engine2.description = "Better than old junk. Increases speed again.";
        engine2.price = 200;

        engine3 = new Upgrade();
        engine3.upgradeNumber = 3;
        engine3.state = Upgrade.State.locked;
        engine3.name = "Modify Engine";
        engine3.description = "Performance tweaks. Further increases speed.";
        engine3.price = 400;

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

        boostSpeed1 = new Upgrade();
        boostSpeed1.upgradeNumber = 1;
        boostSpeed1.category = Upgrade.Category.boostSpeed;
        boostSpeed1.state = Upgrade.State.available;
        boostSpeed1.name = "Filtered Fuel";
        boostSpeed1.description = "Slightly cleaner burning. Increases boost speed.";
        boostSpeed1.price = 250;

        boostCooldown1 = new Upgrade();
        boostCooldown1.upgradeNumber = 1;
        boostCooldown1.category = Upgrade.Category.boostCooldown;
        boostCooldown1.state = Upgrade.State.available;
        boostCooldown1.name = "Calibrate Booster";
        boostCooldown1.description = "A little fine-tuning. Decreases boost cooldown.";
        boostCooldown1.price = 250;

        boostRecharge1 = new Upgrade();
        boostRecharge1.upgradeNumber = 1;
        boostRecharge1.category = Upgrade.Category.boostRecharge;
        boostRecharge1.state = Upgrade.State.available;
        boostRecharge1.name = "Second-Hand Parts";
        boostRecharge1.description = "Better than yours. Increases boost recharge speed.";
        boostRecharge1.price = 250;

        upgradeList = new List<Upgrade>() { engine1, engine2, engine3, armour1, armour2, armour3 };

        currentUpgrade = engine1;
    }

    public void GetPlayerStats()
    {
        engineUpgradeLevel = player.EngineUpgradeLevel;
        armourUpgradeLevel = player.ArmourUpgradeLevel;
        boostSpeedLevel = player.BoostSpeedLevel;

        repairSkill = player.RepairSkillLevel;
        speechSkill = player.SpeechSkillLevel;
        currentFunds = player.GetMoney();
    }

    public static Upgrade GetCurrentUpgrade()
    {
        return currentUpgrade;
    }

    public void EngineUpgradeClicked(int levelButton)
    {

        //currentCategory = UpgradeCategory.engine;
        //currentSelectedLevel = levelButton;

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
        }
    }

    public void ArmourUpgradeClicked(int levelButton)
    {

        //currentCategory = UpgradeCategory.engine;
        //currentSelectedLevel = levelButton;

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
        }
    }

    public void BoostSpeedUpgradeClicked(int levelButton)
    {

        //currentCategory = UpgradeCategory.engine;
        //currentSelectedLevel = levelButton;

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
        }
    }

    public void BoostCooldownUpgradeClicked(int levelButton)
    {

        //currentCategory = UpgradeCategory.engine;
        //currentSelectedLevel = levelButton;

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
        }
    }

    public void BoostRechargeUpgradeClicked(int levelButton)
    {

        //currentCategory = UpgradeCategory.engine;
        //currentSelectedLevel = levelButton;

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
        }
    }

    public void PurchaseClicked()
    {
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

        ScreenManager.UpdateUpgradeIcons();
        ScreenManager.UpdateUpgradeClicked(currentUpgrade);
    }

}

public class Upgrade
{
    public enum State
    {
        equipped,
        owned,
        available,
        locked
    }

    public enum Category
    {
        engine,
        armour,
        boostSpeed,
        boostCooldown,
        boostRecharge,
        repair,
        speech
    }

    public State state;
    public Category category;
    public int upgradeNumber;
    public string name;
    public string description;
    public int price;
}
