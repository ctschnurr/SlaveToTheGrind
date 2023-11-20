using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class ArmouryManager : MonoBehaviour
{
    public enum UpgradeCategory
    {
        bullet,
        missle,
        mine
    }

    public UpgradeCategory currentCategory = UpgradeCategory.bullet;
    public int currentSelectedLevel = 0;
    // Start is called before the first frame update

    PlayerController player;

    static Upgrade bulletAmmo;
    static Upgrade bulletClip1;
    static Upgrade bulletClip2;
    static Upgrade bulletClip3;
    static Upgrade bulletClip4;
    static Upgrade bulletCooldown1;
    static Upgrade bulletCooldown2;
    static Upgrade bulletCooldown3;
    static Upgrade bulletCooldown4;

    static Upgrade missleAmmo;
    static Upgrade missleClip1;
    static Upgrade missleClip2;
    static Upgrade missleClip3;
    static Upgrade missleClip4;
    static Upgrade missleCooldown1;
    static Upgrade missleCooldown2;
    static Upgrade missleCooldown3;
    static Upgrade missleCooldown4;

    static Upgrade mineAmmo;
    static Upgrade mineClip1;
    static Upgrade mineClip2;
    static Upgrade mineClip3;
    static Upgrade mineClip4;
    static Upgrade mineCooldown1;
    static Upgrade mineCooldown2;
    static Upgrade mineCooldown3;
    static Upgrade mineCooldown4;

    private List<Upgrade> upgradeList;

    static Upgrade currentUpgrade;
    public static Upgrade CurrentUpgrade { get { return currentUpgrade; } }

    static GameObject upgradeSelect;

    static GameObject armouryT1;
    static GameObject armouryT2;
    static GameObject armouryT3;
    static GameObject armouryT4;

    // T1 Armoury Elements:
    static GameObject bulletAmmo1Grey;
    static GameObject bulletClip1Check;
    static GameObject bulletCooldown1Check;

    static GameObject missleAmmo1Grey;
    static GameObject missleClip1Check;
    static GameObject missleCooldown1Check;

    static GameObject mineAmmo1Grey;
    static GameObject mineClip1Check;
    static GameObject mineCooldown1Check;

    // T2 Armoury Elements:
    static GameObject bulletAmmo2Grey;
    static GameObject bulletClip2Check;
    static GameObject bulletCooldown2Check;

    static GameObject missleAmmo2Grey;
    static GameObject missleClip2Check;
    static GameObject missleCooldown2Check;

    static GameObject mineAmmo2Grey;
    static GameObject mineClip2Check;
    static GameObject mineCooldown2Check;

    // T3 Armoury Elements
    static GameObject bulletAmmo3Grey;
    static GameObject bulletClip3Check;
    static GameObject bulletCooldown3Check;

    static GameObject missleAmmo3Grey;
    static GameObject missleClip3Check;
    static GameObject missleCooldown3Check;

    static GameObject mineAmmo3Grey;
    static GameObject mineClip3Check;
    static GameObject mineCooldown3Check;

    // T4 Armoury Elements
    static GameObject bulletAmmo4Grey;
    static GameObject bulletClip4Check;
    static GameObject bulletCooldown4Check;

    static GameObject missleAmmo4Grey;
    static GameObject missleClip4Check;
    static GameObject missleCooldown4Check;

    static GameObject mineAmmo4Grey;
    static GameObject mineClip4Check;
    static GameObject mineCooldown4Check;

    //
    static List<GameObject> armouryIconList;

    static PlayerController playerController;

    void StartElements()
    {
        armouryT1 = GameObject.Find("Armoury/T1");
        armouryT2 = GameObject.Find("Armoury/T2");
        armouryT3 = GameObject.Find("Armoury/T3");
        armouryT4 = GameObject.Find("Armoury/T4");

        upgradeSelect = GameObject.Find("ScreenManager/Armoury/Select");

        bulletAmmo1Grey = GameObject.Find("ScreenManager/Armoury/T1/BulletUpgrades/Upgrade1/Grey");
        bulletClip1Check = GameObject.Find("ScreenManager/Armoury/T1/BulletUpgrades/Upgrade2/Check");
        bulletCooldown1Check = GameObject.Find("ScreenManager/Armoury/T1/BulletUpgrades/Upgrade3/Check");

        missleAmmo1Grey = GameObject.Find("ScreenManager/Armoury/T1/MissleUpgrades/Upgrade1/Grey");
        missleClip1Check = GameObject.Find("ScreenManager/Armoury/T1/MissleUpgrades/Upgrade2/Check");
        missleCooldown1Check = GameObject.Find("ScreenManager/Armoury/T1/MissleUpgrades/Upgrade3/Check");

        mineAmmo1Grey = GameObject.Find("ScreenManager/Armoury/T1/MineUpgrades/Upgrade1/Grey");
        mineClip1Check = GameObject.Find("ScreenManager/Armoury/T1/MineUpgrades/Upgrade2/Check");
        mineCooldown1Check = GameObject.Find("ScreenManager/Armoury/T1/MineUpgrades/Upgrade3/Check");

        bulletAmmo2Grey = GameObject.Find("ScreenManager/Armoury/T2/BulletUpgrades/Upgrade1/Grey");
        bulletClip2Check = GameObject.Find("ScreenManager/Armoury/T2/BulletUpgrades/Upgrade2/Check");
        bulletCooldown2Check = GameObject.Find("ScreenManager/Armoury/T2/BulletUpgrades/Upgrade3/Check");

        missleAmmo2Grey = GameObject.Find("ScreenManager/Armoury/T2/MissleUpgrades/Upgrade1/Grey");
        missleClip2Check = GameObject.Find("ScreenManager/Armoury/T2/MissleUpgrades/Upgrade2/Check");
        missleCooldown2Check = GameObject.Find("ScreenManager/Armoury/T2/MissleUpgrades/Upgrade3/Check");

        mineAmmo2Grey = GameObject.Find("ScreenManager/Armoury/T2/MineUpgrades/Upgrade1/Grey");
        mineClip2Check = GameObject.Find("ScreenManager/Armoury/T2/MineUpgrades/Upgrade2/Check");
        mineCooldown2Check = GameObject.Find("ScreenManager/Armoury/T2/MineUpgrades/Upgrade3/Check");

        bulletAmmo3Grey = GameObject.Find("ScreenManager/Armoury/T3/BulletUpgrades/Upgrade1/Grey");
        bulletClip3Check = GameObject.Find("ScreenManager/Armoury/T3/BulletUpgrades/Upgrade2/Check");
        bulletCooldown3Check = GameObject.Find("ScreenManager/Armoury/T3/BulletUpgrades/Upgrade3/Check");

        missleAmmo3Grey = GameObject.Find("ScreenManager/Armoury/T3/MissleUpgrades/Upgrade1/Grey");
        missleClip3Check = GameObject.Find("ScreenManager/Armoury/T3/MissleUpgrades/Upgrade2/Check");
        missleCooldown3Check = GameObject.Find("ScreenManager/Armoury/T3/MissleUpgrades/Upgrade3/Check");

        mineAmmo3Grey = GameObject.Find("ScreenManager/Armoury/T3/MineUpgrades/Upgrade1/Grey");
        mineClip3Check = GameObject.Find("ScreenManager/Armoury/T3/MineUpgrades/Upgrade2/Check");
        mineCooldown3Check = GameObject.Find("ScreenManager/Armoury/T3/MineUpgrades/Upgrade3/Check");

        bulletAmmo4Grey = GameObject.Find("ScreenManager/Armoury/T4/BulletUpgrades/Upgrade1/Grey");
        bulletClip4Check = GameObject.Find("ScreenManager/Armoury/T4/BulletUpgrades/Upgrade2/Check");
        bulletCooldown4Check = GameObject.Find("ScreenManager/Armoury/T4/BulletUpgrades/Upgrade3/Check");

        missleAmmo4Grey = GameObject.Find("ScreenManager/Armoury/T4/MissleUpgrades/Upgrade1/Grey");
        missleClip4Check = GameObject.Find("ScreenManager/Armoury/T4/MissleUpgrades/Upgrade2/Check");
        missleCooldown4Check = GameObject.Find("ScreenManager/Armoury/T4/MissleUpgrades/Upgrade3/Check");

        mineAmmo4Grey = GameObject.Find("ScreenManager/Armoury/T4/MineUpgrades/Upgrade1/Grey");
        mineClip4Check = GameObject.Find("ScreenManager/Armoury/T4/MineUpgrades/Upgrade2/Check");
        mineCooldown4Check = GameObject.Find("ScreenManager/Armoury/T4/MineUpgrades/Upgrade3/Check");

        armouryIconList = new List<GameObject>
        {
            bulletAmmo1Grey, bulletClip1Check, bulletCooldown1Check, missleAmmo1Grey, missleClip1Check, missleCooldown1Check, mineAmmo1Grey, mineClip1Check, mineCooldown1Check,
            bulletAmmo2Grey, bulletClip2Check, bulletCooldown2Check, missleAmmo2Grey, missleClip2Check, missleCooldown2Check, mineAmmo2Grey, mineClip2Check, mineCooldown2Check,
            bulletAmmo3Grey, bulletClip3Check, bulletCooldown3Check, missleAmmo3Grey, missleClip3Check, missleCooldown3Check, mineAmmo3Grey, mineClip3Check, mineCooldown3Check,
            bulletAmmo4Grey, bulletClip4Check, bulletCooldown4Check, missleAmmo4Grey, missleClip4Check, missleCooldown4Check, mineAmmo4Grey, mineClip4Check, mineCooldown4Check
        };
    }

    public void SetupArmoury()
    {
        StartElements();

        bulletAmmo = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.bulletAmmo,
            state = Upgrade.State.available,
            name = "Bullet Ammo",
            description = "Purchase bullet ammo, $5/bullet",
            price = 5
        };

        bulletClip1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.bulletClip,
            state = Upgrade.State.available,
            name = "Bullet Clip Upgrade I",
            description = "Bullet ammo capacity +20",
            price = 100
        };

        bulletClip2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.bulletClip,
            state = Upgrade.State.available,
            name = "Bullet Clip Upgrade II",
            description = "Bullet ammo capacity +40",
            price = 150
        };

        bulletClip3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.bulletClip,
            state = Upgrade.State.available,
            name = "Bullet Clip Upgrade III",
            description = "Bullet ammo capacity +60",
            price = 200
        };

        bulletClip4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.bulletClip,
            state = Upgrade.State.available,
            name = "Bullet Clip Upgrade IV",
            description = "Bullet ammo capacity +80",
            price = 250
        };

        bulletCooldown1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.bulletCooldown,
            state = Upgrade.State.available,
            name = "Bullet Cooldown Upgrade I",
            description = "Bullet cooldown decrease.",
            price = 100
        };

        bulletCooldown2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.bulletCooldown,
            state = Upgrade.State.available,
            name = "Bullet Cooldown Upgrade II",
            description = "Bullet cooldown decrease.",
            price = 150
        };

        bulletCooldown3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.bulletCooldown,
            state = Upgrade.State.available,
            name = "Bullet Cooldown Upgrade III",
            description = "Bullet cooldown decrease.",
            price = 200
        };

        bulletCooldown4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.bulletCooldown,
            state = Upgrade.State.available,
            name = "Bullet Cooldown Upgrade IV",
            description = "Bullet cooldown decrease.",
            price = 250
        };

        missleAmmo = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.missleAmmo,
            state = Upgrade.State.available,
            name = "Missle Ammo",
            description = "Purchase missles, $15/missle",
            price = 5
        };

        missleClip1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.missleClip,
            state = Upgrade.State.available,
            name = "Missle Clip Upgrade I",
            description = "Missle ammo capacity +5",
            price = 100
        };

        missleClip2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.missleClip,
            state = Upgrade.State.available,
            name = "Missle Clip Upgrade II",
            description = "Missle ammo capacity +10",
            price = 150
        };

        missleClip3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.missleClip,
            state = Upgrade.State.available,
            name = "Missle Clip Upgrade III",
            description = "Missle ammo capacity +15",
            price = 200
        };

        missleClip4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.missleClip,
            state = Upgrade.State.available,
            name = "Missle Clip Upgrade IV",
            description = "Missle ammo capacity +20",
            price = 250
        };

        missleCooldown1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.missleCooldown,
            state = Upgrade.State.available,
            name = "Missle Cooldown Upgrade I",
            description = "Missle cooldown decrease.",
            price = 100
        };

        missleCooldown2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.missleCooldown,
            state = Upgrade.State.available,
            name = "Missle Cooldown Upgrade II",
            description = "Missle cooldown decrease.",
            price = 150
        };

        missleCooldown3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.missleCooldown,
            state = Upgrade.State.available,
            name = "Missle Cooldown Upgrade III",
            description = "Missle cooldown decrease.",
            price = 200
        };

        missleCooldown4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.missleCooldown,
            state = Upgrade.State.available,
            name = "Missle Cooldown Upgrade IV",
            description = "Missle cooldown decrease.",
            price = 250
        };

        mineAmmo = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.mineAmmo,
            state = Upgrade.State.available,
            name = "Mine Ammo",
            description = "Purchase mines, $15/mine",
            price = 5
        };

        mineClip1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.mineClip,
            state = Upgrade.State.available,
            name = "Mine Clip Upgrade I",
            description = "Mine ammo capacity +5",
            price = 100
        };

        mineClip2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.mineClip,
            state = Upgrade.State.available,
            name = "Mine Clip Upgrade II",
            description = "Mine ammo capacity +10",
            price = 150
        };

        mineClip3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.mineClip,
            state = Upgrade.State.available,
            name = "Mine Clip Upgrade III",
            description = "Mine ammo capacity +15",
            price = 200
        };

        mineClip4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.mineClip,
            state = Upgrade.State.available,
            name = "Mine Clip Upgrade IV",
            description = "Mine ammo capacity +20",
            price = 250
        };

        mineCooldown1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.mineCooldown,
            state = Upgrade.State.available,
            name = "Mine Cooldown Upgrade I",
            description = "Mine cooldown decrease.",
            price = 100
        };

        mineCooldown2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.mineCooldown,
            state = Upgrade.State.available,
            name = "Mine Cooldown Upgrade II",
            description = "Mine cooldown decrease.",
            price = 150
        };

        mineCooldown3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.mineCooldown,
            state = Upgrade.State.available,
            name = "Mine Cooldown Upgrade III",
            description = "Mine cooldown decrease.",
            price = 200
        };

        mineCooldown4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.mineCooldown,
            state = Upgrade.State.available,
            name = "Mine Cooldown Upgrade IV",
            description = "Mine cooldown decrease.",
            price = 250
        };

        currentUpgrade = bulletAmmo;
    }

    public void BulletAmmoClicked()
    {
        ScreenManager.UpdateArmouryClicked(bulletAmmo);
        currentUpgrade = bulletAmmo;

        UpdateSelectedIcon(currentUpgrade);
    }

    public void BulletClipUpgradeClicked(int levelButton)
    {

        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateArmouryClicked(bulletClip1);
                currentUpgrade = bulletClip1;
                break;
            case 2:
                ScreenManager.UpdateArmouryClicked(bulletClip2);
                currentUpgrade = bulletClip2;
                break;
            case 3:
                ScreenManager.UpdateArmouryClicked(bulletClip3);
                currentUpgrade = bulletClip3;
                break;
            case 4:
                ScreenManager.UpdateArmouryClicked(bulletClip4);
                currentUpgrade = bulletClip4;
                break;
        }

        UpdateSelectedIcon(currentUpgrade);
    }

    public void BulletCooldownUpgradeClicked(int levelButton)
    {

        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateArmouryClicked(bulletCooldown1);
                currentUpgrade = bulletCooldown1;
                break;
            case 2:
                ScreenManager.UpdateArmouryClicked(bulletCooldown2);
                currentUpgrade = bulletCooldown2;
                break;
            case 3:
                ScreenManager.UpdateArmouryClicked(bulletCooldown3);
                currentUpgrade = bulletCooldown3;
                break;
            case 4:
                ScreenManager.UpdateArmouryClicked(bulletCooldown4);
                currentUpgrade = bulletCooldown4;
                break;
        }

        UpdateSelectedIcon(currentUpgrade);
    }

    public void MissleAmmoClicked()
    {
        ScreenManager.UpdateArmouryClicked(missleAmmo);
        currentUpgrade = missleAmmo;

        UpdateSelectedIcon(currentUpgrade);
    }

    public void MissleClipUpgradeClicked(int levelButton)
    {

        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateArmouryClicked(missleClip1);
                currentUpgrade = missleClip1;
                break;
            case 2:
                ScreenManager.UpdateArmouryClicked(missleClip2);
                currentUpgrade = missleClip2;
                break;
            case 3:
                ScreenManager.UpdateArmouryClicked(missleClip3);
                currentUpgrade = missleClip3;
                break;
            case 4:
                ScreenManager.UpdateArmouryClicked(missleClip4);
                currentUpgrade = missleClip4;
                break;
        }

        UpdateSelectedIcon(currentUpgrade);
    }

    public void MissleCooldownUpgradeClicked(int levelButton)
    {

        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateArmouryClicked(missleCooldown1);
                currentUpgrade = missleCooldown1;
                break;
            case 2:
                ScreenManager.UpdateArmouryClicked(missleCooldown2);
                currentUpgrade = missleCooldown2;
                break;
            case 3:
                ScreenManager.UpdateArmouryClicked(missleCooldown3);
                currentUpgrade = missleCooldown3;
                break;
            case 4:
                ScreenManager.UpdateArmouryClicked(missleCooldown4);
                currentUpgrade = missleCooldown4;
                break;
        }

        UpdateSelectedIcon(currentUpgrade);
    }
    public void MineAmmoClicked()
    {
        ScreenManager.UpdateArmouryClicked(mineAmmo);
        currentUpgrade = mineAmmo;

        UpdateSelectedIcon(currentUpgrade);
    }

    public void MineClipUpgradeClicked(int levelButton)
    {

        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateArmouryClicked(mineClip1);
                currentUpgrade = mineClip1;
                break;
            case 2:
                ScreenManager.UpdateArmouryClicked(mineClip2);
                currentUpgrade = mineClip2;
                break;
            case 3:
                ScreenManager.UpdateArmouryClicked(mineClip3);
                currentUpgrade = mineClip3;
                break;
            case 4:
                ScreenManager.UpdateArmouryClicked(mineClip4);
                currentUpgrade = mineClip4;
                break;
        }

        UpdateSelectedIcon(currentUpgrade);
    }

    public void MineCooldownUpgradeClicked(int levelButton)
    {

        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateArmouryClicked(mineCooldown1);
                currentUpgrade = mineCooldown1;
                break;
            case 2:
                ScreenManager.UpdateArmouryClicked(mineCooldown2);
                currentUpgrade = mineCooldown2;
                break;
            case 3:
                ScreenManager.UpdateArmouryClicked(mineCooldown3);
                currentUpgrade = mineCooldown3;
                break;
            case 4:
                ScreenManager.UpdateArmouryClicked(mineCooldown4);
                currentUpgrade = mineCooldown4;
                break;
        }

        UpdateSelectedIcon(currentUpgrade);
    }

    public static void UpdateArmouryIcons()
    {
        if (playerController == null) playerController = GameObject.Find("PlayerRacer").GetComponent<PlayerController>();

        int bulletClipLevel = playerController.BulletClipLevel;
        int bulletCooldownLevel = playerController.BulletCooldownLevel;

        int missleClipLevel = playerController.MissleClipLevel;
        int missleCooldownLevel = playerController.MissleCooldownLevel;

        int mineClipLevel = playerController.MineClipLevel;
        int mineCooldownLevel = playerController.MineCooldownLevel;

        int bulletAmmo = playerController.BulletAmmo;
        int bulletAmmoMax = playerController.BulletAmmoMax;

        int missleAmmo = playerController.MissleAmmo;
        int missleAmmoMax = playerController.MissleAmmoMax;

        int mineAmmo = playerController.MineAmmo;
        int mineAmmoMax = playerController.MineAmmoMax;

        foreach (GameObject icon in armouryIconList)
        {
            icon.SetActive(false);
        }

        switch (GameManager.GameLevel)
        {
            case 0:
                armouryT1.SetActive(true);
                armouryT2.SetActive(false);
                armouryT3.SetActive(false);
                armouryT4.SetActive(false);
                break;

            case 1:
                armouryT1.SetActive(false);
                armouryT2.SetActive(true);
                armouryT3.SetActive(false);
                armouryT4.SetActive(false);
                break;

            case 2:
                armouryT1.SetActive(false);
                armouryT2.SetActive(false);
                armouryT3.SetActive(true);
                armouryT4.SetActive(false);
                break;

            case 3:
                armouryT1.SetActive(false);
                armouryT2.SetActive(false);
                armouryT3.SetActive(false);
                armouryT4.SetActive(true);
                break;
        }

        if(bulletAmmo >= bulletAmmoMax)
        {
            bulletAmmo1Grey.SetActive(true);
            bulletAmmo2Grey.SetActive(true);
            bulletAmmo3Grey.SetActive(true);
            bulletAmmo4Grey.SetActive(true);
        }

        if (missleAmmo >= missleAmmoMax)
        {
            missleAmmo1Grey.SetActive(true);
            missleAmmo2Grey.SetActive(true);
            missleAmmo3Grey.SetActive(true);
            missleAmmo4Grey.SetActive(true);
        }

        if (mineAmmo >= mineAmmoMax)
        {
            mineAmmo1Grey.SetActive(true);
            mineAmmo2Grey.SetActive(true);
            mineAmmo3Grey.SetActive(true);
            mineAmmo4Grey.SetActive(true);
        }

        switch (bulletClipLevel)
        {
            case 1:
                bulletClip1Check.SetActive(true);
                break;
            case 2:
                bulletClip2Check.SetActive(true);
                break;
            case 3:
                bulletClip3Check.SetActive(true);
                break;
            case 4:
                bulletClip4Check.SetActive(true);
                break;
        }

        switch (bulletCooldownLevel)
        {
            case 1:
                bulletCooldown1Check.SetActive(true);
                break;
            case 2:
                bulletCooldown2Check.SetActive(true);
                break;
            case 3:
                bulletCooldown3Check.SetActive(true);
                break;
            case 4:
                bulletCooldown4Check.SetActive(true);
                break;
        }

        switch (missleClipLevel)
        {
            case 1:
                missleClip1Check.SetActive(true);
                break;
            case 2:
                missleClip2Check.SetActive(true);
                break;
            case 3:
                missleClip3Check.SetActive(true);
                break;
            case 4:
                missleClip4Check.SetActive(true);
                break;
        }

        switch (missleCooldownLevel)
        {
            case 1:
                missleCooldown1Check.SetActive(true);
                break;
            case 2:
                missleCooldown2Check.SetActive(true);
                break;
            case 3:
                missleCooldown3Check.SetActive(true);
                break;
            case 4:
                missleCooldown4Check.SetActive(true);
                break;
        }

        switch (mineClipLevel)
        {
            case 1:
                mineClip1Check.SetActive(true);
                break;
            case 2:
                mineClip2Check.SetActive(true);
                break;
            case 3:
                mineClip3Check.SetActive(true);
                break;
            case 4:
                mineClip4Check.SetActive(true);
                break;
        }

        switch (mineCooldownLevel)
        {
            case 1:
                mineCooldown1Check.SetActive(true);
                break;
            case 2:
                mineCooldown2Check.SetActive(true);
                break;
            case 3:
                mineCooldown3Check.SetActive(true);
                break;
            case 4:
                mineCooldown4Check.SetActive(true);
                break;
        }
    }

    public static Upgrade GetDefaultUpgrade()
    {
        return bulletAmmo;
    }

    static void UpdateSelectedIcon(Upgrade input)
    {
        if (!upgradeSelect.activeSelf) upgradeSelect.SetActive(true);

        switch (input.category)
        {
            case Upgrade.Category.bulletAmmo:
                upgradeSelect.transform.position = bulletAmmo1Grey.transform.position;
                break;

            case Upgrade.Category.bulletClip:
                upgradeSelect.transform.position = bulletClip1Check.transform.position;
                break;

            case Upgrade.Category.bulletCooldown:
                upgradeSelect.transform.position = bulletCooldown1Check.transform.position;
                break;

            case Upgrade.Category.missleAmmo:
                upgradeSelect.transform.position = missleAmmo1Grey.transform.position;
                break;

            case Upgrade.Category.missleClip:
                upgradeSelect.transform.position = missleClip1Check.transform.position;
                break;

            case Upgrade.Category.missleCooldown:
                upgradeSelect.transform.position = missleCooldown1Check.transform.position;
                break;

            case Upgrade.Category.mineAmmo:
                upgradeSelect.transform.position = mineAmmo1Grey.transform.position;
                break;

            case Upgrade.Category.mineClip:
                upgradeSelect.transform.position = mineClip1Check.transform.position;
                break;

            case Upgrade.Category.mineCooldown:
                upgradeSelect.transform.position = mineCooldown1Check.transform.position;
                break;
        }
    }

    public void PurchaseClicked()
    {
        player = GameObject.Find("PlayerRacer").GetComponent<PlayerController>();
        switch (currentUpgrade.category)
        {
            case Upgrade.Category.bulletAmmo:
                player.SpendMoney(currentUpgrade.price);
                player.BulletAmmo += currentUpgrade.upgradeNumber;
                break;

            case Upgrade.Category.bulletClip:
                player.SpendMoney(currentUpgrade.price);
                player.BulletClipLevel = currentUpgrade.upgradeNumber;
                break;

            case Upgrade.Category.bulletCooldown:
                player.SpendMoney(currentUpgrade.price);
                player.BulletCooldownLevel = currentUpgrade.upgradeNumber;
                break;

            case Upgrade.Category.missleAmmo:
                player.SpendMoney(currentUpgrade.price);
                player.MissleAmmo += currentUpgrade.upgradeNumber;
                break;

            case Upgrade.Category.missleClip:
                player.SpendMoney(currentUpgrade.price);
                player.MissleClipLevel = currentUpgrade.upgradeNumber;
                break;

            case Upgrade.Category.missleCooldown:
                player.SpendMoney(currentUpgrade.price);
                player.MissleCooldownLevel = currentUpgrade.upgradeNumber;
                break;

            case Upgrade.Category.mineAmmo:
                player.SpendMoney(currentUpgrade.price);
                player.MineAmmo += currentUpgrade.upgradeNumber;
                break;

            case Upgrade.Category.mineClip:
                player.SpendMoney(currentUpgrade.price);
                player.MineClipLevel = currentUpgrade.upgradeNumber;
                break;

            case Upgrade.Category.mineCooldown:
                player.SpendMoney(currentUpgrade.price);
                player.MineCooldownLevel = currentUpgrade.upgradeNumber;
                break;
        }

        if(currentUpgrade.category != Upgrade.Category.bulletAmmo && currentUpgrade.category != Upgrade.Category.missleAmmo && currentUpgrade.category != Upgrade.Category.mineAmmo) currentUpgrade.state = Upgrade.State.owned;

        playerController.UpdateRacer();
        UpdateArmouryIcons();
        ScreenManager.UpdateArmouryClicked(currentUpgrade);
    }
}
