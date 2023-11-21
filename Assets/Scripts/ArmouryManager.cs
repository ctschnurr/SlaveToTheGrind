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

    static Upgrade bulletAmmo1;
    static Upgrade bulletAmmo2;
    static Upgrade bulletAmmo3;
    static Upgrade bulletAmmo4;
    static Upgrade bulletClip1;
    static Upgrade bulletClip2;
    static Upgrade bulletClip3;
    static Upgrade bulletClip4;
    static Upgrade bulletCooldown1;
    static Upgrade bulletCooldown2;
    static Upgrade bulletCooldown3;
    static Upgrade bulletCooldown4;

    static Upgrade missleAmmo1;
    static Upgrade missleAmmo2;
    static Upgrade missleAmmo3;
    static Upgrade missleAmmo4;
    static Upgrade missleClip1;
    static Upgrade missleClip2;
    static Upgrade missleClip3;
    static Upgrade missleClip4;
    static Upgrade missleCooldown1;
    static Upgrade missleCooldown2;
    static Upgrade missleCooldown3;
    static Upgrade missleCooldown4;

    static Upgrade mineAmmo1;
    static Upgrade mineAmmo2;
    static Upgrade mineAmmo3;
    static Upgrade mineAmmo4;
    static Upgrade mineClip1;
    static Upgrade mineClip2;
    static Upgrade mineClip3;
    static Upgrade mineClip4;
    static Upgrade mineCooldown1;
    static Upgrade mineCooldown2;
    static Upgrade mineCooldown3;
    static Upgrade mineCooldown4;

    private static List<Upgrade> upgradeList;

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
    static GameObject bulletClip1Grey;
    static GameObject bulletCooldown1Check;
    static GameObject bulletCooldown1Grey;

    static GameObject missleAmmo1Grey;
    static GameObject missleClip1Check;
    static GameObject missleClip1Grey;
    static GameObject missleCooldown1Check;
    static GameObject missleCooldown1Grey;

    static GameObject mineAmmo1Grey;
    static GameObject mineClip1Check;
    static GameObject mineClip1Grey;
    static GameObject mineCooldown1Check;
    static GameObject mineCooldown1Grey;

    // T2 Armoury Elements:
    static GameObject bulletAmmo2Grey;
    static GameObject bulletClip2Check;
    static GameObject bulletClip2Grey;
    static GameObject bulletCooldown2Check;
    static GameObject bulletCooldown2Grey;

    static GameObject missleAmmo2Grey;
    static GameObject missleClip2Check;
    static GameObject missleClip2Grey;
    static GameObject missleCooldown2Check;
    static GameObject missleCooldown2Grey;

    static GameObject mineAmmo2Grey;
    static GameObject mineClip2Check;
    static GameObject mineClip2Grey;
    static GameObject mineCooldown2Check;
    static GameObject mineCooldown2Grey;

    // T3 Armoury Elements
    static GameObject bulletAmmo3Grey;
    static GameObject bulletClip3Check;
    static GameObject bulletClip3Grey;
    static GameObject bulletCooldown3Check;
    static GameObject bulletCooldown3Grey;

    static GameObject missleAmmo3Grey;
    static GameObject missleClip3Check;
    static GameObject missleClip3Grey;
    static GameObject missleCooldown3Check;
    static GameObject missleCooldown3Grey;

    static GameObject mineAmmo3Grey;
    static GameObject mineClip3Check;
    static GameObject mineClip3Grey;
    static GameObject mineCooldown3Check;
    static GameObject mineCooldown3Grey;

    // T4 Armoury Elements
    static GameObject bulletAmmo4Grey;
    static GameObject bulletClip4Check;
    static GameObject bulletClip4Grey;
    static GameObject bulletCooldown4Check;
    static GameObject bulletCooldown4Grey;

    static GameObject missleAmmo4Grey;
    static GameObject missleClip4Check;
    static GameObject missleClip4Grey;
    static GameObject missleCooldown4Check;
    static GameObject missleCooldown4Grey;

    static GameObject mineAmmo4Grey;
    static GameObject mineClip4Check;
    static GameObject mineClip4Grey;
    static GameObject mineCooldown4Check;
    static GameObject mineCooldown4Grey;

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
        bulletClip1Grey = GameObject.Find("ScreenManager/Armoury/T1/BulletUpgrades/Upgrade2/Grey");
        bulletCooldown1Check = GameObject.Find("ScreenManager/Armoury/T1/BulletUpgrades/Upgrade3/Check");
        bulletCooldown1Grey = GameObject.Find("ScreenManager/Armoury/T1/BulletUpgrades/Upgrade3/Grey");

        missleAmmo1Grey = GameObject.Find("ScreenManager/Armoury/T1/MissleUpgrades/Upgrade1/Grey");
        missleClip1Check = GameObject.Find("ScreenManager/Armoury/T1/MissleUpgrades/Upgrade2/Check");
        missleClip1Grey = GameObject.Find("ScreenManager/Armoury/T1/MissleUpgrades/Upgrade2/Grey");
        missleCooldown1Check = GameObject.Find("ScreenManager/Armoury/T1/MissleUpgrades/Upgrade3/Check");
        missleCooldown1Grey = GameObject.Find("ScreenManager/Armoury/T1/MissleUpgrades/Upgrade3/Grey");

        mineAmmo1Grey = GameObject.Find("ScreenManager/Armoury/T1/MineUpgrades/Upgrade1/Grey");
        mineClip1Check = GameObject.Find("ScreenManager/Armoury/T1/MineUpgrades/Upgrade2/Check");
        mineClip1Grey = GameObject.Find("ScreenManager/Armoury/T1/MineUpgrades/Upgrade2/Grey");
        mineCooldown1Check = GameObject.Find("ScreenManager/Armoury/T1/MineUpgrades/Upgrade3/Check");
        mineCooldown1Grey = GameObject.Find("ScreenManager/Armoury/T1/MineUpgrades/Upgrade3/Grey");

        bulletAmmo2Grey = GameObject.Find("ScreenManager/Armoury/T2/BulletUpgrades/Upgrade1/Grey");
        bulletClip2Check = GameObject.Find("ScreenManager/Armoury/T2/BulletUpgrades/Upgrade2/Check");
        bulletClip2Grey = GameObject.Find("ScreenManager/Armoury/T2/BulletUpgrades/Upgrade2/Grey");
        bulletCooldown2Check = GameObject.Find("ScreenManager/Armoury/T2/BulletUpgrades/Upgrade3/Check");
        bulletCooldown2Grey = GameObject.Find("ScreenManager/Armoury/T2/BulletUpgrades/Upgrade3/Grey");

        missleAmmo2Grey = GameObject.Find("ScreenManager/Armoury/T2/MissleUpgrades/Upgrade1/Grey");
        missleClip2Check = GameObject.Find("ScreenManager/Armoury/T2/MissleUpgrades/Upgrade2/Check");
        missleClip2Grey = GameObject.Find("ScreenManager/Armoury/T2/MissleUpgrades/Upgrade2/Grey");
        missleCooldown2Check = GameObject.Find("ScreenManager/Armoury/T2/MissleUpgrades/Upgrade3/Check");
        missleCooldown2Grey = GameObject.Find("ScreenManager/Armoury/T2/MissleUpgrades/Upgrade3/Grey");

        mineAmmo2Grey = GameObject.Find("ScreenManager/Armoury/T2/MineUpgrades/Upgrade1/Grey");
        mineClip2Check = GameObject.Find("ScreenManager/Armoury/T2/MineUpgrades/Upgrade2/Check");
        mineClip2Grey = GameObject.Find("ScreenManager/Armoury/T2/MineUpgrades/Upgrade2/Grey");
        mineCooldown2Check = GameObject.Find("ScreenManager/Armoury/T2/MineUpgrades/Upgrade3/Check");
        mineCooldown2Grey = GameObject.Find("ScreenManager/Armoury/T2/MineUpgrades/Upgrade3/Grey");

        bulletAmmo3Grey = GameObject.Find("ScreenManager/Armoury/T3/BulletUpgrades/Upgrade1/Grey");
        bulletClip3Check = GameObject.Find("ScreenManager/Armoury/T3/BulletUpgrades/Upgrade2/Check");
        bulletClip3Grey = GameObject.Find("ScreenManager/Armoury/T3/BulletUpgrades/Upgrade2/Grey");
        bulletCooldown3Check = GameObject.Find("ScreenManager/Armoury/T3/BulletUpgrades/Upgrade3/Check");
        bulletCooldown3Grey = GameObject.Find("ScreenManager/Armoury/T3/BulletUpgrades/Upgrade3/Grey");

        missleAmmo3Grey = GameObject.Find("ScreenManager/Armoury/T3/MissleUpgrades/Upgrade1/Grey");
        missleClip3Check = GameObject.Find("ScreenManager/Armoury/T3/MissleUpgrades/Upgrade2/Check");
        missleClip3Grey = GameObject.Find("ScreenManager/Armoury/T3/MissleUpgrades/Upgrade2/Grey");
        missleCooldown3Check = GameObject.Find("ScreenManager/Armoury/T3/MissleUpgrades/Upgrade3/Check");
        missleCooldown3Grey = GameObject.Find("ScreenManager/Armoury/T3/MissleUpgrades/Upgrade3/Grey");

        mineAmmo3Grey = GameObject.Find("ScreenManager/Armoury/T3/MineUpgrades/Upgrade1/Grey");
        mineClip3Check = GameObject.Find("ScreenManager/Armoury/T3/MineUpgrades/Upgrade2/Check");
        mineClip3Grey = GameObject.Find("ScreenManager/Armoury/T3/MineUpgrades/Upgrade2/Grey");
        mineCooldown3Check = GameObject.Find("ScreenManager/Armoury/T3/MineUpgrades/Upgrade3/Check");
        mineCooldown3Grey = GameObject.Find("ScreenManager/Armoury/T3/MineUpgrades/Upgrade3/Grey");

        bulletAmmo4Grey = GameObject.Find("ScreenManager/Armoury/T4/BulletUpgrades/Upgrade1/Grey");
        bulletClip4Check = GameObject.Find("ScreenManager/Armoury/T4/BulletUpgrades/Upgrade2/Check");
        bulletClip4Grey = GameObject.Find("ScreenManager/Armoury/T4/BulletUpgrades/Upgrade2/Grey");
        bulletCooldown4Check = GameObject.Find("ScreenManager/Armoury/T4/BulletUpgrades/Upgrade3/Check");
        bulletCooldown4Grey = GameObject.Find("ScreenManager/Armoury/T4/BulletUpgrades/Upgrade3/Grey");

        missleAmmo4Grey = GameObject.Find("ScreenManager/Armoury/T4/MissleUpgrades/Upgrade1/Grey");
        missleClip4Check = GameObject.Find("ScreenManager/Armoury/T4/MissleUpgrades/Upgrade2/Check");
        missleClip4Grey = GameObject.Find("ScreenManager/Armoury/T4/MissleUpgrades/Upgrade2/Grey");
        missleCooldown4Check = GameObject.Find("ScreenManager/Armoury/T4/MissleUpgrades/Upgrade3/Check");
        missleCooldown4Grey = GameObject.Find("ScreenManager/Armoury/T4/MissleUpgrades/Upgrade3/Grey");

        mineAmmo4Grey = GameObject.Find("ScreenManager/Armoury/T4/MineUpgrades/Upgrade1/Grey");
        mineClip4Check = GameObject.Find("ScreenManager/Armoury/T4/MineUpgrades/Upgrade2/Check");
        mineClip4Grey = GameObject.Find("ScreenManager/Armoury/T4/MineUpgrades/Upgrade2/Grey");
        mineCooldown4Check = GameObject.Find("ScreenManager/Armoury/T4/MineUpgrades/Upgrade3/Check");
        mineCooldown4Grey = GameObject.Find("ScreenManager/Armoury/T4/MineUpgrades/Upgrade3/Grey");

        armouryIconList = new List<GameObject>
        {
            bulletAmmo1Grey, bulletClip1Check, bulletClip1Grey, bulletCooldown1Check, bulletCooldown1Grey, missleAmmo1Grey, missleClip1Check, missleClip1Grey, missleCooldown1Check, missleCooldown1Grey, mineAmmo1Grey, mineClip1Check, mineClip1Grey, mineCooldown1Check, mineCooldown1Grey,
            bulletAmmo2Grey, bulletClip2Check, bulletClip2Grey, bulletCooldown2Check, bulletCooldown2Grey, missleAmmo2Grey, missleClip2Check, missleClip2Grey, missleCooldown2Check, missleCooldown2Grey, mineAmmo2Grey, mineClip2Check, mineClip2Grey, mineCooldown2Check, mineCooldown2Grey,
            bulletAmmo3Grey, bulletClip3Check, bulletClip3Grey, bulletCooldown3Check, bulletCooldown3Grey, missleAmmo3Grey, missleClip3Check, missleClip3Grey, missleCooldown3Check, missleCooldown3Grey, mineAmmo3Grey, mineClip3Check, mineClip3Grey, mineCooldown3Check, mineCooldown3Grey,
            bulletAmmo4Grey, bulletClip4Check, bulletClip4Grey, bulletCooldown4Check, bulletCooldown4Grey, missleAmmo4Grey, missleClip4Check, missleClip4Grey, missleCooldown4Check, missleCooldown4Grey, mineAmmo4Grey, mineClip4Check, mineClip4Grey, mineCooldown4Check, mineCooldown4Grey
        };
    }

    public void SetupArmoury()
    {
        StartElements();

        bulletAmmo1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.bulletAmmo,
            state = Upgrade.State.available,
            name = "Bullet Ammo",
            description = "Purchase bullet ammo, $5/bullet",
            price = 5,
            greyObj = bulletAmmo1Grey,
            checkObj = null,
            lockObj = null
        };

        bulletAmmo2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.bulletAmmo,
            state = Upgrade.State.available,
            name = "Bullet Ammo",
            description = "Purchase bullet ammo, $5/bullet",
            price = 5,
            greyObj = bulletAmmo2Grey,
            checkObj = null,
            lockObj = null
        };

        bulletAmmo3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.bulletAmmo,
            state = Upgrade.State.available,
            name = "Bullet Ammo",
            description = "Purchase bullet ammo, $5/bullet",
            price = 3,
            greyObj = bulletAmmo1Grey,
            checkObj = null,
            lockObj = null
        };

        bulletAmmo4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.bulletAmmo,
            state = Upgrade.State.available,
            name = "Bullet Ammo",
            description = "Purchase bullet ammo, $5/bullet",
            price = 5,
            greyObj = bulletAmmo4Grey,
            checkObj = null,
            lockObj = null
        };

        bulletClip1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.bulletClip,
            state = Upgrade.State.available,
            name = "Bullet Clip Upgrade I",
            description = "Bullet ammo capacity +20",
            price = 100,
            greyObj = bulletClip1Grey,
            checkObj = bulletClip1Check,
            lockObj = null
        };

        bulletClip2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.bulletClip,
            state = Upgrade.State.available,
            name = "Bullet Clip Upgrade II",
            description = "Bullet ammo capacity +40",
            price = 150,
            greyObj = bulletClip2Grey,
            checkObj = bulletClip2Check,
            lockObj = null
        };

        bulletClip3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.bulletClip,
            state = Upgrade.State.available,
            name = "Bullet Clip Upgrade III",
            description = "Bullet ammo capacity +60",
            price = 200,
            greyObj = bulletClip3Grey,
            checkObj = bulletClip3Check,
            lockObj = null
        };

        bulletClip4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.bulletClip,
            state = Upgrade.State.available,
            name = "Bullet Clip Upgrade IV",
            description = "Bullet ammo capacity +80",
            price = 250,
            greyObj = bulletClip4Grey,
            checkObj = bulletClip4Check,
            lockObj = null
        };

        bulletCooldown1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.bulletCooldown,
            state = Upgrade.State.available,
            name = "Bullet Cooldown Upgrade I",
            description = "Bullet cooldown decrease.",
            price = 100,
            greyObj = bulletCooldown1Grey,
            checkObj = bulletCooldown1Check,
            lockObj = null
        };

        bulletCooldown2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.bulletCooldown,
            state = Upgrade.State.available,
            name = "Bullet Cooldown Upgrade II",
            description = "Bullet cooldown decrease.",
            price = 150,
            greyObj = bulletCooldown2Grey,
            checkObj = bulletCooldown2Check,
            lockObj = null
        };

        bulletCooldown3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.bulletCooldown,
            state = Upgrade.State.available,
            name = "Bullet Cooldown Upgrade III",
            description = "Bullet cooldown decrease.",
            price = 200,
            greyObj = bulletCooldown3Grey,
            checkObj = bulletCooldown3Check,
            lockObj = null
        };

        bulletCooldown4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.bulletCooldown,
            state = Upgrade.State.available,
            name = "Bullet Cooldown Upgrade IV",
            description = "Bullet cooldown decrease.",
            price = 250,
            greyObj = bulletCooldown4Grey,
            checkObj = bulletCooldown4Check,
            lockObj = null
        };

        missleAmmo1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.missleAmmo,
            state = Upgrade.State.available,
            name = "Missle Ammo",
            description = "Purchase missles, $15/missle",
            price = 5,
            greyObj = missleAmmo1Grey,
            checkObj = null,
            lockObj = null
        };

        missleAmmo2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.missleAmmo,
            state = Upgrade.State.available,
            name = "Missle Ammo",
            description = "Purchase missles, $15/missle",
            price = 5,
            greyObj = missleAmmo2Grey,
            checkObj = null,
            lockObj = null
        };

        missleAmmo3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.missleAmmo,
            state = Upgrade.State.available,
            name = "Missle Ammo",
            description = "Purchase missles, $15/missle",
            price = 5,
            greyObj = missleAmmo3Grey,
            checkObj = null,
            lockObj = null
        };

        missleAmmo4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.missleAmmo,
            state = Upgrade.State.available,
            name = "Missle Ammo",
            description = "Purchase missles, $15/missle",
            price = 5,
            greyObj = missleAmmo4Grey,
            checkObj = null,
            lockObj = null
        };

        missleClip1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.missleClip,
            state = Upgrade.State.available,
            name = "Missle Clip Upgrade I",
            description = "Missle ammo capacity +5",
            price = 100,
            greyObj = missleClip1Grey,
            checkObj = missleClip1Check,
            lockObj = null
        };

        missleClip2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.missleClip,
            state = Upgrade.State.available,
            name = "Missle Clip Upgrade II",
            description = "Missle ammo capacity +10",
            price = 150,
            greyObj = missleClip2Grey,
            checkObj = missleClip2Check,
            lockObj = null
        };

        missleClip3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.missleClip,
            state = Upgrade.State.available,
            name = "Missle Clip Upgrade III",
            description = "Missle ammo capacity +15",
            price = 200,
            greyObj = missleClip3Grey,
            checkObj = missleClip3Check,
            lockObj = null
        };

        missleClip4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.missleClip,
            state = Upgrade.State.available,
            name = "Missle Clip Upgrade IV",
            description = "Missle ammo capacity +20",
            price = 250,
            greyObj = missleClip4Grey,
            checkObj = missleClip4Check,
            lockObj = null
        };

        missleCooldown1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.missleCooldown,
            state = Upgrade.State.available,
            name = "Missle Cooldown Upgrade I",
            description = "Missle cooldown decrease.",
            price = 100,
            greyObj = missleCooldown1Grey,
            checkObj = missleCooldown1Check,
            lockObj = null
        };

        missleCooldown2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.missleCooldown,
            state = Upgrade.State.available,
            name = "Missle Cooldown Upgrade II",
            description = "Missle cooldown decrease.",
            price = 150,
            greyObj = missleCooldown2Grey,
            checkObj = missleCooldown2Check,
            lockObj = null
        };

        missleCooldown3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.missleCooldown,
            state = Upgrade.State.available,
            name = "Missle Cooldown Upgrade III",
            description = "Missle cooldown decrease.",
            price = 200,
            greyObj = missleCooldown3Grey,
            checkObj = missleCooldown3Check,
            lockObj = null
        };

        missleCooldown4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.missleCooldown,
            state = Upgrade.State.available,
            name = "Missle Cooldown Upgrade IV",
            description = "Missle cooldown decrease.",
            price = 250,
            greyObj = missleCooldown4Grey,
            checkObj = missleCooldown4Check,
            lockObj = null
        };

        mineAmmo1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.mineAmmo,
            state = Upgrade.State.available,
            name = "Mine Ammo",
            description = "Purchase mines, $15/mine",
            price = 5,
            greyObj = mineAmmo1Grey,
            checkObj = null,
            lockObj = null
        };

        mineAmmo2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.mineAmmo,
            state = Upgrade.State.available,
            name = "Mine Ammo",
            description = "Purchase mines, $15/mine",
            price = 5,
            greyObj = mineAmmo2Grey,
            checkObj = null,
            lockObj = null
        };

        mineAmmo3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.mineAmmo,
            state = Upgrade.State.available,
            name = "Mine Ammo",
            description = "Purchase mines, $15/mine",
            price = 5,
            greyObj = mineAmmo3Grey,
            checkObj = null,
            lockObj = null
        };

        mineAmmo4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.mineAmmo,
            state = Upgrade.State.available,
            name = "Mine Ammo",
            description = "Purchase mines, $15/mine",
            price = 5,
            greyObj = mineAmmo4Grey,
            checkObj = null,
            lockObj = null
        };

        mineClip1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.mineClip,
            state = Upgrade.State.available,
            name = "Mine Clip Upgrade I",
            description = "Mine ammo capacity +5",
            price = 100,
            greyObj = mineClip1Grey,
            checkObj = mineClip1Check,
            lockObj = null
        };

        mineClip2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.mineClip,
            state = Upgrade.State.available,
            name = "Mine Clip Upgrade II",
            description = "Mine ammo capacity +10",
            price = 150,
            greyObj = mineClip2Grey,
            checkObj = mineClip2Check,
            lockObj = null
        };

        mineClip3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.mineClip,
            state = Upgrade.State.available,
            name = "Mine Clip Upgrade III",
            description = "Mine ammo capacity +15",
            price = 200,
            greyObj = mineClip3Grey,
            checkObj = mineClip3Check,
            lockObj = null
        };

        mineClip4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.mineClip,
            state = Upgrade.State.available,
            name = "Mine Clip Upgrade IV",
            description = "Mine ammo capacity +20",
            price = 250,
            greyObj = mineClip4Grey,
            checkObj = mineClip4Check,
            lockObj = null
        };

        mineCooldown1 = new Upgrade
        {
            upgradeNumber = 1,
            category = Upgrade.Category.mineCooldown,
            state = Upgrade.State.available,
            name = "Mine Cooldown Upgrade I",
            description = "Mine cooldown decrease.",
            price = 100,
            greyObj = mineCooldown1Grey,
            checkObj = mineCooldown1Check,
            lockObj = null
        };

        mineCooldown2 = new Upgrade
        {
            upgradeNumber = 2,
            category = Upgrade.Category.mineCooldown,
            state = Upgrade.State.available,
            name = "Mine Cooldown Upgrade II",
            description = "Mine cooldown decrease.",
            price = 150,
            greyObj = mineCooldown2Grey,
            checkObj = mineCooldown2Check,
            lockObj = null
        };

        mineCooldown3 = new Upgrade
        {
            upgradeNumber = 3,
            category = Upgrade.Category.mineCooldown,
            state = Upgrade.State.available,
            name = "Mine Cooldown Upgrade III",
            description = "Mine cooldown decrease.",
            price = 200,
            greyObj = mineCooldown3Grey,
            checkObj = mineCooldown3Check,
            lockObj = null
        };

        mineCooldown4 = new Upgrade
        {
            upgradeNumber = 4,
            category = Upgrade.Category.mineCooldown,
            state = Upgrade.State.available,
            name = "Mine Cooldown Upgrade IV",
            description = "Mine cooldown decrease.",
            price = 250,
            greyObj = mineCooldown4Grey,
            checkObj = mineCooldown4Check,
            lockObj = null
        };

        upgradeList = new List<Upgrade>()
        {
            bulletAmmo1, bulletClip1, bulletCooldown1, missleAmmo1, missleClip1, missleCooldown1, mineAmmo1, mineClip1, mineCooldown1,
            bulletAmmo2, bulletClip2, bulletCooldown2, missleAmmo2, missleClip2, missleCooldown2, mineAmmo2, mineClip2, mineCooldown2,
            bulletAmmo3, bulletClip3, bulletCooldown3, missleAmmo3, missleClip3, missleCooldown3, mineAmmo3, mineClip3, mineCooldown3,
            bulletAmmo4, bulletClip4, bulletCooldown4, missleAmmo4, missleClip4, missleCooldown4, mineAmmo4, mineClip4, mineCooldown4
        };

        currentUpgrade = GetDefaultUpgrade();
    }

    public void BulletAmmoClicked(int levelButton)
    {
        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateArmouryClicked(bulletAmmo1);
                currentUpgrade = bulletAmmo1;
                break;
            case 2:
                ScreenManager.UpdateArmouryClicked(bulletAmmo2);
                currentUpgrade = bulletAmmo2;
                break;
            case 3:
                ScreenManager.UpdateArmouryClicked(bulletAmmo3);
                currentUpgrade = bulletAmmo3;
                break;
            case 4:
                ScreenManager.UpdateArmouryClicked(bulletAmmo4);
                currentUpgrade = bulletAmmo4;
                break;
        }

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

    public void MissleAmmoClicked(int levelButton)
    {
        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateArmouryClicked(missleAmmo1);
                currentUpgrade = missleAmmo1;
                break;
            case 2:
                ScreenManager.UpdateArmouryClicked(missleAmmo2);
                currentUpgrade = missleAmmo2;
                break;
            case 3:
                ScreenManager.UpdateArmouryClicked(missleAmmo3);
                currentUpgrade = missleAmmo3;
                break;
            case 4:
                ScreenManager.UpdateArmouryClicked(missleAmmo4);
                currentUpgrade = missleAmmo4;
                break;
        }

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
    public void MineAmmoClicked(int levelButton)
    {
        switch (levelButton)
        {
            case 1:
                ScreenManager.UpdateArmouryClicked(mineAmmo1);
                currentUpgrade = mineAmmo1;
                break;
            case 2:
                ScreenManager.UpdateArmouryClicked(mineAmmo2);
                currentUpgrade = mineAmmo2;
                break;
            case 3:
                ScreenManager.UpdateArmouryClicked(mineAmmo3);
                currentUpgrade = mineAmmo3;
                break;
            case 4:
                ScreenManager.UpdateArmouryClicked(mineAmmo4);
                currentUpgrade = mineAmmo4;
                break;
        }

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

        foreach (Upgrade upgrade in upgradeList)
        {
            switch (upgrade.state)
            {
                case Upgrade.State.available:
                    if (playerController.TotalMoney < upgrade.price) upgrade.greyObj.SetActive(true);
                    if (upgrade.checkObj != null) upgrade.checkObj.SetActive(false);
                    break;

                case Upgrade.State.owned:
                    upgrade.greyObj.SetActive(false);
                    upgrade.checkObj.SetActive(true);
                    break;
            }
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
    }

    public static Upgrade GetDefaultUpgrade()
    {
        return bulletAmmo1;
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
