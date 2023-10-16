using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public enum UpgradeCategory
    {
        engine,
        armour,
        repair,
        speech
    }

    public UpgradeCategory currentCategory = UpgradeCategory.engine;
    public int currentSelectedLevel = 0;
    // Start is called before the first frame update
    private int engineUpgradeLevel;
    private int armourUpgradeLevel;

    private int repairSkill;
    private int speechSkill;

    private int currentFunds;

    PlayerController player;

    Upgrade engine1;
    Upgrade engine2;
    Upgrade engine3;

    private List<Upgrade> upgradeList;

    static Upgrade currentUpgrade;

    void Start()
    {
        player = GameObject.Find("PlayerRacer").GetComponent<PlayerController>();

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

        upgradeList = new List<Upgrade>() { engine1, engine2, engine3 };

        currentUpgrade = engine1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPlayerStats()
    {
        engineUpgradeLevel = player.GetEngineLevel();
        armourUpgradeLevel = player.GetArmourLevel();
        repairSkill = player.GetRepairSkill();
        speechSkill = player.GetSpeechSkill();
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

    public void PurchaseClicked()
    {
        switch(currentUpgrade.category)
        {
            case Upgrade.Category.engine:
                player.SpendMoney(currentUpgrade.price);
                player.SetEngineLevel(currentUpgrade.upgradeNumber);
                break;

            case Upgrade.Category.armour:
                player.SpendMoney(currentUpgrade.price);
                player.SetArmourLevel(currentUpgrade.upgradeNumber);
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
