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
    Upgrade engine4;
    Upgrade engine5;
    Upgrade engine6;
    Upgrade engine7;
    Upgrade engine8;
    Upgrade engine9;
    Upgrade engine10;
    Upgrade engine11;
    Upgrade engine12;

    Upgrade armour1;
    Upgrade armour2;
    Upgrade armour3;
    Upgrade armour4;
    Upgrade armour5;
    Upgrade armour6;
    Upgrade armour7;
    Upgrade armour8;
    Upgrade armour9;
    Upgrade armour10;
    Upgrade armour11;
    Upgrade armour12;

    Upgrade boostSpeed1;
    Upgrade boostSpeed2;
    Upgrade boostSpeed3;
    Upgrade boostSpeed4;

    Upgrade boostCooldown1;
    Upgrade boostCooldown2;
    Upgrade boostCooldown3;
    Upgrade boostCooldown4;

    Upgrade boostRecharge1;
    Upgrade boostRecharge2;
    Upgrade boostRecharge3;
    Upgrade boostRecharge4;

    private List<Upgrade> upgradeList;

    static Upgrade currentUpgrade;

    void Start()
    {
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

        engine10 = new Upgrade();
        engine10.upgradeNumber = 10;
        engine10.category = Upgrade.Category.engine;
        engine10.state = Upgrade.State.available;
        engine10.name = "Engine Level X";
        engine10.description = "Speed +10";
        engine10.price = 400;

        engine11 = new Upgrade();
        engine11.upgradeNumber = 11;
        engine11.category = Upgrade.Category.engine;
        engine11.state = Upgrade.State.locked;
        engine11.name = "Engine Level XI";
        engine11.description = "Speed +11";
        engine11.price = 500;

        engine12 = new Upgrade();
        engine12.upgradeNumber = 12;
        engine12.category = Upgrade.Category.engine;
        engine12.state = Upgrade.State.locked;
        engine12.name = "Engine Level XII";
        engine12.description = "Speed +12";
        engine12.price = 600;

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

        ScreenManager.UpdateShopIcons();
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
